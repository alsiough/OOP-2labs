using System;
using System.Text.RegularExpressions;
namespace Domain
{
    public class Student : Person, IPersonActions
    {
        private static Regex studentIdRegex = new Regex(@"^[A-Z]{2}\d{6}$");
        public string StudentId { get; private set; }
        public int Course { get; private set; }

        public override string TypeName => "Student";
        public override string UniqueId => StudentId;

        public Student(string firstName, string lastName, string studentId, int course)
            : base(firstName, lastName)
        {
            if (!studentIdRegex.IsMatch(studentId)) throw new ArgumentException("Invalid studentId (expected format: AA123456)");
            if (course < 1 || course > 12) throw new ArgumentException("Invalid course");
            StudentId = studentId;
            Course = course;
        }

        public void Study()
        {
            if (Course < 12) Course++;
        }

        void IPersonActions.PerformSpecificAction() => Study();

        public override string ToString()
        {
            return $"{TypeName} {FirstName} {LastName} ID:{StudentId} Course:{Course}";
        }
    }
}
