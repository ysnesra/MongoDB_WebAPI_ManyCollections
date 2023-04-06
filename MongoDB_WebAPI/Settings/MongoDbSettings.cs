namespace MongoDB_WebAPI.Settings
{
    //appsettings dosyasında bu değişkenlerin değeri verildi.
    public class MongoDbSettings : IDbSettings
    {   
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        //public string[] Collections { get; set; }
    }
}

