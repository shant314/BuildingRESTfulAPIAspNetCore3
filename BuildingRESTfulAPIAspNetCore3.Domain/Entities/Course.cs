using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingRESTfulAPIAspNetCore3.Domain.Entities
{
    public class Course
    {
        //[Key, Column(name: nameof(Course.Id), Order = 1)]//Composite Key (Multi Columns Primary Key)
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        //[Key, Column(name: nameof(Course.Guid), Order = 2)]//Composite Key (Multi Columns Primary Key)
        ////[DatabaseGenerated(DatabaseGeneratedOption.Identity)] //we want to handle it manually in EF.
        public Guid Guid { get; set; }
        [Required]
        [MaxLength(200)]
        public required string Title { get; set; }
        [MaxLength(1500)]
        public string? Description { get; set; }

        //[ForeignKey(nameof(Course.AuthorId))]// state a foreign key 'AuthorId' from the Author table
        public Author? Author { get; set; }
        public long AuthorId { get; set; } // actual column we need to have 
    }
}
/*https://stack247.wordpress.com/2015/06/11/composite-key-multi-columns-primary-key-in-ef-code-first/*/