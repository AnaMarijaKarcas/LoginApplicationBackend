using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Backend.Models;

namespace Backend.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }
		public DbSet<User> Users { get; set; }

	}
}