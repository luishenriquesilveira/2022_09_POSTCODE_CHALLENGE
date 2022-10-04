using Microsoft.Extensions.DependencyInjection;
using PostCodes.Application.Test.Shared;
using PostCodes.Infrastructure.Context;

namespace PostCodes.Application.Test.Integration
{
    public class PostCodeMockData
    {
        public static async Task CreatePostCodes(ApplicationTest application, bool create)
        {
            using (var scope = application.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var appDbContext = provider.GetRequiredService<AppDbContext>())
                {
                    await appDbContext.Database.EnsureCreatedAsync();

                    if (create)
                    {
                        await appDbContext.PostCodes.AddAsync(Utils.FactoryPostCode());
                        await appDbContext.PostCodes.AddAsync(Utils.FactoryPostCode());
                        await appDbContext.PostCodes.AddAsync(Utils.FactoryPostCode());
                        await appDbContext.PostCodes.AddAsync(Utils.FactoryPostCode());

                        await appDbContext.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
