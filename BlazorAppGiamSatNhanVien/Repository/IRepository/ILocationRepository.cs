using BlazorAppGiamSatNhanVien.Data;

namespace BlazorAppGiamSatNhanVien.Repository.IRepository
{
    public interface ILocationRepository
    {
        public Task<Location> CreateAsync(Location obj);
        public Task<Location> UpdateAsync(Location obj);
        public Task<bool> DeleteAsync(int id);
        public Task<Location> GetAsync(int id);
        public Task<IEnumerable<Location>> GetAllAsync();
    }
}
