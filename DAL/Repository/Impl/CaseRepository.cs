using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Impl
{
    public class CaseRepository : BaseRepository<Case>, ICaseRepository
    {
        internal CaseRepository(DbContext context) : base(context)
        {
        }
    }
}