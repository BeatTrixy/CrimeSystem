using BLL.DTO;
using BLL.Services.ChainOfResponsibility;
using Xunit;

namespace BLL.Tests
{
    public class ChainOfResponsibilityTest
    {
        [Fact]
        public void CoR_StartChain_CollectionsAreNotEmpty()
        {
            var id = new IdHandler();
            var descriptionHandler = new DescriptionHandler();
            var caseTypeHandler = new CaseTypeHandler();

            var caseDto = new CaseDTO(0, 0);
            id.NextHandler = descriptionHandler;
            descriptionHandler.NextHandler = caseTypeHandler;
            
            id.Handle(ref caseDto);
            
            Assert.True(caseDto.ID >= 0 || caseDto.ID <= 9999);
            Assert.NotEmpty(caseDto.Description);
            Assert.True(caseDto.CaseType >= 0);
        }
        
        [Fact]
        public void CoR_StartChain_SomeCollectionsAreEmpty()
        {
            var id = new IdHandler();
            var caseTypeHandler = new CaseTypeHandler();

            var caseDto = new CaseDTO(0, 0);
            id.NextHandler = caseTypeHandler;
            
            id.Handle(ref caseDto);
            
            Assert.True(caseDto.ID >= 0 || caseDto.ID <= 9999);
            Assert.True(caseDto.CaseType >= 0);
            
            Assert.Null(caseDto.Description);

        }
    }
}