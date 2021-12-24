using System;
using BLL.Services.Impl;
using CCL.Security.Identity;
using DAL.Entities;

namespace BLL.DTO
{
    public class CaseDTO
    {
        public CaseDTO(int id, CaseType caseType)
        {
            ID = id;
            CaseType = caseType;
        }

        public int ID { get; set; }
        public CaseType CaseType { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public PersonalData PersonalData { get; set; }
        public Location Location { get; set; }
        public DateTime Date { get; set; }
        public State State { get; set; }
    }
}