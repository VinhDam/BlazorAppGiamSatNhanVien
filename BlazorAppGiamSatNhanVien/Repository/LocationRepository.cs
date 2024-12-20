using BlazorAppGiamSatNhanVien.Data;
using BlazorAppGiamSatNhanVien.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppGiamSatNhanVien.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _db;
        public LocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Location> CreateAsync(Location obj)
        {
            obj.CreateDate = DateTime.Now;
            obj.UpdateDate = obj.CreateDate;
            await _db.Location.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _db.Location.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _db.Location.Remove(obj);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _db.Location.ToListAsync();
        }

        public async Task<Location> GetAsync(int id)
        {
            var obj = await _db.Location.FirstOrDefaultAsync(u => u.Id == id);
            if (obj == null)
            {
                return new Location();
            }
            return obj;
        }

        public async Task<Location> UpdateAsync(Location obj)
        {
            var objFromDb = await _db.Location.FirstOrDefaultAsync(u => u.Id == obj.Id);
            if (objFromDb is not null)
            {
                objFromDb.Code = obj.Code;
                objFromDb.Name = obj.Name;
                objFromDb.Description = obj.Description;
                objFromDb.UpdateDate = DateTime.Now;
                _db.Location.Update(objFromDb);
                await _db.SaveChangesAsync();
                return objFromDb;
            }
            return obj;
        }
    }
}
