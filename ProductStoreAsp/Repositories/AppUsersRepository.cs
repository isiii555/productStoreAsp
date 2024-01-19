﻿using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using ProductStoreAsp.Data;
using ProductStoreAsp.Models;
using ProductStoreAsp.Repositories.Abstractions;

namespace ProductStoreAsp.Repositories
{
    public class AppUsersRepository : IAppUsersRepository
    {
        private readonly AppDbContext _dbContext;

        public AppUsersRepository(AppDbContext dbContext)
        {
            _dbContext = Guard.Against.Null(dbContext);
        }

        public async Task AddProductToCart(Product product,string userId)
        {
            var user = await _dbContext.AppUsers.Include(a => a.Products).FirstOrDefaultAsync(a => a.Id == userId);

            user!.Products!.Add(product);

            await _dbContext.SaveChangesAsync();
        }
    }
}
