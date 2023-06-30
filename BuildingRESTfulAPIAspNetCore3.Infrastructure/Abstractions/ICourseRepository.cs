using BuildingRESTfulAPIAspNetCore3.Domain.Entities;

namespace BuildingRESTfulAPIAspNetCore3.Infrastructure.Abstractions
{
    public interface ICourseRepository : IBaseRepository
    {
        IEnumerable<Course> GetCourses(Guid authorGuid);
        IEnumerable<Course> GetCourses(long authorId);
        Course? GetCourse(long authorId, Guid courseGuid);
        Course? GetCourse(long authorId, long courseId);
        void AddCourse(long authorId, Course course);
        void UpdateCourse(long authorId, Course course);
        void DeleteCourse(Course course);
    }
}
