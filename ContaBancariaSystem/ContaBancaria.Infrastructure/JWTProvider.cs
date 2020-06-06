﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Builder;

namespace ContaBancaria.Infrastructure
{
    public static class JWTProvider
    {
        public static IApplicationBuilder UseJWTAuthorization(this IApplicationBuilder application)
        {
            application.Map("/api/Authorization/GenerateToken", app => {
                app.UseMiddleware<GenerateTokenMiddleware>();
            });

            application.UseMiddleware<ValidateTokenMiddleware>();

            return application;
        }
    }
}
