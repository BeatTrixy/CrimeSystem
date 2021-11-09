using DAL.Entities;
using DAL.Repository.Impl;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace DAL.Tests
{
    public class Tests
    {
        [Fact]
        public void Create_InputCalculatedStatsInstance_CalledAddMethodOfDBSetWithCalculatedStatsInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<CaseContext>()
                .Options;
            var mockContext = new Mock<CaseContext>(opt);
            var mockDbSet = new Mock<DbSet<Case>>();
            mockContext
                .Setup(context => 
                    context.Set<Case>(
                    ))
                .Returns(mockDbSet.Object);
            var repository = new TestCaseRepository(mockContext.Object);
            var expectedCase = new Mock<Case>().Object;

            //Act
            repository.Create(expectedCase);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedCase
                ), Times.Once());
        }
        
        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<CaseContext>()
                .Options;
            var mockContext = new Mock<CaseContext>(opt);
            var mockDbSet = new Mock<DbSet<Case>>();
            mockContext
                .Setup(context =>
                    context.Set<Case>(
                        ))
                .Returns(mockDbSet.Object);

            var repository = new TestCaseRepository(mockContext.Object);

            var expectedCase = new Case { ID = 1};
            mockDbSet.Setup(mock => mock.Find(expectedCase.ID)).Returns(expectedCase);

            //Act
            repository.Delete(expectedCase.ID);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedCase.ID
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedCase
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<CaseContext>()
                .Options;
            var mockContext = new Mock<CaseContext>(opt);
            var mockDbSet = new Mock<DbSet<Case>>();
            mockContext
                .Setup(context =>
                    context.Set<Case>(
                        ))
                .Returns(mockDbSet.Object);

            var expectedCase = new Case { ID = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedCase.ID))
                    .Returns(expectedCase);
            var repository = new TestCaseRepository(mockContext.Object);

            //Act
            var actualCase = repository.Get(expectedCase.ID);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedCase.ID
                    ), Times.Once());
            Assert.Equal(expectedCase, actualCase);
        }
    }
}