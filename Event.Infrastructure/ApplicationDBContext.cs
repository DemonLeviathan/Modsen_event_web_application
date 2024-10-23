﻿using Microsoft.EntityFrameworkCore;

namespace Event.Infrastructure;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }

    public DbSet<Domain.Event> Events { get; set; }
    public DbSet<Domain.Participant> Participants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }
}