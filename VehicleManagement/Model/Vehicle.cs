using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleManagement.Model
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Vehicle_Name { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [Required]
        public VCategory Category { get; set; }
        public string Vehicle_Complaint { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public double Repair_Cost { get; set; }
    }
}
