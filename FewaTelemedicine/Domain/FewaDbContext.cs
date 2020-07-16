﻿using FewaTelemedicine.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FewaTelemedicine.Domain
{
    public class FewaContextFactory : IDesignTimeDbContextFactory<FewaDbContext>
    {
        public FewaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FewaDbContext>();
            optionsBuilder.UseNpgsql("Server=xxxx;Database=xxx;Port=5432;User Id=xxxx;Password=xxx;Ssl Mode=Require;");
            
            return new FewaDbContext(optionsBuilder.Options);
        }

        
    }

    public class FewaDbContext : DbContext
    {
        
        public FewaDbContext(DbContextOptions<FewaDbContext> options)
            : base(options)
        {
        }
        public DbSet<DoctorsModel> DoctorsModels { get; set; }
        public DbSet<PatientsAttendedModel> PatientsAttendedModels { get; set; }
        public DbSet<ParametersModel> ParametersModels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorsModel>().ToTable("mst_Doctors");
            modelBuilder.Entity<PatientsAttendedModel>().ToTable("txn_Patients_Attended");
            modelBuilder.Entity<PatientsAttendedModel>().Property(et => et.Id)
                    .ValueGeneratedOnAdd();
            modelBuilder.Entity<ParametersModel>().ToTable("mst_Parameters");
            // Default user name and password
            modelBuilder.Entity<DoctorsModel>().HasData(new DoctorsModel
            {Id=1, UserName = "doctor",Password = "doctor"}
            );
            // Filling the parameter table with default names
            modelBuilder.Entity<ParametersModel>().HasData(
                        new
                        {
                            Id = 1,
                            ParameterGroupName = "Hospital",
                            ParameterName = "Name",
                            ParameterValue = "Fewa Telemedicine",
                            ValueDataType = "string"
                        },
                        new
                        {
                            Id = 2,
                            ParameterGroupName = "Hospital",
                            ParameterName = "Description",
                            ParameterValue = "..Lorem ipsum dolor sit amet, consectetur adipisicing elit. Cupiditate dolorem facilis aliquam veritatis, quam debitis beatae quaerat id totam dolor, ipsa dolorum, at iusto. Explicabo numquam, nostrum iste voluptatem maiores.",
                            ValueDataType = "string"
                        },
                        new
                        {
                            Id = 3,
                            ParameterGroupName = "Hospital",
                            ParameterName = "ContactNumber",
                            ParameterValue = "98465175",
                            ValueDataType = "string"
                        },
                        new
                        {
                            Id = 4,
                            ParameterGroupName = "Hospital",
                            ParameterName = "Email",
                            ParameterValue = "dummy@email.com",
                            ValueDataType = "string"
                        },
                        new
                        {
                            Id = 5,
                            ParameterGroupName = "Hospital",
                            ParameterName = "LogoPath",
                            ParameterValue = "img/logo.png",
                            ValueDataType = "string"
                        });
            // Default entry in to paramete table

        }
    }
}