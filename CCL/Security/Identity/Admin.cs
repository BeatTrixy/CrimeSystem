using System.Collections.Generic;

namespace CCL.Security.Identity
{
    public class Admin : Person
    {
        public Admin(int userId, LoginDetails details, PersonalData data, IEnumerable<int> casesId) : base(userId, details, data, casesId, nameof(Admin))
        {
        }
        
        public override string Register()
        {
            return LoginDetails.Login + LoginDetails.Password + nameof(Admin);
        }

        public override string Login()
        {
            return $"Logged in as {nameof(Admin)}";
        }

        public override string WatchTutorial()
        {
            return $"Watched tutorial for {nameof(Admin)}";
        }
    }
}