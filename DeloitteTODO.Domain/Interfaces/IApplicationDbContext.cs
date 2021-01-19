using DeloitteTODO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeloitteTODO.Domain.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<ToDoData> ToDoData { get; set; }
    }
}
