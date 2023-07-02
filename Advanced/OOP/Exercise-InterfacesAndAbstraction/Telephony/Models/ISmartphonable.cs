namespace Telephony.Models
{
    public interface ISmartphonable
    {
        public string PhoneNumber { get; set; }
        public string URL { get; set; }


        public string Calling(string phoneNumber);

        public string Browsing(string url);
    }
}
