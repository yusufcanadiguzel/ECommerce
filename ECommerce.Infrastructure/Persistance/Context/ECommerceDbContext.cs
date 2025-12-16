using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Persistance.Context;

public class ECommerceDbContext : DbContext
{
    public ECommerceDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }
}
