namespace HotelListing.API.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
         Task<T> GetAsync(int id);
         Task<List<T>> GetALlsync();
         Task<T> AddAsync(T entity);
         Task UpdateAsync(T entity);
         Task DeleteAsync(int id);
         Task<bool>Exist(int id);


         

    }
}
