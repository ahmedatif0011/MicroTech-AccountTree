﻿using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data;

namespace MicroTech.Infrastructure.Interfaces.Context
{
    public interface IApplicationSqlDbContext
    {
        IDbConnection Connection { get; }
        DatabaseFacade Database { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
