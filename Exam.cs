using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    public class Exam
    {
        public string Title { get; set; }
        public ExamType Type { get; set; }
        public List<Question> Questions { get; set; }
        public int numberofstudentsattempted { get; set; }
        public Course Course { get; set; }
        public int ExamDuration { get; set; } // Duration in minutes
        public double ObtainedMarks { get; set; } 

        public Exam(string title, ExamType type, Course course)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));
            }
            if(course == null || !Course.CourseName.Contains(course.CourseName))
            {
                throw new ArgumentNullException(nameof(course), "Course cannot be null and must be assigned to the teacher.");
            }
            Title = title;
            Type = type;
            Course = course;
            Questions = new List<Question>();
        }
        public void AddQuestion(Question question)
        {
            if (question == null)
            {
                throw new ArgumentNullException(nameof(question), "Question cannot be null.");
            }
            else if (Questions.Contains(question))
            {
                throw new InvalidOperationException("Question already exists in the exam.");
            }
            Questions.Add(question);
        }
        public void ToString()
        {
            Console.WriteLine($"Exam Title: {Title}, Type: {Type}, Number of Questions: {Questions.Count}, Course: {Course.CourseName}");
            Console.WriteLine("Questions:");
            foreach (var question in Questions)
            {
                Console.WriteLine($"Question: {question.Text}, Type: {question.Type}, Marks: {question.Marks}");
                if (question.Options != null && question.Options.Count > 0 && question.Type == ExamType.MultipleChoice)
                {
                    Console.WriteLine("Options:");
                    foreach (var option in question.Options)
                    {
                        Console.WriteLine($"- {option}");
                    }
                }
                if(question.Type == ExamType.ShortAnswer)
                {
                    Console.WriteLine("This is a short answer question.");
                    string userAnswer = Console.ReadLine();
                }
                if (question.Type == ExamType.TrueFalse)
                {
                    Console.WriteLine("This is a true/false question.");
                    string userAnswer = Console.ReadLine();
                }
                Console.WriteLine($"Correct Answer: {question.CorrectAnswer}");
            }
        }
        public double EvaluateExam(Student student, Dictionary<Question, string> studentAnswers, out  double obtainedMarks)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student cannot be null.");
            }
            if (studentAnswers == null || studentAnswers.Count == 0)
            {
                throw new ArgumentException("Student answers cannot be null or empty.", nameof(studentAnswers));
            }
            double totalMarks = 0;
            obtainedMarks = 0;
            foreach (var question in Questions)
            {
                totalMarks += question.Marks;
                if (studentAnswers.TryGetValue(question, out string answer))
                {
                    if (answer.Equals(question.CorrectAnswer))
                    {
                        obtainedMarks += question.Marks;
                    }
                }
            }
            Console.WriteLine($"Student {student.Name} scored {obtainedMarks}/{totalMarks} in the exam {Title}.");
            return obtainedMarks;
            this.ObtainedMarks = obtainedMarks;
        }
        

    }
}
