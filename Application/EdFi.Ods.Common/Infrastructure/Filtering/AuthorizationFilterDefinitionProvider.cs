// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.Common.Infrastructure.Filtering
{
    /// <inheritdoc cref="IAuthorizationFilterDefinitionProvider" />
    public class AuthorizationFilterDefinitionProvider : IAuthorizationFilterDefinitionProvider
    {
        private readonly Lazy<IDictionary<string, AuthorizationFilterDefinition>> _filterDefinitionByName;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationFilterDefinitionProvider"/> class using the supplied filter configurators.
        /// </summary>
        /// <param name="authorizationFilterDefinitionsProviders"></param>
        public AuthorizationFilterDefinitionProvider(IAuthorizationFilterDefinitionsProvider[] authorizationFilterDefinitionsProviders)
        {
            _filterDefinitionByName = new Lazy<IDictionary<string, AuthorizationFilterDefinition>>(
                () => authorizationFilterDefinitionsProviders
                    .SelectMany(c => c.GetAuthorizationFilterDefinitions())
                    .Distinct()
                    .ToDictionary(f => f.FilterName, f => f));
        }

        /// <inheritdoc cref="IAuthorizationFilterDefinitionProvider.GetFilterDefinition" />
        public AuthorizationFilterDefinition GetFilterDefinition(string filterName)
        {
            if (!_filterDefinitionByName.Value.TryGetValue(filterName, out var filterApplicationDetails))
            {
                throw new Exception($"Unable to find filter application details for filter '{filterName}'.");
            }

            return filterApplicationDetails;
        }

        /// <inheritdoc cref="IAuthorizationFilterDefinitionProvider.TryGetFilterApplicationDetails" />
        public bool TryGetFilterApplicationDetails(string filterName, out AuthorizationFilterDefinition authorizationFilterDefinition)
        {
            return _filterDefinitionByName.Value.TryGetValue(filterName, out authorizationFilterDefinition);
        }
    }
}