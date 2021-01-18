using DeloitteTODO.Data;
using DeloitteTODO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DeloitteTODO.Services
{
    public abstract class BaseService
    {
        protected readonly IApplicationDbContext _dbContext;
        public BaseService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
