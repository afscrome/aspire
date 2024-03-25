// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Aspire.Npgsql.EntityFrameworkCore.PostgreSQL.Tests;

public class WorkaroundToReadProtectedField : NpgsqlRetryingExecutionStrategy
{
    public WorkaroundToReadProtectedField(DbContext context) : base(context)
    {
    }

    public WorkaroundToReadProtectedField(ExecutionStrategyDependencies dependencies) : base(dependencies)
    {
    }

    public int RetryCount => base.MaxRetryCount;
}
