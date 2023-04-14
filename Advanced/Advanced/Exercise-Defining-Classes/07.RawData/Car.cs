namespace RawData
{
    public class Car
    {

		private string model;
		private Engine engine;
		private Cargo cargo;
		private Tires[] tires;

            public Car(
          string model,
          int speed,
          int power,
          int weight,
          string type,
          double tire1pressure,
          int tire1age,
          double tire2pressure,
          int tire2age,
          double tire3pressure,
          int tire3age,
          double tire4pressure,
          int tire4age)
        {

            Model = model;
            Engine = new(speed, power);
            Cargo = new(weight, type);
            Tires = new Tires[4];
            Tires[0] = new(tire1age, tire1pressure);
            Tires[1] = new(tire2age, tire2pressure);
            Tires[2] = new(tire3age, tire3pressure);
            Tires[3] = new(tire4age, tire4pressure);
        }

        public string Model
		{
			get { return model; }
			set { model = value; }
		}
		public Engine Engine
		{
			get { return engine; }
			set { engine = value; }
		}

		public Cargo Cargo
		{
			get { return cargo; }
			set { cargo = value; }
		}


		public Tires[] Tires
		{
			get { return tires; }
			set { tires = value; }
		}
	}
}
