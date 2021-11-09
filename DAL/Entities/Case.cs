using System;

namespace DAL.Entities
{
    public class Case
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public PersonalData PersonalData { get; set; }
        public Location Location { get; set; }
        public DateTime Date { get; set; }
        public State State { get; set; }
    }

    public enum State
    {
        New,
        Considered,
        Confirmed,
        Refutation,
        Appelate,
        Closed
    }
}