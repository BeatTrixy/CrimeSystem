using BLL.DTO;
using BLL.Services.Impl;

namespace BLL.Services.Interfaces
{
    public interface ICaseCreatorService
    {
        CaseDTO FactoryMethod(CaseType type);
    }
}