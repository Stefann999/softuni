﻿namespace Medicines.Data.Models;

using Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Medicine
{
    public Medicine()
    {
        PatientsMedicines = new HashSet<PatientMedicine>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public Category Category { get; set; }

    [Required]
    public DateTime ProductionDate { get; set; }

    [Required]
    public DateTime ExpiryDate { get; set; }

    [Required]
    [MaxLength(100)]
    public string Producer { get; set; } = null!;

    [ForeignKey(nameof(Pharmacy))]
    public int PharmacyId { get; set; }

    public virtual Pharmacy Pharmacy { get; set; } = null!;

    public virtual ICollection<PatientMedicine> PatientsMedicines { get; set; }
}