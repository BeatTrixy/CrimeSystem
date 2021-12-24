using System;
using BLL.Services.Impl;
using BLL.Services.Interfaces;
using Xunit;

namespace BLL.Tests
{
    public class CaseCreatorServiceTests
    {
        [Fact]
        public void Singleton_GetInstance_EqualResult()
        {
            var instance1 = CaseCreatorService.Instance;
            var instance2 = CaseCreatorService.Instance;
            
            // Assert
            Assert.Equal(instance1, instance2);
        }
        
        [Fact]
        public void Singleton_GetInstance_NotNullResult()
        {
            //Arrange
            ICaseCreatorService caseCreatorService = CaseCreatorService.Instance;

            // Assert
            Assert.NotNull(caseCreatorService);
        }
        
        [Fact]
        public void FactoryMethod_UseFactoryMethod_TypeOfClass()
        {
            //Arrange
            ICaseCreatorService caseCreatorService = CaseCreatorService.Instance;
            
            // Act
            var type = CaseType.Murder;
            var result = caseCreatorService.FactoryMethod(type);
            // Assert
            Assert.Equal(CaseType.Murder, result.CaseType);
        }
        
        [Fact]
        public void FactoryMethod_UseFactoryMethodWithBadParameter_ThrowException()
        {
            //Arrange
            ICaseCreatorService caseCreatorService = CaseCreatorService.Instance;
            
            // Act
            var type = CaseType.Unknown;
            
            // Assert
            Assert.Throws<NotImplementedException>(() => caseCreatorService.FactoryMethod(type));
        }
    }
}