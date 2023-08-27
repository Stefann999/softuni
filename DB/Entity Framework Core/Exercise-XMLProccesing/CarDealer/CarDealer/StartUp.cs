using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.DTOs.Export;
using CarDealer.Models;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

           //string xmlSuppliers = File.ReadAllText(@"../../../Datasets/suppliers.xml");
           //ImportSuppliers(context, xmlSuppliers);
           //
           //string xmlParts = File.ReadAllText(@"../../../Datasets/parts.xml");
           //ImportParts(context, xmlParts);
           //
           //string xmlCars = File.ReadAllText(@"../../../Datasets/cars.xml");
           //ImportCars(context, xmlCars);
           //
           //string xmlCustomers = File.ReadAllText(@"../../../Datasets/customers.xml");
           //ImportCustomers(context, xmlCustomers);
           //
           //string xmlSales = File.ReadAllText(@"../../../Datasets/sales.xml");
           //ImportSales(context, xmlSales);

           Console.WriteLine(GetCarsFromMakeBmw(context));
        }
        private static T Deserializer<T>(string inputXml, string rootName)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            using StringReader reader = new StringReader(inputXml);

            T dtos = (T)serializer.Deserialize(reader);
            return dtos;
        }
        private static string Serializer<T>(T dataTransferObjects, string xmlRootAttributeName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));

            StringBuilder sb = new StringBuilder();
            using var write = new StringWriter(sb);

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            serializer.Serialize(write, dataTransferObjects, xmlNamespaces);

            return sb.ToString();
        }

        //09.Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XDocument xmlDocument = XDocument.Parse(inputXml);

            var suppliers = xmlDocument.Root.Elements();

            foreach (var supplier in suppliers)
            {
                Supplier s = new Supplier()
                {
                    Name = supplier.Element("name").Value,
                    IsImporter = bool.Parse(supplier.Element("isImporter").Value)
                };

                context.Suppliers.Add(s);
            }

            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }

        //10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XDocument xmlDocument = XDocument.Parse(inputXml);

            var parts = xmlDocument.Root.Elements();

            int cnt = 0;

            foreach (var part in parts)
            {
                int suppId = int.Parse(part.Element("supplierId").Value);
                if (!context.Suppliers.Any(s => s.Id == suppId))
                {
                    continue;
                }
                
                Part p = new Part()
                {
                    Name = part.Element("name").Value,
                    Price = decimal.Parse(part.Element("price").Value),
                    Quantity = int.Parse(part.Element("quantity").Value),
                    SupplierId = int.Parse(part.Element("supplierId").Value)
                };

                context.Parts.Add(p);
                cnt++;
            }

            context.SaveChanges();

            return $"Successfully imported {cnt}";
        }

        //11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            ImportCarsDto[] carsDtos = Deserializer<ImportCarsDto[]>(inputXml, "Cars");

            List<Car> cars = new List<Car>();
            List<PartCar> partCars = new List<PartCar>();
            int[] allPartIds = context.Parts.Select(p => p.Id).ToArray();
            int carId = 1;

            foreach (var dto in carsDtos)
            {
                Car car = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TraveledDistance = dto.TraveledDistance
                };

                cars.Add(car);

                foreach (int partId in dto.Parts
                             .Where(p => allPartIds.Contains(p.PartId))
                             .Select(p => p.PartId)
                             .Distinct())
                {
                    PartCar partCar = new PartCar()
                    {
                        CarId = carId,
                        PartId = partId
                    };
                    partCars.Add(partCar);
                }
                carId++;
            }

            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(partCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XDocument xmlDocument = XDocument.Parse(inputXml);

            var customers = xmlDocument.Root.Elements();

            int cnt = 0;

            foreach (var customer in customers)
            {
                Customer c = new Customer()
                {
                    Name = customer.Element("name").Value,
                    BirthDate = DateTime.Parse(customer.Element("birthDate").Value),
                    IsYoungDriver = bool.Parse(customer.Element("isYoungDriver").Value)
                };

                context.Customers.Add(c);
                cnt++;
            }

            context.SaveChanges();

            return $"Successfully imported {cnt}";
        }

        //13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {

            XDocument xmlDocument = XDocument.Parse(inputXml);

            var sales = xmlDocument.Root.Elements();

            int cnt = 0;

            foreach (var sale in sales)
            {
                int carId = int.Parse(sale.Element("carId").Value);
                if (!context.Cars.Any(s => s.Id == carId))
                {
                    continue;
                }

                Sale p = new Sale()
                {
                    CarId = int.Parse(sale.Element("carId").Value),
                    CustomerId = int.Parse(sale.Element("customerId").Value),
                    Discount = decimal.Parse(sale.Element("discount").Value),
                };

                context.Sales.Add(p);
                cnt++;
            }

            context.SaveChanges();

            return $"Successfully imported {cnt}";
        }

        //14. Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new ExportCarsWithDistanceDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                })
                .ToArray();

            return Serializer<ExportCarsWithDistanceDto[]>(cars, "cars");
        }

        //15. Export Cars From Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new ExportCarsFromMakeBMWDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray();

            return Serializer<ExportCarsFromMakeBMWDto[]>(cars, "cars");
        }

        //16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new ExportLocalSuppliersDto()
                {
                    Name = s.Name,
                    Id = s.Id,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            return Serializer<ExportLocalSuppliersDto[]>(suppliers, "suppliers");
        }
    }
}