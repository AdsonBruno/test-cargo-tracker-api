﻿using Microsoft.EntityFrameworkCore;
using test_cargo_tracker_api.src.Models;
using test_cargo_tracker_api.src.Models.Container;

namespace test_cargo_tracker_api.src.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<CustomerModel> Customer { get; set; }
        public DbSet<ContainerModel> Container { get; set; }
    }
}
