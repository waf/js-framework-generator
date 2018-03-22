// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using StandaloneApp.JSFrameworkGenerator;
using StandaloneApp.JSFrameworkGenerator.Services;

namespace StandaloneApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(configure =>
            {
                configure.Add(Service(new FrameworkGenerator(FrameworkData.Frameworks)));
                configure.Add(Service(new CompanyGenerator(CompanyData.Companies)));
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }

        private static ServiceDescriptor Service<T>(T obj) =>
            new ServiceDescriptor(typeof(T), obj);

    }
}
