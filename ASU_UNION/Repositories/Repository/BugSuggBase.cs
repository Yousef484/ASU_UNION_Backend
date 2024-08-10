using ASU_UNION.Data;
using ASU_UNION.Models.Helpers;
using ASU_UNION.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ASU_UNION.Repositories.Repository
{
    public class BugSuggBase<T> : IBugSuggBase<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BugSuggBase(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServicesResponse<T>> AddItem(T model)
        {
            var response = new ServicesResponse<T>();
            await _context.Set<T>().AddAsync(model); 
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = "Added Successfully...";
            response.Data = model;
            return response;
           
            
        }

        public async Task<ServicesResponse<IEnumerable<T>>> GetAll()
        {
            var response = new ServicesResponse<IEnumerable<T>>();
            response.Success = true;
            response.Message = "Data Retreived Successfully...";
            response.Data = await _context.Set<T>().ToListAsync(); ;
            return response;
        }
    }
}
