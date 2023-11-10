﻿using FastLocationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FastLocationAPI.Context;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }
}
