using System.ComponentModel.DataAnnotations;

namespace CrudOperation.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? MiddleName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public List<Gender> GenderList { get; set; }
    }

    public class Gender
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
}
