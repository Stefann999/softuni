using System.ComponentModel.DataAnnotations;
using Footballers.Common;
using Newtonsoft.Json;

namespace Footballers.DataProcessor.ImportDto;

public class ImportTeamDto
{
    [JsonProperty("Name")]
    [Required]
    [RegularExpression(GlobalConstants.TeamNameRegex)]
    public string Name { get; set; }

    [JsonProperty("Nationality")]
    [Required]
    [MinLength(GlobalConstants.TeamNationalityMinLength)]
    [MaxLength(GlobalConstants.TeamNationalityMaxLength)]
    public string Nationality { get; set; }

    [JsonProperty("Trophies")]
    [Required]
    public int Trophies { get; set; }

    [JsonProperty("Footballers")]
    public int[] FootballersIds { get; set; }
}