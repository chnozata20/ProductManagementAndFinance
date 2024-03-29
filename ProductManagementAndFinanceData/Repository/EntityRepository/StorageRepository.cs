﻿using Entities.ConcreteEntity;
using Microsoft.EntityFrameworkCore;
using ProductManagementAndFinanceData.Repository.Contract;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;
using System.Linq.Expressions;

namespace ProductManagementAndFinanceData.Repository.EntityRepository
{
    public class StorageRepository : GenericRepository<Storage>, IStorageRepository
    {
        public StorageRepository(ProductManagementAndFinanceContext context) : base(context)
        {
        }

        private DbSet<Storage> Context
        {
            get { return _context.Storages; }
        }

        public async Task<IQueryable<Storage>> GetAllStoragesWithUser()
        {
            return  Context.Include(a => a.User);
        }

        public async Task<IQueryable<Storage>> GetFilteredStoragesWithUser(Expression<Func<Storage, bool>> predicate)
        {
            return Context.Include(a => a.User).Where(predicate);
        }

        public async Task<IQueryable<Storage>> GetFilteredStoragesWithProductAndUser(Expression<Func<Storage, bool>> predicate)
        {
            return Context.Include(a => a.User)
                .Include(a => a.Products)
                .Where(predicate);
        }
    }
}