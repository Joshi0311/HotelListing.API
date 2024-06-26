﻿using HotelListing.API.Data;
using HotelListing.API.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HotelListingDBContext _context;
        public GenericRepository(HotelListingDBContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
           await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task DeleteAsync(int id)
        {
            var country = await GetAsync(id);
           

               _context.Set<T>().Remove(country);
            await  _context.SaveChangesAsync();
   }

        public async Task<bool> Exist(int id)
        {
                var entity=await GetAsync(id);
                  return entity!=null; 
        }

        public async Task<List<T>> GetALlsync()
        {
              return  await  _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            if (id == null) { 
            return null;
            }
                return await _context.Set<T>().FindAsync(id);
          
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await  _context.SaveChangesAsync();
        }
    }
}
