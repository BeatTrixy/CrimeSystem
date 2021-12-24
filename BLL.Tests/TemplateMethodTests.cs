using System;
using System.Collections.Generic;
using CCL.Security.Identity;
using Xunit;

namespace BLL.Tests
{
    public class TemplateMethodTests
    {
        [Fact]
        public void TemplateMethod_CreateUser_Equals()
        {
            var user = new User(1, new LoginDetails("login", "pass"), new PersonalData("Alex", "Velmart", DateTime.Now), new List<int>());
            user.CreatePerson(out var reg, out var log, out var tutorial);
            Assert.Equal(user.LoginDetails.Login + user.LoginDetails.Password + nameof(User),  reg );
        }
        
        [Fact]
        public void TemplateMethod_CreateAdmin_Equals()
        {
            var user = new Admin(1, new LoginDetails("login", "pass"), new PersonalData("Alex", "Velmart", DateTime.Now), new List<int>());
            user.CreatePerson(out var reg, out var log, out var tutorial);
            Assert.Equal($"Logged in as {nameof(Admin)}",  log );
        }
        
        [Fact]
        public void TemplateMethod_CreateAdmin2_Equals()
        {
            var user = new Admin(1, new LoginDetails("login", "pass"), new PersonalData("Alex", "Velmart", DateTime.Now), new List<int>());
            user.CreatePerson(out var reg, out var log, out var tutorial);
            Assert.Equal($"Watched tutorial for {nameof(Admin)}",  tutorial );
        }
    }
}