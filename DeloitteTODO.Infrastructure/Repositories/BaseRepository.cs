using DeloitteTODO.Domain.Repositories;
using DeloitteTODO.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeloitteTODO.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
