using Footballers.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto;

[XmlType("Coach")]
public class ImportCoachDto
{
    [XmlElement("Name")]
    [Required]
    [MinLength(GlobalConstants.CoachNameMinLength)]
    [MaxLength(GlobalConstants.CoachNameMaxLength)]
    public string Name { get; set; } = null!;

    [XmlElement("Nationality")]
    [Required]
    public string Nationality { get; set; } = null!;

    [XmlArray("Footballers")]
    public FootballersDto[] Footballers { get; set; }
}

[XmlType("Footballer")]
public class FootballersDto
{
    [XmlElement("Name")]
    [Required]
    [MinLength(GlobalConstants.FootballerNameMinLength)]
    [MaxLength(GlobalConstants.FootballerNameMaxLength)]
    public string Name { get; set; } = null!;

    [XmlElement("ContractStartDate")]
    [Required]
    public string ContractStartDate { get; set; }

    [XmlElement("ContractEndDate")]
    [Required]
    public string ContractEndDate { get; set; }

    [XmlElement("BestSkillTypeacity")]
    [Required]
    [Range(0, 4)]
    public int BestSkillType { get; set; }

    [XmlElement("PositionType")]
    [Required]
    [Range(0, 4)]
    public int PositionType { get; set; }
}