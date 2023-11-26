using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Common;
using Trucks.Data.Models;

namespace Trucks.DataProcessor.ImportDto;

[XmlType("Client")]
public class ImportClientDto
{
    [XmlElement("Name")]
    [Required]
    [MinLength(GlobalConstants.ClientNameMinLength)]
    [MaxLength(GlobalConstants.ClientNameMaxLength)]
    public string Name { get; set; }

    [XmlElement("Nationality")]
    [Required]
    [MinLength(GlobalConstants.ClientNationalityMinLength)]
    [MaxLength(GlobalConstants.ClientNationalityMaxLength)]
    public string Nationality { get; set; }

    [XmlElement("Type")]
    [Required]
    public string Type { get; set; }

    [XmlArray("Trucks")]
    public int[] Trucks { get; set; }
}
