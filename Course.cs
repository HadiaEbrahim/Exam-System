using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    internal class Course
    {
        public string CourseName { get; set; }
        public int CourseCode { get; set; }
        public Teacher CourseTeacher { get; set; }
        public List<Student> EnrolledStudents { get; set; }
        public List<Exam> Exams { get; set; }
        public int durationInWeeks { get; set; } 
        public int Numberoflessons { get; set; }
        public string Category { get; set; }
        public int NumberOfEnrolledStudents => EnrolledStudents.Count;
        public int NumberOfExams => Exams.Count;
        public Course(string courseName, int courseCode, Teacher courseTeacher, int DurationInWeeks, int Numberoflessons, string category)
        {
            if (string.IsNullOrWhiteSpace(courseName))
            {
                throw new ArgumentException("Course name cannot be null or empty.", nameof(courseName));
            }
            if (courseCode <= 0)
            {
                throw new ArgumentException("Course code cannot be null or empty.", nameof(courseCode));
            }
            if (DurationInWeeks <= 0)
            {
                throw new ArgumentException("Duration in weeks must be a positive integer.", nameof(DurationInWeeks));
            }
            if (Numberoflessons <= 0)
            {
                throw new ArgumentException("Number of lessons must be a positive integer.", nameof(Numberoflessons));
            }
            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentException("Category cannot be null or empty.", nameof(category));
            }
            CourseName = courseName;
            CourseCode = courseCode;
            CourseTeacher = courseTeacher ?? throw new ArgumentNullException(nameof(courseTeacher), "Course teacher cannot be null.");
            EnrolledStudents = new List<Student>();
        }
        public void EnrollStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student cannot be null.");
            }
            if (!EnrolledStudents.Contains(student))
            {
                EnrolledStudents.Add(student);
            }
        }
        public void AddExam(Exam exam)
        {
            if (exam == null)
            {
                throw new ArgumentNullException(nameof(exam), "Exam cannot be null.");
            }
            if (!Exams.Contains(exam))
            {
                Exams.Add(exam);
            }
        }
        public void AssignTeacher(Teacher teacher)
        {
            if (teacher == null || teacher.Role != Role.Teacher)
            {
                throw new ArgumentNullException(nameof(teacher), "Teacher cannot be null or have an invalid role.");
            }
            CourseTeacher = teacher;
        }
        public void ToString()
        {
            Console.WriteLine($"Course Name: {CourseName}");
            Console.WriteLine($"Course Code: {CourseCode}");
            Console.WriteLine($"Teacher: {CourseTeacher.Name}");
            Console.WriteLine($"Duration: {durationInWeeks} weeks");
            Console.WriteLine($"Number of Lessons: {Numberoflessons}");
            Console.WriteLine($"Number of Students: {NumberOfEnrolledStudents}");
            Console.WriteLine($"Number of Exams: {NumberOfExams}");
            Console.WriteLine($"Category: {Category}");
        }
        public void DeleteCourse()
        {
            CourseTeacher = null;
            EnrolledStudents.Clear();
            Exams.Clear();
            Console.WriteLine($"Course {CourseName} deleted successfully.");
        }

    }
}
