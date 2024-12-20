using BlazorAppGiamSatNhanVien.Data;

namespace BlazorAppGiamSatNhanVien.Repository.IRepository
{
    public interface IShiftRepository
    {
        public Task<Shift> CreateAsync(Shift obj);
        public Task<Shift> UpdateAsync(Shift obj);
        public Task<bool> DeleteAsync(int id);
        public Task<Shift> GetAsync(int id);
        public Task<IEnumerable<Shift>> GetAllAsync();
    }
}
