using System.ComponentModel.DataAnnotations;

namespace InfoSystem_Drivers_U3.Models
{
        public class Event
        {
            [Key]
            public int EventID { get; set; }
            [Required]
            public DateTime NoteDate { get; set; }
            [Required]
            public string NoteDescription { get; set; }
            [Required]
            public decimal BeloppIn { get; set; }
            [Required]
            public decimal BeloppUt { get; set; }

            [Required]
            public int DriverID { get; set; }
            public Driver? Driver { get; set; }
        }
    
}
