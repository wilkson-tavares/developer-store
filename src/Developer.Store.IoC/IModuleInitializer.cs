using Microsoft.AspNetCore.Builder;

namespace Developer.Store.IoC;

public interface IModuleInitializer
{
    void Initialize(WebApplicationBuilder builder);
}
