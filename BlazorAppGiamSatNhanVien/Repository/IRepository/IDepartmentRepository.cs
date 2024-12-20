using BlazorAppGiamSatNhanVien.Data;

namespace BlazorAppGiamSatNhanVien.Repository.IRepository
{
    public interface IDepartmentRepository
    {
        public Task<Department> CreateAsync(Department obj);
        public Task<Department> UpdateAsync(Department obj);
        public Task<bool> DeleteAsync(int id);
        public Task<Department> GetAsync(int id);
        public Task<IEnumerable<Department>> GetAllAsync();
    }
}
