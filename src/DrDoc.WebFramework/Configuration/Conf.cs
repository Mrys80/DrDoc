using System.Reflection;
using DrDoc.Common.Entities.Abstracts;
using DrDoc.Common.Utilities.Settings;
using DrDoc.Data.Concretes.Context;
using DrDoc.Services.Concretes;
using DrDoc.WebFramework.Api;

namespace DrDoc.WebFramework.Configuration;

public static class Conf
{
    public static Assembly[] GetAllAssemblies()
    {
        var commonAssembly = typeof(Setting).Assembly;
        var entitiesAssembly = typeof(IEntity).Assembly;
        var coreEntitiesAssembly = typeof(IEntity).Assembly;
        var dataAssembly = typeof(AppDbContext).Assembly;
        var servicesAssembly = typeof(BaseService).Assembly;
        var frameworkAssembly = typeof(BaseController).Assembly;

        return new[] { commonAssembly, entitiesAssembly, coreEntitiesAssembly, dataAssembly, servicesAssembly, frameworkAssembly };
    }
}