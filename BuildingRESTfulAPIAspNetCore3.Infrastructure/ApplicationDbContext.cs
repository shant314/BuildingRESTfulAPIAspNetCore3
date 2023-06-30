using BuildingRESTfulAPIAspNetCore3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRESTfulAPIAspNetCore3.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Author { get; set; }
        public DbSet<Course> Course { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //You can configure multiple properties to be the key of an entity - this is known as a composite key.
            modelBuilder.Entity<Author>()
                .HasKey(key => new { key.Id });
            modelBuilder.Entity<Author>()
                .HasAlternateKey(key => new { key.Guid });
            modelBuilder.Entity<Author>()
                .Property(c => c.Guid).ValueGeneratedNever();
            modelBuilder.Entity<Author>()
                .HasMany(c => c.Courses);


            modelBuilder.Entity<Course>()
                .HasKey(key => new { key.Id });
            modelBuilder.Entity<Course>()
                .HasAlternateKey(key => new { key.Guid });
            modelBuilder.Entity<Course>()
                .Property(c => c.Guid).ValueGeneratedNever();
            modelBuilder.Entity<Course>()
                .HasOne(a => a.Author)
                .WithMany(c => c.Courses)
                .HasForeignKey(fk => fk.AuthorId)
                .HasPrincipalKey(c => c.Id);

            // seed the database with dummy data
            modelBuilder.Entity<Author>()
               .HasData(
                new Author()
                {
                    Id = 1,
                    Guid = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    FirstName = "Berry",
                    LastName = "Griffin Beak Eldritch",
                    BirthDate = new DateTime(1650, 7, 23),
                    MainCategory = "Ships"
                },
                new Author()
                {
                    Id = 2,
                    Guid = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    FirstName = "Nancy",
                    LastName = "Swashbuckler Rye",
                    BirthDate = new DateTime(1668, 5, 21),
                    MainCategory = "Rum"
                },
                new Author()
                {
                    Id = 3,
                    Guid = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    FirstName = "Eli",
                    LastName = "Ivory Bones Sweet",
                    BirthDate = new DateTime(1701, 12, 16),
                    MainCategory = "Singing"
                },
                new Author()
                {
                    Id = 4,
                    Guid = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    FirstName = "Arnold",
                    LastName = "The Unseen Stafford",
                    BirthDate = new DateTime(1702, 3, 6),
                    MainCategory = "Singing"
                },
                new Author()
                {
                    Id = 5,
                    Guid = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    FirstName = "Seabury",
                    LastName = "Toxic Reyson",
                    BirthDate = new DateTime(1690, 11, 23),
                    MainCategory = "Maps"
                },
                new Author()
                {
                    Id = 6,
                    Guid = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                    FirstName = "Rutherford",
                    LastName = "Fearless Cloven",
                    BirthDate = new DateTime(1723, 4, 5),
                    MainCategory = "General debauchery"
                },
                new Author()
                {
                    Id = 7,
                    Guid = Guid.Parse("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                    FirstName = "Atherton",
                    LastName = "Crow Ridley",
                    BirthDate = new DateTime(1721, 10, 11),
                    MainCategory = "Rum"
                }
                );

            modelBuilder.Entity<Course>().HasData(
               new Course
               {
                   Id = 1,
                   Guid = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                   AuthorId = 1,
                   Title = "Commandeering a Ship Without Getting Caught",
                   Description = "Commandeering a ship in rough waters isn't easy.  Commandeering it without getting caught is even harder.  In this course you'll learn how to sail away and avoid those pesky musketeers."
               },
               new Course
               {
                   Id = 2,
                   Guid = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                   AuthorId = 1,
                   Title = "Overthrowing Mutiny",
                   Description = "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny."
               },
               new Course
               {
                   Id = 3,
                   Guid = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                   AuthorId = 2,
                   Title = "Avoiding Brawls While Drinking as Much Rum as You Desire",
                   Description = "Every good pirate loves rum, but it also has a tendency to get you into trouble.  In this course you'll learn how to avoid that.  This new exclusive edition includes an additional chapter on how to run fast without falling while drunk."
               },
               new Course
               {
                   Id = 4,
                   Guid = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                   AuthorId = 3,
                   Title = "Singalong Pirate Hits",
                   Description = "In this course you'll learn how to sing all-time favourite pirate songs without sounding like you actually know the words or how to hold a note."
               }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}

//https://www.entityframeworktutorial.net/efcore/configure-many-to-many-relationship-in-ef-core.aspx
//https://learn.microsoft.com/en-us/ef/core/modeling/keys?tabs=fluent-api
//add-migration InitialMigration -startupProject BuildingRESTfulAPIAspNetCore3.Web -project BuildingRESTfulAPIAspNetCore3.Infrastructure 