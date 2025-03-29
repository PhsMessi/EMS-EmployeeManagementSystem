using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models.Api
{
    public class AddEmployee
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string EmployeeName { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }

        [Required]
        public string Birthday { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
