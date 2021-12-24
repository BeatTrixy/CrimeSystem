using System.Collections.Generic;

namespace CCL.Security.Identity
{
    public abstract class Person
    {
        public Person(int userId, LoginDetails details, PersonalData data, IEnumerable<int> casesId, string userType)
        {
            UserId = userId;
            LoginDetails = details;
            PersonalData = data;
            CasesID = casesId;
            UserType = userType;
        }

        public int UserId { get; }
        public LoginDetails LoginDetails { get; }
        public PersonalData PersonalData { get; }
        public IEnumerable<int> CasesID { get; }
        protected string UserType { get; }
        
        public void CreatePerson(out string register, out string login, out string tutorial)
        {
            register = Register();
            login = Login();
            tutorial = WatchTutorial();
        }

        public abstract string Register();
        public abstract string Login();
        public abstract string WatchTutorial();
    }
}