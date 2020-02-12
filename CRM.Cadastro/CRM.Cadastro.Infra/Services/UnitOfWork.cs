using CRM.Cadastro.Aplicacao.Infra;
using CRM.Cadastro.Infra.Persistence;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace CRM.Cadastro.Infra.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CadastroDbContext _db;

        private IDbContextTransaction tx;

        public UnitOfWork(CadastroDbContext db)
        {
            _db = db;
        }

        public void Begin()
        {
            if (tx != null)
            {
                throw new NotSupportedException("Já existe uma transação a decorrer.");
            }

            tx = _db.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (tx == null)
            {
                throw new NotSupportedException("Não está a decorrer nenhuma transação.");
            }

            tx.Commit();
        }

        public void Rollback()
        {
            if (tx == null)
            {
                throw new NotSupportedException("Não está a decorrer nenhuma transação.");
            }

            tx.Rollback();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}