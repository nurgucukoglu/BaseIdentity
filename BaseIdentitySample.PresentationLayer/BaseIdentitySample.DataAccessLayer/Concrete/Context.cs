using BaseIdentitySample.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BaseIdentitySample.DataAccessLayer.Concrete
{
	public class Context : IdentityDbContext<AppUser, AppRole, int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-0LTDDDI\\SQLEXPRESS01; Database=BaseEntityDb; integrated Security=True;TrustServerCertificate=True;");
		}

		public DbSet<Product> Products { get; set; }	
		public DbSet<Category> Categories { get; set; }	
	}
}
 