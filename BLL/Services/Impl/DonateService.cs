using BLL.Services.Interfaces;

namespace BLL.Services.Impl
{
    public class DonateService : IDonateService
    {
        public int GiveADonate(int value)
        {
            return value / 100;
        }
    }
}