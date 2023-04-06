namespace MongoDB_WebAPI.Settings
{
    public interface IDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        //public string[] Collections { get; set; }
    }
}
