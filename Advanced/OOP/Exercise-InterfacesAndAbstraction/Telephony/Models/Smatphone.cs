namespace Telephony.Models
{
    public class Smatphone : ISmartphonable
    {
        public string PhoneNumber { get; set; }
        public string URL { get; set; }

        public string Browsing(string url)
        {
            for (int i = 0; i < url.Length; i++)
            {
                if (char.IsDigit(url[i]))
                {
                    return "Invalid URL!";
                }
            }
            return $"Browsing: {url}!";
        }

        public string Calling(string phoneNumber)
        {
            return $"Calling... {phoneNumber}";
        }
    }
}
