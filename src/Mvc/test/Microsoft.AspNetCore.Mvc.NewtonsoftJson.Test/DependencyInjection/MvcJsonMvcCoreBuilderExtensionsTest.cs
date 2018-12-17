﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace Microsoft.Extensions.DependencyInjection
{
    public class MvcJsonMvcBuilderExtensionsTest
    {
        [Fact]
        public void AddMvc_AddsMvcJsonOption()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            services.AddMvc()
                .AddNewtonsoftJsonOptions((options) =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            // Assert
            Assert.Single(services, d => d.ServiceType == typeof(IConfigureOptions<MvcJsonOptions>));
        }
    }
}
