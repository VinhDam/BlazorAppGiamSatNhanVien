using BlazorAppGiamSatNhanVien.Data;
using BlazorAppGiamSatNhanVien.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppGiamSatNhanVien.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Employee> CreateAsync(Employee obj)
        {
            obj.CreateDate = DateTime.Now;
            obj.UpdateDate = obj.CreateDate;
            await _db.Employees.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _db.Employees.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _db.Employees.Remove(obj);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _db.Employees.Include(u=>u.Shift).Include(u=>u.Department).ToListAsync();
        }

        public async Task<Employee> GetAsync(int id)
        {
            var obj = await _db.Employees.FirstOrDefaultAsync(u => u.Id == id);
            if (obj == null)
            {
                return new Employee();
            }
            return obj;
        }

        public async Task<Employee> UpdateAsync(Employee obj)
        {
            var objFromDb = await _db.Employees.FirstOrDefaultAsync(u => u.Id == obj.Id);
            if (objFromDb is not null)
            {
                objFromDb.Code = obj.Code;
                objFromDb.Name = obj.Name;
                objFromDb.PhoneNumber = obj.PhoneNumber;
                objFromDb.Email = obj.Email;
                objFromDb.CCCD = obj.CCCD;
                objFromDb.Description = obj.Description;
                objFromDb.DepartmentId = obj.DepartmentId;
                objFromDb.ShiftId = obj.ShiftId;
                objFromDb.UpdateDate = DateTime.Now;
                _db.Employees.Update(objFromDb);
                await _db.SaveChangesAsync();
                return objFromDb;
            }
            return obj;
        }
    }
}
