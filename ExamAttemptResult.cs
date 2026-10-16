using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    public class ExamAttemptResult
    {
        public Exam Exam { get; set; }
        public Student Student { get; set; }
        public List<QuestionResult> QuestionResults { get; set; }
        public double ObtainedMarks { get; set; }
        public double TotalMarks { get; set; }
        public ExamAttemptResult(Exam exam, Student student, List<QuestionResult> questionResults)
        {
            if (exam == null)
            {
                throw new ArgumentNullException(nameof(exam), "Exam cannot be null.");
            }
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student cannot be null.");
            }
            if (questionResults == null || questionResults.Count == 0)
            {
                throw new ArgumentException("Question results cannot be null or empty.", nameof(questionResults));
            }
            Exam = exam;
            Student = student;
            QuestionResults = questionResults;
            TotalMarks = CalculateTotalMarks();
            ObtainedMarks = CalculateObtainedMarks();
        }
        private double CalculateTotalMarks()
        {
            return QuestionResults.Sum(qr => qr.Question.Marks);
        }
        private double CalculateObtainedMarks()
        {
            return QuestionResults.Sum(qr => qr.ObtainedMarks);
        }
    }
}
