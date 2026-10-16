using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    internal class Admin : User
    {
        public Course Course { get; set; }
        public Admin(string name, string email, string password) : base(name, email, password, Role.Admin)
        {
            
        }

        public void CreateCourse(string courseName, int courseCode, Teacher teacher,int duration,int numberoflessons,string category)
        {
            Course = new Course(courseName, courseCode, teacher,duration,numberoflessons,category);
            Console.WriteLine($"Course {courseName} created successfully.");
        }
        public void DisplayCourseDetails()
        {
            if (Course != null)
            {
                Console.WriteLine($"Course Name: {Course.CourseName}");
                Console.WriteLine($"Course Code: {Course.CourseCode}");
                Console.WriteLine($"Teacher: {Course.CourseTeacher}");
                Console.WriteLine($"Duration: {Course.durationInWeeks} hours");
                Console.WriteLine($"Number of Lessons: {Course.Numberoflessons}");
                Console.WriteLine($"Number of Students: {Course.NumberOfEnrolledStudents}");
                Console.WriteLine($"Number of Exams: {Course.NumberOfExams}");
                Console.WriteLine($"Category: {Course.Category}");
                Console.WriteLine($"Enrolled Students: ");
                foreach (var student in Course.EnrolledStudents)
                {
                    Console.WriteLine($"- {student.Name} )");
                }
                Console.WriteLine($"Exams: ");
                foreach (var exam in Course.Exams)
                {
                    Console.WriteLine($"- {exam.Title} ");
                }
            }
            else
            {
                Console.WriteLine("No course created yet.");
            }
        }
        public void DisplayStudentDetails(Student student)
        {
            if (student != null)
            {
                Console.WriteLine($"Student Name: {student.Name}");
                Console.WriteLine($"Email: {student.Email}");
                Console.WriteLine($"Grade: {student.Grade}");
                Console.WriteLine($"Number of Courses: {student.NumberOfCourses}");
                Console.WriteLine($"Number of Exams: {student.NumberOfExams}");
                Console.WriteLine($"Enrolled Courses: ");
                foreach (var course in student.Courses)
                {
                    Console.WriteLine($"- {course.CourseName} ");
                }
                Console.WriteLine($"Exams: ");
                foreach (var exam in student.Exams)
                {
                    Console.WriteLine($"- {exam.Title} ");
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }

        }
        public void DisplayTeacherDetails(Teacher teacher)
        {
            if (teacher != null)
            {
                Console.WriteLine($"Teacher Name: {teacher.Name}");
                Console.WriteLine($"Email: {teacher.Email}");
                Console.WriteLine($"Title: {teacher.Title}");
                Console.WriteLine($"Number of Courses: {teacher.NumberOfCourses}");
                Console.WriteLine($"Number of Exams: {teacher.NumberOfExams}");
                Console.WriteLine($"Courses: ");
                foreach (var course in teacher.Courses)
                {
                    Console.WriteLine($"- {course.CourseName} ");
                }
            }
            else
            {
                Console.WriteLine("Teacher not found.");
            }
        }
    }
}
