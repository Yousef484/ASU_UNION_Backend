namespace ASU_UNION.Models.Helpers
{
    public class JWT
    {
        public string key { get; set; }
        public string issuer { get; set; }
        public string audience { get; set; }
        public double duration { get; set; }
    }
}
