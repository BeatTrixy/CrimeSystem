using BLL.Services.HelperClasses;
using BLL.Services.Impl;
using BLL.Services.Interfaces;
using Xunit;

namespace BLL.Tests
{
    public class OrderServiceTests
    {
        [Fact]
        public void Adapter_SubscriptionService_ReturnValue()
        {
            ISubscriptionService subscriptionService = new SubscriptionService();
            
            var orderService = new OrderService();

            var value = 100;
            var result = orderService.Order(subscriptionService, value);
            Assert.Equal(value, result);
        }
        
        [Fact]
        public void Adapter_TipsService_ReturnValue()
        {
            IDonateService donateService = new DonateService();
            DonateToSubscription subscriptionService = new DonateToSubscription(donateService);
            
            var orderService = new OrderService();
            
            var value = 100;
            var result = orderService.Order(subscriptionService, value);
            Assert.NotEqual(value, result);
            Assert.Equal(value / 100, result);
        }
    }
}