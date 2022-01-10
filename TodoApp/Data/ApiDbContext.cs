using Microsoft.EntityFrameworkCore;
using TodoApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TodoApp.Data
{
    public class ApiDbContext : IdentityDbContext
    {
        public virtual DbSet<ItemData> Items { get; set; } 

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) 
        {

        }
    }
}