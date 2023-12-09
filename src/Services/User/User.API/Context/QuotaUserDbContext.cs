using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using User.API.Entities;

namespace User.API.Context
{
    public class QuotaUserDbContext : IdentityDbContext<Entities.User, Role, int>
    {
        public QuotaUserDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
