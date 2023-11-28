using Trucks.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto;

[XmlType("Despatcher")]
public class ImportDespatcherDto
{
    [XmlElement("Name")]
    [Required]
    [MinLength(GlobalConstants.ClientNameMinLength)]
    [MaxLength(GlobalConstants.ClientNameMaxLength)]
    public string Name { get; set; } = null!;

    [XmlElement("Position")]
    [Required]
    public string Position { get; set; } = null!;

    [XmlArray("Trucks")]
    public TrucksDto[] Trucks { get; set; }
}

[XmlType("Truck")]
public class TrucksDto
{
    [XmlElement("RegistrationNumber")]
    [RegularExpression(GlobalConstants.TruckRegistrationNumberRegex)]
    public string RegistrationNumber { get; set; } = null!;

    [XmlElement("VinNumber")]
    [Required]
    [StringLength(17)]
    public string VinNumber { get; set; }

    [XmlElement("TankCapacity")]
    [Range(GlobalConstants.TruckTankCapacityMinRange, GlobalConstants.TruckTankCapacityMaxRange)]
    public int TankCapacity { get; set; }

    [XmlElement("CargoCapacity")]
    [Required]
    [Range(GlobalConstants.TruckCargoCapacityMinRange, GlobalConstants.TruckCargoCapacityMaxRange)]
    public int CargoCapacity { get; set; }

    [XmlElement("CategoryType")]
    [Required]
    [Range(GlobalConstants.TruckCategoryTypeMinRange, GlobalConstants.TruckCategoryTypeMaxRange)]
    public int CategoryType { get; set; }

    [XmlElement("MakeType")]
    [Required]
    [Range(GlobalConstants.TruckMakeTypeMinRange, GlobalConstants.TruckMakeTypeMaxRange)]
    public int MakeType { get; set; }
}