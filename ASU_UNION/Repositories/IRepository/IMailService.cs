namespace ASU_UNION.Repositories.IRepository
{
    public interface IMailService
    {
        public Task SendEmail(string to, string subject );
    }
}
