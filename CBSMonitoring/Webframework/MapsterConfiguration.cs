﻿using Mapster;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CBSMonitoring.Webframework
{
    public static class MapsterConfiguration
    {
        public static void AddMapster(this IServiceCollection services)
        {
            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            //Assembly applicationAssembly = typeof(BaseDto<,>).Assembly;
            //typeAdapterConfig.Scan(applicationAssembly);
        }
    }
}
