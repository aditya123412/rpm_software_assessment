using System.Data.Entity;

namespace assessment_platform_developer.Models
{
    public class CustomerDBContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
	}
}