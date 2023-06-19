namespace BlazorApp.Data
{
    public interface IEmployeeSvc
    {
        Task<IEnumerable<Employee>> GetImages(int days);
    }
}