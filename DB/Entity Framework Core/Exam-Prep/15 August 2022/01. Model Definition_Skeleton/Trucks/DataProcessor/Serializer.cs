using System.Globalization;
using Newtonsoft.Json;
using Trucks.Utilities;
using Trucks.DataProcessor.ExportDto;

namespace Trucks.DataProcessor
{
    using Data;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            var products = context.Despatchers
                .Where(d => d.Trucks.Any())
                .Select(d => new ExportDespatcherDto()
                {
                    TrucksCount = d.Trucks.Count,
                    DespatcherName= d.Name,
                    Trucks = d.Trucks
                        .OrderBy(t => t.RegistrationNumber)
                        .Select(t => new ExportTruckDto()
                        {
                            RegistrationNumber = t.RegistrationNumber,
                            Make = t.MakeType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(d => d.Trucks.Length)
                .ThenBy(d => d.DespatcherName)
                .ToArray();

            return new XmlParser().Serialize<ExportDespatcherDto[]>(products, "Despatchers");
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var trucks = context.Clients
                .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                .AsEnumerable()
                .Select(c => new
                {
                    Name = c.Name,
                    Trucks = c.ClientsTrucks
                        .Where(ct => ct.Truck.TankCapacity>= capacity)
                        .Select(ct => new
                        {
                            TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                            VinNumber = ct.Truck.VinNumber,
                            TankCapacity = ct.Truck.TankCapacity,
                            CargoCapacity = ct.Truck.CargoCapacity,
                            CategoryType = ct.Truck.CategoryType.ToString(),
                            MakeType = ct.Truck.MakeType.ToString()
                        })
                        .OrderBy(t => t.MakeType)
                        .ThenByDescending(t => t.CargoCapacity)
                        .ToArray()
                })
                .OrderByDescending(c => c.Trucks.Length)
                .ThenBy(c => c.Name)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(trucks);
        }
    }
}
