﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Configuration;

namespace EdFi.Admin.DataAccess.Providers
{
    public class AdminDatabaseConnectionStringProvider : IAdminDatabaseConnectionStringProvider
    {
        private readonly IConfigConnectionStringsProvider _configConnectionStringsProvider;

        public AdminDatabaseConnectionStringProvider(IConfigConnectionStringsProvider configConnectionStringsProvider)
        {
            _configConnectionStringsProvider = configConnectionStringsProvider;
        }

        public string GetConnectionString() => _configConnectionStringsProvider.GetConnectionString("EdFi_Admin");
    }
}
