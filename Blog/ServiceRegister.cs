using Blog.Data;
using Blog.Domain.Interfaces;
using Blog.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection @this)
        {
            var serviceType = typeof(Service);
            var definedTypes = serviceType.Assembly.DefinedTypes;

            var services = definedTypes
                .Where(x => x.GetTypeInfo().GetCustomAttribute<Service>() != null);

            foreach (var service in services)
            {
                @this.AddTransient(service);
            }

            @this.AddTransient<IPostManager, PostManager>();
            @this.AddTransient<IMainCommentManager, MainCommentManager>();
            @this.AddTransient<ISubCommentManager, SubCommentManager>();

            return @this;
        }
    }
}
