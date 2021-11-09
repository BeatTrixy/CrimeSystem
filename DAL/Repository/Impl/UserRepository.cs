using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Impl
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        internal UserRepository(DbContext context) : base(context)
        {
        }
    }
}