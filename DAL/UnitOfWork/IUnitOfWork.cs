using System;
using DAL.Repository.Impl;
using DAL.Repository.Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICaseRepository CaseRepository { get; }
        void Save();
    }
}