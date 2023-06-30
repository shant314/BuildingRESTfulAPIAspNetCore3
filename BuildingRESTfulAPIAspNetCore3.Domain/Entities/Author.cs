using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingRESTfulAPIAspNetCore3.Domain.Entities
{
    public class Author
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key, Column(name: nameof(Author.Id), Order = 0)]
        public long Id { get; set; }
       //[Key, Column(name: nameof(Author.Guid), Order = 1)]//
        ////[DatabaseGenerated(DatabaseGeneratedOption.Identity)] //we want to handle it manually in EF.
        public Guid Guid { get; set; }
        [Required]
        [MaxLength(100)]
        public required string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public required string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        [MaxLength(200)]
        public required string MainCategory { get; set; }

        public ICollection<Course> Courses { get; set; }
         = new List<Course>();
    }
}
