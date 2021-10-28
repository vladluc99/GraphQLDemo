using GraphQLDemo.GraphQL;
using GraphQLDemo.IService;
using GraphQLDemo.Service;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace GraphQLDemo
{
    public class Startup
    {
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGroupService, GroupService>();
            services.AddSingleton<IStudentService, StudentService>();

            services.AddGraphQL(x => SchemaBuilder.New()
                .AddServices(x)
                .AddType<GroupType>()
                .AddType<StudentType>()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .Create()
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UsePlayground(new PlaygroundOptions {
                    QueryPath = "/api",
                    Path = "/Playground"
                });
            }

            app.UseGraphQL("/api");

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
