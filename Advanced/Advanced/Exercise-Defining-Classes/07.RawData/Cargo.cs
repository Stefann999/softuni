namespace RawData;

    public class Cargo
    {
	private string type;
	private int weight;

        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }

        public int Weight
	{
		get { return weight; }
		set { weight = value; }
	}

	public string Type
	{
		get { return type; }
		set { type = value; }
	}

}
