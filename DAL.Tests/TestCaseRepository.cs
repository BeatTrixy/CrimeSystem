using DAL.Entities;
using DAL.Repository.Impl;
using Microsoft.EntityFrameworkCore;

namespace DAL.Tests
{
    public class TestCaseRepository : BaseRepository<Case>
    {
        public TestCaseRepository(DbContext context) : base(context)
        {
        }
    }
}