using System;
using BLL.DTO;
using BLL.Services.HelperClasses;
using BLL.Services.Interfaces;

namespace BLL.Services.Impl
{
    public enum CaseType
    {
        Murder,
        Robbery,
        Shoplifting,
        Unknown
    }

    public class CaseCreatorService : Component, ICaseCreatorService
    {
        private static CaseCreatorService _instance;

        private CaseCreatorService() { }

        public static CaseCreatorService Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new CaseCreatorService();
                }

                return _instance;
            }
        }

        public CaseDTO FactoryMethod(CaseType type)
        {
            var random = new Random();
            var randomNumber = random.Next(0, 1000);
            switch (type)
            {
                case CaseType.Murder:
                    return new CaseDTO(randomNumber, CaseType.Murder);
                case CaseType.Robbery:
                    return new CaseDTO(randomNumber, CaseType.Robbery);
                case CaseType.Shoplifting:
                    return new CaseDTO(randomNumber, CaseType.Shoplifting);
            }
            
            // if case type is unknown - throw exception
            throw new NotImplementedException();
        }
    }
}