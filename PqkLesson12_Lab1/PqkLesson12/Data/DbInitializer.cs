using Lab4_MVC_EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4_MVC_EFCore.Data;

public static class DbInitializer
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = serviceProvider.GetRequiredService<SchoolContext>();
        context.Database.EnsureCreated();

        if (context.Majors.Any()) return;

        var majors = new[]
        {
            new Major { MajorName = "IT" },
            new Major { MajorName = "Economics" },
            new Major { MajorName = "Mathematics" }
        };
        context.Majors.AddRange(majors);
        context.SaveChanges();

        var learners = new[]
        {
            new Learner { FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = new DateTime(2005, 9, 1), MajorID = majors[0].MajorID },
            new Learner { FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = new DateTime(2002, 9, 1), MajorID = majors[1].MajorID },
            new Learner { FirstMidName = "Nam", LastName = "Le", EnrollmentDate = new DateTime(2023, 10, 4), MajorID = majors[2].MajorID }
        };
        context.Learners.AddRange(learners);

        var courses = new[]
        {
            new Course { CourseID = 1050, Title = "Chemistry", Credits = 3 },
            new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
            new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3 }
        };
        context.Courses.AddRange(courses);
        context.SaveChanges();

        context.Enrollments.AddRange(
            new Enrollment { LearnerID = learners[0].LearnerID, CourseID = 1050, Grade = 5.5f },
            new Enrollment { LearnerID = learners[1].LearnerID, CourseID = 4022, Grade = 8.0f });
        context.SaveChanges();
    }
}
