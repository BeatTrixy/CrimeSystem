using BLL.DTO;

namespace BLL.Services.ChainOfResponsibility
{
    public abstract class CaseHandler
    {
        public CaseHandler NextHandler { get; set; }
        public abstract void Handle(ref CaseDTO caseDro);
    }
}