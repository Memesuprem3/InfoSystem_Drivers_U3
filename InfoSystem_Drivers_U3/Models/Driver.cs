using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InfoSystem_Drivers_U3.Models
{
    public class Driver
    {
        [Key]
        public int DriverID { get; set; }
        [Column(TypeName = "nvarChar(50)")]
        [Required(ErrorMessage = "Driver Name Is A Requierment")]
        public string DriverName { get; set; }
        [Column(TypeName = "nvarChar(7)")]
        [Required(ErrorMessage = "Registration Nummer Is Required")]
        public string CarReg { get; set; }
        public DateTime NoteDate { get; set; } = DateTime.Now;
        [Column(TypeName = "nvarChar(150)")]
        public string? NoteDescription { get; set; }
        [Column(TypeName = "nvarChar(50)")]
        [Required(ErrorMessage = "Responsible Employee Is Required")]
        public string ResponsibleEmployee { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Range Cant Be A Negative")]
        public decimal BeloppUt { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Range Cant Be A Negative")]
        public decimal BeloppIn { get; set; }
        public decimal TotalBeloppUt { get; set; }
        public decimal TotalBeloppIn { get; set; }

        public ICollection<Event>? Events { get; set; }
    }
}
