using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FizzBuzzz
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Run(async (context) =>
            {



                var inputList = System.IO.File.ReadAllLines(@"C:\Temp\inputFile.txt");

                foreach (var item in inputList)
                {
                    var success = int.TryParse(item, out var convertedInt);

                    if (success)
                    {
                        if (convertedInt % 3 == 0 && convertedInt % 5 == 0)
                        {
                            await context.Response.WriteAsync("FizzBuzz ");
                            continue;
                        }

                        if (convertedInt % 3 == 0 || convertedInt % 5 == 0)
                        {
                            if (convertedInt % 3 == 0)
                            {
                                await context.Response.WriteAsync("Fizz ");
                            }

                            if (convertedInt % 5 == 0)
                            {
                                await context.Response.WriteAsync("Buzz ");
                            }
                        }
                        else
                        {
                            await context.Response.WriteAsync($"Divided {convertedInt} by 3 ");
                            await context.Response.WriteAsync($"Divided {convertedInt} by 5 ");
                        }
                    }
                    else
                    {
                        await context.Response.WriteAsync("Invalid Item ");
                    }
                }
            });



        }
    }
}
