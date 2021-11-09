using System;
using DAL.Repository.Impl;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private CaseContext db;
        private CaseRepository _caseRepository;
        private UserRepository _userRepository;
        
        public EfUnitOfWork(DbContextOptions options)
        {
            db = new CaseContext(options);
        }
        
        public CaseRepository CaseRepository => _caseRepository ??= new CaseRepository(db);

        public UserRepository UserRepository => _userRepository ??= new UserRepository(db);

        public void Save()
        {
            db.SaveChanges();
        }

        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                _disposed = true;
            }
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}