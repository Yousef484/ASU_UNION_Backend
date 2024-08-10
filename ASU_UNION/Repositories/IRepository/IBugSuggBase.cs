using ASU_UNION.Models.Helpers;

namespace ASU_UNION.Repositories.IRepository
{
    public interface IBugSuggBase<T> where T : class
    {
        public Task<ServicesResponse<IEnumerable<T>>> GetAll();
        public Task<ServicesResponse<T>> AddItem(T model);
    }
}
