namespace Telephony.Models
{
    public class Stationaryphone : IStationarable
    {
        public string PhoneNumber { get; set; }

        public string Dialing(string phoneNumber)
        {
            return $"Dialing... {phoneNumber}";
        }
    }
}
