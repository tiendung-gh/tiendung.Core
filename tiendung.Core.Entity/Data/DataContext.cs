﻿using Microsoft.EntityFrameworkCore;

namespace tiendung.Core.Entity.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
