using BLL.Services.Interfaces;

namespace BLL.Services.Impl
{
    public class OrderService
    {
        public int Order(ISubscriptionService subscription, int value)
        {
            return subscription.Pay(value);
        }
    }
}