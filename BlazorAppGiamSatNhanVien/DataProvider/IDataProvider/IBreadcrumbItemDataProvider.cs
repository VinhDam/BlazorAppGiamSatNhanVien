using BlazorAppGiamSatNhanVien.Data;

namespace BlazorAppGiamSatNhanVien.DataProvider.IDataProvider
{
    public interface IBreadcrumbItemDataProvider
    {
        public List<UrlItemName> GenerateBreadcrumbItemDataProviderItemDatas();
    }
}
