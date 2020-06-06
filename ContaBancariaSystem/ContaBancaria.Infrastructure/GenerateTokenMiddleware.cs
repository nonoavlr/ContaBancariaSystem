using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ContaBancaria.Application;
using ContaCorrente.Infrastructure;
using JsonWebToken;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ContaBancaria.Infrastructure
{
    public class GenerateTokenMiddleware
    {
        private readonly RequestDelegate next;

        public GenerateTokenMiddleware(RequestDelegate next) => this.next = next;

        public async Task Invoke(HttpContext context, ClientHandler db, IConfiguration configuration)
        {
            try
            {
                string secret = configuration.GetValue<string>("JWTKey");

                using (StreamReader sr = new StreamReader(context.Request.Body))
                {
                    var content = await sr.ReadToEndAsync();
                    var model = content.FromJson<RequestTokenModel>();
                    var user = await db.GetUserByApiCredentials(model.ApiKey, model.Secret);

                    if (user != null)
                    {
                        JWTPayload payload = new JWTPayload()
                        {
                            exp = DateTimeOffset.Now.AddDays(1).ToUnixTimeSeconds(),
                            uid = user.ClientID.ToString(),
                            uname = user.ClientID.ToString()
                        };
                        var token = JWT.GenerateToken(payload, secret);
                        context.Response.StatusCode = 200;
                        await context.Response.Body.WriteAsync(new { token = token }.ToJson().ToByteArray());
                        return;
                    }
                    context.Response.StatusCode = 404;
                    await context.Response.Body.WriteAsync("Usuário não encontrado".ToByteArray());
                }
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.Body.WriteAsync(
                    typeof(RequestTokenModel)
                    .GetProperties()
                    .Aggregate(nameof(RequestTokenModel) + ":\n", (acc, next) => {
                        return acc + $"  {next.Name} : {next.PropertyType.ToFriendlyName()}\n";
                    })
                    .ToByteArray());
            }
        }
    }
}
