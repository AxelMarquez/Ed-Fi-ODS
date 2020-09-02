﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Common.Database;
using EdFi.Ods.Common.Database;

namespace EdFi.Ods.Api.Container.Modules
{
    public class AdminConnectionStringProviderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AdminDatabaseConnectionStringProvider>().As<IAdminDatabaseConnectionStringProvider>()
                .SingleInstance();
        }
    }
}
#endif