using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface ICaseService
    {
        IEnumerable<CaseDTO> GetCases(int page);
    }
}