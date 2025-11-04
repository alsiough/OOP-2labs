namespace Domain
{
    public class Teacher : Person, IPersonActions
    {
        public string Department { get; private set; }
        public override string TypeName => "Teacher";
        public override string UniqueId => string.Empty;

        public Teacher(string firstName, string lastName, string department)
            : base(firstName, lastName)
        {
            Department = department ?? string.Empty;
        }

        public void Teach()
        {
            // placeholder for state change
        }

        void IPersonActions.PerformSpecificAction() => Teach();

        public override string ToString()
        {
            return $"{TypeName} {FirstName} {LastName} Dept:{Department}";
        }
    }
}
