using Customers.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace Customers.Api.DBContext
{
    public class CustomerContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }

        public Task<bool> ExistsAsync(string fullName, CancellationToken cancellationToken)
        {
            return Task.FromResult(false);
        }
    }
}
