using BuildingRESTfulAPIAspNetCore3.Domain.Entities;
using BuildingRESTfulAPIAspNetCore3.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRESTfulAPIAspNetCore3.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CourseRepository(ApplicationDbContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context)); ;
        }

        public IEnumerable<Course> GetCourses(Guid authorGuid)
        {
            if (authorGuid == Guid.Empty)
                throw new ArgumentNullException(nameof(authorGuid));

            return _dbContext.Course
                .Where(c => c.Guid == authorGuid)
                .OrderBy(c => c.Title)
                .ToList();
        }
        public IEnumerable<Course> GetCourses(long authorId)
        {
            return _dbContext.Course
                        .Where(c => c.AuthorId == authorId)
                        .OrderBy(c => c.Title)
                        .ToList();
        }


        public Course? GetCourse(long authorId, Guid courseGuid)
        {
            if (courseGuid == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseGuid));
            }

            return _dbContext.Course
              .Where(c => c.AuthorId == authorId && c.Guid == courseGuid)
              .SingleOrDefault();
        }
        public Course? GetCourse(long authorId, long courseId)
        {
            return _dbContext.Course
                .Where(c => c.AuthorId == authorId && c.Id == courseId)
                .SingleOrDefault();
        }


        public void AddCourse(long authorId, Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));
            
            // always set the AuthorId to the passed-in authorId
            course.AuthorId = authorId;
            _dbContext.Course.Add(course);
        }

        public void UpdateCourse(long authorId, Course course)
        {
            // no code in this implementation
            // log, permission ...
        }

        public void DeleteCourse(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            _dbContext.Remove(course);
        }

        public bool Save()
        {
            return (_dbContext.SaveChanges() >= 0);
        }
    }
}
