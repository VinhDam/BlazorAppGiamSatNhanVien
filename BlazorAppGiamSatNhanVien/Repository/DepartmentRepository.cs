using BlazorAppGiamSatNhanVien.Data;
using BlazorAppGiamSatNhanVien.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BlazorAppGiamSatNhanVien.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _db;
        public DepartmentRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Department> CreateAsync(Department obj)
        {
            obj.CreateDate = DateTime.Now;
            obj.UpdateDate = obj.CreateDate;
            await _db.Department.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _db.Department.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _db.Department.Remove(obj);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _db.Department.Include(u => u.Location).ToListAsync();
        }

        public async Task<Department> GetAsync(int id)
        {
            var obj = await _db.Department.FirstOrDefaultAsync(u => u.Id == id);
            if (obj == null)
            {
                return new Department();
            }
            return obj;
        }

        public async Task<Department> UpdateAsync(Department obj)
        {
            var objFromDb = await _db.Department.FirstOrDefaultAsync(u => u.Id == obj.Id);
            if (objFromDb is not null)
            {
                objFromDb.Code = obj.Code;
                objFromDb.Name = obj.Name;
                objFromDb.Description = obj.Description;
                objFromDb.LocationId = obj.LocationId;
                objFromDb.UpdateDate = DateTime.Now;
                _db.Department.Update(objFromDb);
                await _db.SaveChangesAsync();
                return objFromDb;
            }
            return obj;
        }
    }
}
