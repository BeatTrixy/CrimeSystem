using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using BLL.Services.HelperClasses;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork;

namespace BLL.Services.Impl
{
    public class CaseService : Component, ICaseService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public CaseService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        
        public IEnumerable<CaseDTO> GetCases(int page)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(User))
            {
                throw new MethodAccessException();
            }
            var caseId = user.CasesID.First();
            var statsEntities = _database.CaseRepository
                .Find(z => z.ID == caseId, page, pageSize);
            
            var mapper = new MapperConfiguration(cfg => cfg
                .CreateMap<Case, CaseDTO>()).CreateMapper();
            
            var statsDto = mapper
                .Map<IEnumerable<Case>, List<CaseDTO>>(statsEntities);
            return statsDto;
        }
    }
}