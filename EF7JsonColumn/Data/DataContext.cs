using System;
using Microsoft.EntityFrameworkCore;


namespace EF7JsonColumn.Data
{
	public class DataContext: DbContext
	{
		public DataContext(DbContextOptions<DataContext> options):base(options) {}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SuperHero>().OwnsOne(sh=>sh.Details, navigationsBuilder =>
			{
                //navigationsBuilder.Table("HeroDetails");
                navigationsBuilder.ToJson();//Details will exist in SuperHero Table(only one table exists)
			});

		}
		public DbSet<SuperHero> Heroes { get; set; }
	}
}

