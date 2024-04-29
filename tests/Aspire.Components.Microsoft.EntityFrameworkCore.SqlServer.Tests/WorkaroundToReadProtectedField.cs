// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;

namespace Aspire.Components.Microsoft.EntityFrameworkCore.SqlServer.Tests;

public class WorkaroundToReadProtectedField : SqlServerRetryingExecutionStrategy
{
    public WorkaroundToReadProtectedField(DbContext context) : base(context)
    {
    }

    public int RetryCount => base.MaxRetryCount;
}
