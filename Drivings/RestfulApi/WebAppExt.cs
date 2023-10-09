using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace RestfulApi;

public static class WebAppExt
{
    public static void UseRestfulApiConfigurations(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseHttpsRedirection();
        
        app.MapControllers();
    }
}