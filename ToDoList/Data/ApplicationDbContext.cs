﻿using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<TaskList> Tasks { get; set; }
}
