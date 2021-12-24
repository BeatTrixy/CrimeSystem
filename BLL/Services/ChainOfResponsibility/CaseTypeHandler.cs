using System;
using BLL.DTO;
using BLL.Services.Impl;

namespace BLL.Services.ChainOfResponsibility
{
    public class CaseTypeHandler : CaseHandler
    {
        public override void Handle(ref CaseDTO caseDto)
        {
            caseDto.CaseType = (CaseType) new Random().Next(0, 3);
            NextHandler?.Handle(ref caseDto);
        }
    }
}