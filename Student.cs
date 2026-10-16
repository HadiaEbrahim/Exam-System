using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    internal class Student : User
    {
        public string Grade { get; set; }
        public List<Exam> ExamTaken { get; set; }
        public List<Course> courses { get; set; }
        public Student(string name, string email,  string password,string grade) : base(name, email, password, Role.Student)
        {
            if(string.IsNullOrWhiteSpace(grade))
            {
                throw new ArgumentException("Grade cannot be null or empty.", nameof(grade));
            }
            Grade = grade;
        }
        public void Register(string name, string email, string grade, string password, Role role)
        {

            Console.WriteLine($"User {name} registered successfully with role {role}.");
        }
        public void ToString()
        {
            Console.WriteLine($"Student Name: {Name}, Email: {Email}, Grade: {Grade}, Number of Courses: {NumberOfCourses}, Number of Exams: {NumberOfExams}");
        }
        public void DisplayCourseDetails()
        {
            if (Courses.Count > 0)
            {
               
                foreach (var course in Courses)
                {
                    course.ToString();
                }
            }
            else
            {
                Console.WriteLine($"No courses enrolled by {Name}.");
            }
        }
        public void EnrollInCourse(Course course)
        {
            if (course == null || course.CourseTeacher == null)
            {
                throw new ArgumentNullException(nameof(course), "Course cannot be null and must have a teacher assigned.");
            }
            Courses.Add(course);
            NumberOfCourses++;
            Console.WriteLine(course);
        }
        public void TakeExam(Exam exam)
        {
            if (exam == null || !Courses.Contains(exam.Course))
            {
                throw new ArgumentNullException(nameof(exam), "Exam cannot be null and must belong to a course the student is enrolled in.");
            }

            ExamTaken.Add(exam);
            NumberOfExams++;
            Console.WriteLine($"Student {Name} has taken the exam {exam.Title}, scored {exam.EvaluateExam}.");
        }
        public void displaytakenExams()
        {
            if (ExamTaken.Count > 0)
            {
                Console.WriteLine($"Exams taken by {Name}:");
                foreach (var exam in ExamTaken)
                {
                    Console.WriteLine(exam);
                    Console.WriteLine(exam.EvaluateExam);
                }
            }
            else
            {
                Console.WriteLine($"No exams taken by {Name}.");
            }
        }

    }

}
