using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    public class Teacher: User
    {
        public List<Course> Courses { get; set; } = new List<Course>();
        public string Title { get; set; }
        public Teacher(string name, string email, string title, string password) : base(name, email,  password, Role.Teacher)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));
            }
            Title = title;
        }
        public void Register(string name, string email, string title, string password, Role role)
        {

            Console.WriteLine($"User {name} registered successfully with role {role}.");
        }
        public void ToString()
        {
            Console.WriteLine($"Teacher Name: {Name}, Email: {Email}, Title: {Title}, Number of Courses: {NumberOfCourses}, Number of Exams: {NumberOfExams}");
        }
        public void AssignCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course), "Course cannot be null.");
            }
            Courses.Add(course);
            NumberOfCourses++;
            Console.WriteLine($"Course {course.CourseName} assigned to teacher {Name} successfully.");
        }
        public void DisplayCourseDetails()
        {
            if (Courses.Count > 0)
            {
                Console.WriteLine($"Courses assigned to {Name}:");
                foreach (var course in Courses)
                {
                    course.ToString();
                }
            }
            else
            {
                Console.WriteLine($"No courses assigned to {Name}.");
                foreach (var course in Courses)
                {
                    Console.WriteLine($"Course Name: {course.CourseName}");
                }
            }
        }
        public void RemoveCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course), "Course cannot be null.");
            }
            if (Courses.Contains(course)&& course.NumberOfEnrolledStudents==0)
            {
                course.DeleteCourse();
            }
            else
            {
                Console.WriteLine($"Course {course.CourseName} is not assigned to teacher {Name}.");
            }
        }
        public void CreateExam(string title, ExamType type,  Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course), "Course cannot be null.");
            }
            if (!Courses.Contains(course))
            {
                throw new InvalidOperationException($"Teacher {Name} is not assigned to the course {course.CourseName}.");
            }
            Exam exam = new Exam(title, type,  course);
            course.AddExam(exam);
            NumberOfExams++;
            Console.WriteLine($"Exam {title} created successfully for course {course.CourseName}.");
        }
        public void DisplayExamDetails(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course), "Course cannot be null.");
            }
            if (!Courses.Contains(course))
            {
                throw new InvalidOperationException($"Teacher {Name} is not assigned to the course {course.CourseName}.");
            }
            if (course.Exams.Count > 0)
            {
                Console.WriteLine($"Exams for course {course.CourseName}:");
                foreach (var exam in course.Exams)
                {
                    exam.ToString();
                }
            }
            else
            {
                Console.WriteLine($"No exams created for course {course.CourseName}.");
            }
        }
        }
}

