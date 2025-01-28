using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    internal class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }

        public ICollection<Resource> Resources {get;} = new List<Resource>();
        public ICollection<StudentCourse> StudentCourses { get;} = new List<StudentCourse>();
        public ICollection<Homework> Homeworks {get;} = new List<Homework>();
    }
}
