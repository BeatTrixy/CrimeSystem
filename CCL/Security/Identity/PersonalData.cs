using System;

namespace CCL.Security.Identity
{
    public class PersonalData
    {
        public PersonalData(string name, string surname, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
        }

        public string Name { get; }
        public string Surname { get; }
        public DateTime Birthday { get; }
    }
}