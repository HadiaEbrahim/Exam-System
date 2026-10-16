using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    public class Question
    {
       public string Text { get; set; }
       public ExamType Type { get; set; }
       public List<string> Options { get; set; }
       public string CorrectAnswer { get; set; }
       public double Marks { get; set; }
       public double totalMarks { get; set; }
       public int ExamId { get; set; }

        public Question(string text, ExamType type, List<string> options, string correctAnswer, double marks)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Question text cannot be null or empty.", nameof(text));
            }
            if (type == ExamType.MultipleChoice && (options == null || options.Count == 0))
            {
                throw new ArgumentException("Options cannot be null or empty for multiple choice questions.", nameof(options));
            }
            else if (type == ExamType.ShortAnswer && (options != null && options.Count > 0))
            {
                throw new ArgumentException("Options should be null or empty for short answer questions.", nameof(options));
            }
           
            if (string.IsNullOrWhiteSpace(correctAnswer))
            {
                throw new ArgumentException("Correct answer cannot be null or empty.", nameof(correctAnswer));
            }
            if(marks < 0)
            {
                throw new ArgumentException("Marks cannot be negative.", nameof(marks));
            }
            Text = text;
            Type = type;
            Options = options;
            CorrectAnswer = correctAnswer;
            Marks = marks;
        }

    }
}
