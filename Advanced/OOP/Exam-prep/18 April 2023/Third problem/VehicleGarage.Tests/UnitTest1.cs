using NUnit.Framework;
using System.Collections.Generic;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void VehicleIsinitializedCorrectly()
        {
            Vehicle vehicle = new Vehicle("kola", "bavna", "123");
            string brand = "kola";
            string model = "bavna";
            string number = "123";

            Assert.AreEqual(brand, vehicle.Brand);
            Assert.AreEqual(model, vehicle.Model);
            Assert.AreEqual(number, vehicle.LicensePlateNumber);
        }


        [Test]
        public void GarageIsinitializedCorrectly()
        {
            Garage garage = new Garage(5);

            int expectedCapacity = 5;
            List<Vehicle> vehiclesList = new List<Vehicle>();

            Assert.AreEqual(expectedCapacity, garage.Capacity);
            Assert.AreEqual(vehiclesList, garage.Vehicles);
        }

        [Test]
        public void VehiclesAreAddedProperly()
        {
            Garage garage = new Garage(5);
            Vehicle vehicle = new Vehicle("kola", "bavna", "123");
            string brand = "kola";
            string model = "bavna";
            string number = "123";

            Assert.IsTrue(garage.AddVehicle(vehicle));
        }

        [Test]
        public void ReturnsFalseIfNotAdded()
        {
            Garage garage = new Garage(0);
            Vehicle vehicle = new Vehicle("kola", "bavna", "123");
            string brand = "kola";
            string model = "bavna";
            string number = "123";

            Assert.IsFalse(garage.AddVehicle(vehicle));
        }

        [Test]
        public void VehiclesAreChargedProperly()
        {
            Garage garage = new Garage(0);
            Vehicle vehicle = new Vehicle("kola", "bavna", "123");
            vehicle.BatteryLevel = 0;
            garage.Vehicles.Add(vehicle);

            int expectedCnt = 1;

            Assert.AreEqual(expectedCnt, garage.ChargeVehicles(50));

        }

        [Test]

        public void VehiclesAreDrivenCorectly()
        {
            Garage garage = new Garage(5);
            Vehicle vehicle = new Vehicle("kola", "bavna", "123");
            garage.Vehicles.Add(vehicle);

            garage.DriveVehicle("123", 5, false);

            int actualBattery = vehicle.BatteryLevel;
            int expectedBattery = 95;
            Assert.AreEqual(expectedBattery, actualBattery);
        }

        [Test]
        public void Garage_CheckCapacity()
        {
            Garage garage = new Garage(3);

            Vehicle car = new Vehicle("Peugoet", "208", "CT7006H");
            Vehicle van = new Vehicle("Mercedes-Benz", "Vito", "H7806AH");
            Vehicle truck = new Vehicle("Scania", "Citywide", "P7006XX");
            Vehicle scooter = new Vehicle("Yamaha", "Aerox", "PB6006PA");

            garage.AddVehicle(car);
            garage.AddVehicle(van);
            garage.AddVehicle(truck);

            bool actualResult = garage.AddVehicle(scooter);
            Assert.IsFalse(actualResult);
        }

        [Test]
        public void Garage_AddVehicle_LicensePlateAlreadyExists()
        {
            Garage garage = new Garage(3);

            Vehicle car = new Vehicle("Peugoet", "208", "CT7006H");

            garage.AddVehicle(car);

            bool actualResult = garage.AddVehicle(car);
            Assert.IsFalse(actualResult);
        }
        [Test]
        public void Garage_DriveVehicle_VehicleAlreadyDamaged()
        {
            Garage garage = new Garage(5);

            Vehicle car = new Vehicle("Peugoet", "208", "CT7006H");
            Vehicle van = new Vehicle("Mercedes-Benz", "Vito", "H7806AH");
            Vehicle truck = new Vehicle("Scania", "Citywide", "P7006XX");
            Vehicle scooter = new Vehicle("Yamaha", "Aerox", "PB6006PA");

            garage.AddVehicle(car);
            garage.AddVehicle(van);
            garage.AddVehicle(truck);
            garage.AddVehicle(scooter);

            garage.DriveVehicle("P7006XX", 25, true);
            garage.DriveVehicle("P7006XX", 25, true);

            int actualBatteryLevel = truck.BatteryLevel;

            Assert.AreEqual(75, actualBatteryLevel);
        }

        [Test]
        public void Garage_DriveVehicle_VehicleAlready2()
        {
            Garage garage = new Garage(5);

            Vehicle car = new Vehicle("Peugoet", "208", "CT7006H");
            Vehicle van = new Vehicle("Mercedes-Benz", "Vito", "H7806AH");
            Vehicle truck = new Vehicle("Scania", "Citywide", "P7006XX");
            Vehicle scooter = new Vehicle("Yamaha", "Aerox", "PB6006PA");

            garage.AddVehicle(car);
            garage.AddVehicle(van);
            garage.AddVehicle(truck);
            garage.AddVehicle(scooter);

            garage.DriveVehicle("P7006XX", 101, false);

            int actualBatteryLevel = truck.BatteryLevel;

            Assert.AreEqual(100, actualBatteryLevel);
        }

        [Test]
        public void Garage_DriveVehicle_VehicleAlready3()
        {
            Garage garage = new Garage(5);

            Vehicle car = new Vehicle("Peugoet", "208", "CT7006H");
            Vehicle van = new Vehicle("Mercedes-Benz", "Vito", "H7806AH");
            Vehicle truck = new Vehicle("Scania", "Citywide", "P7006XX");
            Vehicle scooter = new Vehicle("Yamaha", "Aerox", "PB6006PA");

            garage.AddVehicle(car);
            garage.AddVehicle(van);
            garage.AddVehicle(truck);
            garage.AddVehicle(scooter);

            garage.DriveVehicle("P7006XX", 60, false);
            garage.DriveVehicle("P7006XX", 60, false);

            int actualBatteryLevel = truck.BatteryLevel;

            Assert.AreEqual(40, actualBatteryLevel);
        }

        [Test]
        public void Garage_ChargeVihicle()
        {
            Garage garage = new Garage(5);

            Vehicle car = new Vehicle("Peugoet", "208", "CT7006H");
            Vehicle van = new Vehicle("Mercedes-Benz", "Vito", "H7806AH");
            Vehicle truck = new Vehicle("Scania", "Citywide", "P7006XX");
            Vehicle scooter = new Vehicle("Yamaha", "Aerox", "PB6006PA");

            garage.AddVehicle(car);
            garage.AddVehicle(van);
            garage.AddVehicle(truck);
            garage.AddVehicle(scooter);

            garage.DriveVehicle("CT7006H", 51, false);
            garage.DriveVehicle("H7806AH", 51, false);
            garage.DriveVehicle("P7006XX", 51, false);
            garage.DriveVehicle("PB6006PA", 50, false);

            int actualChargedVehicles = garage.ChargeVehicles(49);

            Assert.AreEqual(3, actualChargedVehicles);
        }

        [Test]
        public void Garage_RepairVihicles()
        {
            Garage garage = new Garage(5);

            Vehicle car = new Vehicle("Peugoet", "208", "CT7006H");
            Vehicle van = new Vehicle("Mercedes-Benz", "Vito", "H7806AH");
            Vehicle truck = new Vehicle("Scania", "Citywide", "P7006XX");
            Vehicle scooter = new Vehicle("Yamaha", "Aerox", "PB6006PA");

            garage.AddVehicle(car);
            garage.AddVehicle(van);
            garage.AddVehicle(truck);
            garage.AddVehicle(scooter);

            garage.DriveVehicle("CT7006H", 51, true);
            garage.DriveVehicle("H7806AH", 51, true);
            garage.DriveVehicle("P7006XX", 51, true);
            garage.DriveVehicle("PB6006PA", 50, false);

            string actualResult = garage.RepairVehicles();
            string expectedResult = "Vehicles repaired: 3";

            Assert.AreEqual(expectedResult, actualResult);
            Assert.IsFalse(car.IsDamaged);
            Assert.IsFalse(van.IsDamaged);
            Assert.IsFalse(truck.IsDamaged);
        }
    }
}