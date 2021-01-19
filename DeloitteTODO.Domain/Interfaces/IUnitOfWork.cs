using DeloitteTODO.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeloitteTODO.Domain.Interfaces
{    public interface IUnitOfWork
    {
        IToDoRepository ToDoRepository { get; }

        void Dispose();
        public Task Save();
    }
}
