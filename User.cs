using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    internal class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
       
        public string Password { get; set; }
        public int NumberOfCourses { get; set; }
        public int NumberOfExams { get; set; }
        public List<Course> Courses { get; set; }
        public List<Exam> Exams { get; set; }
        public Role Role { get; set; }

        public User(string name, string email, string password, Role role)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                throw new ArgumentException("Email cannot be null or empty or invalid.", nameof(email));
            }
            
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                throw new ArgumentException("Password cannot be null or empty and must be at least 6 characters long.", nameof(password));
            }
            if (!Enum.IsDefined(typeof(Role), role))
            {
                throw new ArgumentException("Invalid role specified.", nameof(role));
            }
            Name = name;
            Email = email;
            
            Password = password;
            NumberOfCourses = 0;
            NumberOfExams = 0;
            Courses = new List<Course>();
            Exams = new List<Exam>();
            Role = role;
        }
        public void Login(string email, string password)
        {
            if (email == Email && password == Password)
            {
                Console.WriteLine("Login successful.");
            }
            else
            {
                Console.WriteLine("Invalid email or password.");
            }

        }
        public void Logout()
        {
            Console.WriteLine("Logout successful.");
        }  
        
    }
}
