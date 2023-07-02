namespace _04.BorderControl.Models
{
    public interface IBuyer
    {
        public int Food { get; set; }
        public string Name { get; set; }
        public void BuyFood();
    }
}
