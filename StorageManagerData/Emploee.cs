
using System.ComponentModel.DataAnnotations;

namespace StorageManagerData
{
    public class Emploee: IPerson
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public DateTime Hiredate { get; set; }
        [Required]
        public string Contacts { get; set; }

        public string? Notes { get; set; }

        public string? AlocatedJob { get; set; }    

        public override string ToString()
        {
            return $"{Name} {SecondName}";
        }
    }
}