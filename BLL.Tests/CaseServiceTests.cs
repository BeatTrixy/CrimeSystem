using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Services.Impl;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Moq;
using Xunit;

namespace BLL.Tests
{
    public class CaseServiceTests
    {
         [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(
                () => new CaseService(nullUnitOfWork)
            );
        }

        [Fact]
        public void GetCases_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            var userDetails = new LoginDetails("admin", "1111");
            var data = new PersonalData("John", "Smith", new DateTime(1980, 11, 11));
            var user = new Admin(1, userDetails, data, new List<int>(){1,2,3});
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var service = new CaseService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => service.GetCases(0));
        }

        /*[Fact]
        public void GetCases_StatsFromDAL_CorrectMappingToStatsDTO()
        {
            // Arrange
            var userDetails = new LoginDetails("user", "1111");
            var data = new PersonalData("John", "Smith", new DateTime(1980, 11, 11));
            var user = new User(1, userDetails, data, new List<int>(){1,2,3});
            SecurityContext.SetUser(user);
            var service = GetCasesService();

            // Act
            var dto = service.GetCases(0).First();

            // Assert
            Assert.True(
                dto.ID == 1
            );
        }*/

        private ICaseService GetCasesService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedCase = new Case{ 
                ID = 1
            };
            var mockDbSet = new Mock<ICaseRepository>();
            
            mockDbSet
                .Setup(z => 
                    z.Find(
                        It.IsAny<Func<Case, bool>>(), 
                        It.IsAny<int>(), 
                        It.IsAny<int>()))
                .Returns(
                    new List<Case> { expectedCase }
                );
            mockContext
                .Setup(context =>
                    context.CaseRepository)
                .Returns(mockDbSet.Object);

            ICaseService calcStatsService = new CaseService(mockContext.Object);

            return calcStatsService;
        }
    }
}