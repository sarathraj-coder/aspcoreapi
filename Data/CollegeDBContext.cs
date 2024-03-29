﻿using System;
using Microsoft.EntityFrameworkCore;

namespace school.Data
{
	public class CollegeDBContext : DbContext
	{
		public CollegeDBContext() {
		}

		public CollegeDBContext(DbContextOptions<CollegeDBContext> options):base(options) {
		}
		public  DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			//Table 1 
            modelBuilder.Entity<Student>().HasData(new Student
			{
				Id = 1,
				Name = "Sarath",
				Address = "doha",
				Email = "sraj@gmail.com",
				Dob = new DateTime(1986, 5, 25)
        },
		new Student
			{
				Id = 2,
				Name = "nik",
				Address = "doha",
				Email = "nik@gmail.com",
				Dob = new DateTime(1986, 5, 25)
        });

	
    }
}}

