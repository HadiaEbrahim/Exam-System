using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    public record Courseinfo(string CourseName, string Category, Teacher CourseTeacher);
    public record Examsinf(string ExamName, int QuestionsCount);
    public record CourseExamsnum(string CourseName, int NumberOfExams);
    public record CourseWithThereTeacher(string CourseName, string Category, Teacher CourseTeacher);
    public class LINQ
    {
        List<Course> courses;
        List<Exam> exams;
        List<Question> questions;
        List<Student> students;
        public LINQ(List<Course> courses, List<Exam> exams, List<Question> questions, List<Student> students)
        {
            
            this.courses = courses;
            this.exams = exams;
            this.questions = questions;
            this.students = students;
        }
        public List<Courseinfo> ReturnAllCoursesByTeacherAndCategory()
        {
            var  res= this.courses
                .Select(c => new Courseinfo(CourseName:c.CourseName, Category:c.Category, CourseTeacher:c.CourseTeacher))
                .ToList();
            return res;
        }
        public List<Examsinf> ReturnAllExams()
        {
            var res = this.exams
                .Select(e => new Examsinf(ExamName:e.Title, QuestionsCount:e.Questions!=null ? e.Questions.Count : 0))
                .ToList();
            return res;
        }
        public List<Question> ReturnAllQuestionsByExamID(int examId)
        {
            var res = this.questions
                .Where(q => q.ExamId == examId)
                .ToList();
            return res;
        }
        public List<Question> ReturnAllQuestionsByExamTitle(string examTitle)
        {
            var res = this.questions
                .Where(q => this.exams.Any(e => e.Title == examTitle && e.Questions.Contains(q)))
                .ToList();
            return res;
        }

        //Return all student names and the course name they are enrolled in for a
        //specific course
        public List<(string StudentName, List<string> CourseNames)> ReturnStudentsAndCourses()
        {
            var res = this.students
                .Select(s => (StudentName: s.Name, CourseNames: s.Courses.Select(c => c.CourseName).ToList()))
                .ToList();
            return res;
        }

        public List<CourseExamsnum> ReturnNumberOfExamsPerCourse()
        {
            var res = this.courses
                .Select(c => new CourseExamsnum(CourseName: c.CourseName, NumberOfExams: c.Exams.Count))
                .ToList();
            return res;
        }
        public List<CourseWithThereTeacher> ReturnCoursesWithTheirTeachers()
        {
            var res = this.courses
                .Select(c => new CourseWithThereTeacher(CourseName: c.CourseName, Category: c.Category, CourseTeacher: c.CourseTeacher!=null ? c.CourseTeacher : null))
                .ToList();
            return res;
        }
        
        public double ReturnAverageExamDuration()
        {
            var averageDuration = this.exams.Average(e => e.ExamDuration);
            return averageDuration;
        }

        public double ReturnAverageStudentScoreInExam(string examTitle)
        {
            var exam = this.exams.FirstOrDefault(e => e.Title == examTitle);
            if (exam == null || exam.Questions.Count == 0)
            {
                return 0; // No such exam or no questions in the exam
            }
            var totalScores = this.students
                .SelectMany(s => s.ExamTaken.Where(et => et.Title == examTitle))
                .Sum(et => et.ObtainedMarks);
            var studentCount = this.students.Count(s => s.ExamTaken.Any(et => et.Title == examTitle));
            return studentCount > 0 ? totalScores / studentCount : 0;
        }
        //Show student name, student answer, correct answer, and score per quiz
        public List<(string StudentName, string StudentAnswer, string CorrectAnswer, double Score)> ReturnStudentAnswersAndScores(string examTitle)
        {
           var exam = this.exams.FirstOrDefault(e => e.Title == examTitle);
            if (exam == null)
            {
                return new List<(string StudentName, string StudentAnswer, string CorrectAnswer, double Score)>();
            }
            var result = this.students
                .SelectMany(s => s.ExamTaken.Where(et => et.Title == examTitle)
                    .SelectMany(et => et.Questions.Select(q => (StudentName: s.Name, StudentAnswer: "N/A", CorrectAnswer: q.CorrectAnswer, Score: q.Marks))))
                .ToList();
            return result;
        }
        //Get courses with more than 5 students
        public List<Course> ReturnCoursesWithMoreThanFiveStudents()
        {
            var res = this.courses
                .Where(c => c.NumberOfEnrolledStudents > 5)
                .ToList();
            return res;
        }
        //Get courses that have quizzes
        public List<Course> ReturnCoursesWithExams()
        {
            var res = this.courses
                .Where(c => c.NumberOfExams > 0)
                .ToList();
            return res;
        }
        //Add Admin details
        public void AddAdmin(string name, string email, string password)
        {
            Admin admin = new Admin(name, email, password);
            Console.WriteLine($"Admin {name} added successfully.");
        }
        public void ReportStudentPerformance(string studentName)
        {
            var student = this.students.FirstOrDefault(s => s.Name == studentName);
            if (student == null)
            {
                Console.WriteLine($"Student {studentName} not found.");
                return;
            }
            Console.WriteLine($"Performance Report for Student: {student.Name}");
            foreach (var exam in student.ExamTaken)
            {
                Console.WriteLine($"Exam: {exam.Title}, Score: {exam.ObtainedMarks}/{exam.Questions.Sum(q => q.Marks)}");
            }
            foreach (var course in student.Courses)
            {
                Console.WriteLine($"Course: {course.CourseName}, Number of Exams: {course.NumberOfExams}");
            }
        }
    }
}
