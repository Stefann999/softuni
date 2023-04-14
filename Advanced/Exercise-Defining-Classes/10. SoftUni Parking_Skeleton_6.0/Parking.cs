using System.Collections.Generic;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            cars = new();
            this.capacity = capacity;
        }

        public int Count { get { return this.cars.Count; } }


        public string AddCar(Car car)
        {

            if (cars.ContainsKey(car.RegistrationNumber))
            {
                string message = "Car with that registration number, already exists!";
                return message;
            }

            else if (cars.Count == capacity)
            {
                string message = "Parking is full!";
                return message;
            }

            else
            {
                cars.Add(car.RegistrationNumber, car);
                string message = $"Successfully added new car {car.Make} {car.RegistrationNumber}";
                return message;
            }
        }


        public string RemoveCar(string RegistrationNumber)
        {

            if (!cars.ContainsKey(RegistrationNumber))
            {
                string message = "Car with that registration number, doesn't exist!";
                return message;
            }

            else
            {
                cars.Remove(RegistrationNumber);
                string message = $"Successfully removed {RegistrationNumber}";
                return message;
            }
        }


        public Car GetCar(string RegistrationNumber)
        {
            Car car = cars[RegistrationNumber];
            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            for (int i = 0; i < RegistrationNumbers.Count; i++)
            {
                if (cars.ContainsKey(RegistrationNumbers[i]))
                {
                    cars.Remove(RegistrationNumbers[i]);
                }
            }
        }

    }
}
