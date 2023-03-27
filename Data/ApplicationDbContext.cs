﻿using CrudMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudMVC.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //agregando los modelos
        public DbSet<Contact> Contacts { get; set; }   
    }
}
