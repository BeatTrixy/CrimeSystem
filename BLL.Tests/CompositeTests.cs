using BLL.Services.HelperClasses;
using BLL.Services.Impl;
using Xunit;

namespace BLL.Tests
{
    public class CompositeTests
    {
        [Fact]
        public void Composite_AddComponent_ContainsLink()
        {
            var composite = new Composite();
            composite.Add(CaseCreatorService.Instance);

            Assert.Contains(CaseCreatorService.Instance, composite.Components);
        }
        
        [Fact]
        public void Composite_RemoveComponent_ContainsLink()
        {
            var mockComposite = new Composite();
            var component = CaseCreatorService.Instance;
            mockComposite.Add(component);
            mockComposite.Remove(component);
            Assert.DoesNotContain(component, mockComposite.Components);
        }
        
        [Fact]
        public void Composite_GetComponentByName_ReturnsValue()
        {
            var mockComposite = new Composite();
            var component = CaseCreatorService.Instance;
            mockComposite.Add(component);

            var result = mockComposite.GetComponentByName(component.GetType().ToString());
            
            Assert.NotNull(result);
        }
    }
}