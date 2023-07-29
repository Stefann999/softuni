using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Linq;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths;
        private DelicacyRepository delicacies;
        private CocktailRepository cocktails;

        public Controller()
        {
            booths = new BoothRepository();       
            delicacies = new DelicacyRepository();
            cocktails = new CocktailRepository();
        }


        public string AddBooth(int capacity)
        {
            int id = booths.Models.Count + 1;
            Booth booth = new Booth(id, capacity);
            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, id, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != nameof(MulledWine) && cocktailTypeName != nameof(Hibernation))
            {
                return string
                    .Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }
            else if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }
            else if (cocktails.Models.Any(x => x.Name == cocktailName && x.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            ICocktail cocktail;
            if (cocktailTypeName == nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else
            {
                cocktail = new Hibernation(cocktailName, size);
            }

            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            booth.CocktailMenu.AddModel(cocktail);
            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != "Gingerbread" && delicacyTypeName != "Stolen")
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }
            else if (delicacies.Models.Any(x => x.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            IDelicacy delicacy;
            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else
            {
                delicacy = new Stolen(delicacyName);
            }

            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {boothId}");
            sb.AppendLine($"Capacity: {booth.Capacity}");
            sb.AppendLine($"Turnover: {booth.Turnover:f2} lv");

            foreach (var item in booth.CocktailMenu.Models)
            {
                sb.AppendLine(item.ToString());
            }

            foreach (var item in booth.DelicacyMenu.Models)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            booth.Charge();
            booth.ChangeStatus();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {booth.CurrentBill:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            var booth = booths.Models.Where(b => b.IsReserved == false && b.Capacity >= countOfPeople).OrderBy(x => x.Capacity).ThenByDescending(x => x.BoothId).FirstOrDefault();
            if (booth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            booth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);


            string[] info = order.Split('/');
            string itemTypeName = info[0];
            string itemName = info[1];
            int cnt = int.Parse(info[2]);
           

            if (itemTypeName != nameof(MulledWine) &&
               itemTypeName != nameof(Hibernation) &&
               itemTypeName != nameof(Gingerbread) &&
               itemTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if (!booth.CocktailMenu.Models.Any(m => m.Name == itemName) &&
                !booth.DelicacyMenu.Models.Any(m => m.Name == itemName))
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }


            if (itemTypeName == nameof(MulledWine) || itemTypeName == nameof(Hibernation))
            {
                string size = info[3];

                ICocktail desiredCocktail = booth
                 .CocktailMenu.Models
                 .FirstOrDefault(m => m.GetType().Name == itemTypeName && m.Name == itemName && m.Size == size);

                if (desiredCocktail == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }

                booth.UpdateCurrentBill(desiredCocktail.Price * cnt);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, cnt, itemName);
            }

            else
            {
                IDelicacy desiredDelicacy = booth.DelicacyMenu.Models.FirstOrDefault(m => m.GetType().Name == itemTypeName && m.Name == itemName);

                if (desiredDelicacy == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, itemName);
                }
                booth.UpdateCurrentBill(desiredDelicacy.Price * cnt);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, cnt, itemName);
            }
        }
    }
}
