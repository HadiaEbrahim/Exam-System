using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
     public class QuestionResult
    {
        public Question Question { get; set; }
        public string StudentAnswer { get; set; }
        public double ObtainedMarks { get; set; }
        public string CorrectAnswer { get; set; }
        public ExamType Type { get; set; }
       

        public QuestionResult(Question question, string studentAnswer)
        {
            if (question == null)
            {
                throw new ArgumentNullException(nameof(question), "Question cannot be null.");
            }
            if (string.IsNullOrWhiteSpace(studentAnswer))
            {
                throw new ArgumentException("Student answer cannot be null or empty.", nameof(studentAnswer));
            }
            Question = question;
            StudentAnswer = studentAnswer;
            CorrectAnswer = question.CorrectAnswer;
            Type = question.Type;
            // Calculate obtained marks based on the student's answer
            ObtainedMarks = CalculateObtainedMarks();
        }
        public double CalculateObtainedMarks()
        {
            if (StudentAnswer == CorrectAnswer)
            {
                return Question.Marks;
            }
            else
            {
                return 0;
            }
        }
    }
}
