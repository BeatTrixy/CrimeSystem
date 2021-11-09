using System;
using DAL.Repository.Impl;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        CaseRepository CaseRepository { get; }
        UserRepository UserRepository { get; }
        void Save();
    }
}