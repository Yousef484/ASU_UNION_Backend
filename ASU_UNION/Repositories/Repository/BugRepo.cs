using ASU_UNION.Data;
using ASU_UNION.Models;
using ASU_UNION.Repositories.IRepository;

namespace ASU_UNION.Repositories.Repository
{
    public class BugRepo : BugSuggBase<Bug> , IBugRepo
    {
        public BugRepo(ApplicationDbContext context) : base(context)
        {
        }
    }
}
