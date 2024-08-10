using ASU_UNION.Data;
using ASU_UNION.Models;
using ASU_UNION.Repositories.IRepository;

namespace ASU_UNION.Repositories.Repository
{
    public class SuggestationsRepo : BugSuggBase<Suggestations>, ISuggestationsRepo
    {
        public SuggestationsRepo(ApplicationDbContext context) : base(context)
        {
        }
    }
}
