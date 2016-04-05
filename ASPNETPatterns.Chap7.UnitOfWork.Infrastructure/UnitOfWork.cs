using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ASPNETPatterns.Chap7.UnitOfWork.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> addedEntities;
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> changedEntities;
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> deletedEntities;

        public UnitOfWork()
        {
            this.addedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            this.changedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            this.deletedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
        }

        public void Commit()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach(IAggregateRoot entity in this.addedEntities.Keys)
                {
                    this.addedEntities[entity].PersistCreationOf(entity);
                }

                foreach (IAggregateRoot entity in this.changedEntities.Keys)
                {
                    this.changedEntities[entity].PersistUpdateOf(entity);
                }

                foreach (IAggregateRoot entity in this.deletedEntities.Keys)
                {
                    this.deletedEntities[entity].PersistDeleteOf(entity);
                }

                scope.Complete();
            }
        }

        public void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            if (!changedEntities.ContainsKey(entity))
                this.changedEntities.Add(entity, unitOfWorkRepository);
        }

        public void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            if (!this.addedEntities.ContainsKey(entity))
                this.addedEntities.Add(entity, unitOfWorkRepository);
        }

        public void RegisterRemove(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            if (!this.deletedEntities.ContainsKey(entity))
                this.deletedEntities.Add(entity, unitOfWorkRepository);
        }
    }
}
