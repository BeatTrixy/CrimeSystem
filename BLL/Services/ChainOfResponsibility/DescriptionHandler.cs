using BLL.DTO;

namespace BLL.Services.ChainOfResponsibility
{
    public class DescriptionHandler : CaseHandler
    {
        public override void Handle(ref CaseDTO caseDto)
        {
            caseDto.Description = "New description";
            NextHandler?.Handle(ref caseDto);
        }
    }
}