using System;
using BLL.DTO;

namespace BLL.Services.ChainOfResponsibility
{
    public class IdHandler : CaseHandler
    {
        public override void Handle(ref CaseDTO caseDto)
        {
            caseDto.ID = new Random().Next(0, 9999);
            NextHandler?.Handle(ref caseDto);
        }
    }
}