using BlazorAppGiamSatNhanVien.Data;
using BlazorAppGiamSatNhanVien.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppGiamSatNhanVien.Repository
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly ApplicationDbContext _db;
        public ShiftRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Shift> CreateAsync(Shift obj)
        {
            obj.CreateDate = DateTime.Now;
            obj.UpdateDate = obj.CreateDate;
            await _db.Shift.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _db.Shift.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _db.Shift.Remove(obj);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Shift>> GetAllAsync()
        {
            return await _db.Shift.ToListAsync();
        }

        public async Task<Shift> GetAsync(int id)
        {
            var obj = await _db.Shift.FirstOrDefaultAsync(u => u.Id == id);
            if (obj == null)
            {
                return new Shift();
            }
            return obj;
        }

        public async Task<Shift> UpdateAsync(Shift obj)
        {
            var objFromDb = await _db.Shift.FirstOrDefaultAsync(u => u.Id == obj.Id);
            if (objFromDb is not null)
            {
                objFromDb.Code = obj.Code;
                objFromDb.Name = obj.Name;
                objFromDb.Description = obj.Description;
                objFromDb.StartHour = obj.StartHour;
                objFromDb.EndHour = obj.EndHour;
                objFromDb.UpdateDate = DateTime.Now;
                _db.Shift.Update(objFromDb);
                await _db.SaveChangesAsync();
                return objFromDb;
            }
            return obj;
        }
    }
}
