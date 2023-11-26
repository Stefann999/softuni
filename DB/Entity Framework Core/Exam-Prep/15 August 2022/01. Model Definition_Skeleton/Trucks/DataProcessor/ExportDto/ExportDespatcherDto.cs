using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto;

[XmlType("Despatcher")]
public class ExportDespatcherDto
{

    [XmlElement("DespatcherName")]
    public string DespatcherName { get; set; } = null!;

    [XmlAttribute("TrucksCount")]
    public int TrucksCount { get; set; }


    [XmlArray("Trucks")]
    public ExportTruckDto[] Trucks { get; set; }
}

[XmlType("Truck")]
public class ExportTruckDto
{
    [XmlElement("RegistrationNumber")]
    public string RegistrationNumber { get; set; }

    [XmlElement("Make")]
    public string Make { get; set; }
}