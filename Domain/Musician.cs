namespace Domain
{
    public class Musician : Person, IPersonActions, IPlayable
    {
        public string Instrument { get; private set; }
        public override string TypeName => "Musician";
        public override string UniqueId => string.Empty;

        public Musician(string firstName, string lastName, string instrument)
            : base(firstName, lastName)
        {
            Instrument = instrument ?? "Unknown";
        }

        public void Play()
        {
            // placeholder
        }

        void IPersonActions.PerformSpecificAction() => Play();

        public override string ToString()
        {
            return $"{TypeName} {FirstName} {LastName} Instrument:{Instrument}";
        }
    }
}
