namespace Telephony.Models
{
    public interface IStationarable
    {
        public string PhoneNumber { get; set; }

        public string Dialing(string phoneNumber);
    }
}
