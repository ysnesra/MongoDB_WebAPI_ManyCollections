# MongoDB_WebAPI_ManyCollections
MongoDB ile WepApi Projesi 


MongoShell ekranında; User,Product ve Category collectionslarından oluşan eStoreDB database'i oluşturuldu.

Birden çok tablomuz olduğundan MongDB veritabanı bağlantısını sağlamak için Generic Yapıya taşıdım:

-IGenericRepository ve GenericRepositoryBase ile base classı oluşturuldu

    "this.Collection = db.GetCollection<TEntity>(typeof(TEntity).Name.ToLowerInvariant());" --> kodu herbir entity clasımızın isminde MongoDB de tablomuzu oluşturur.

    Herbir tablomuzun ayrı ayrı Respository lerini oluşturup veritabanı bağlantıları sağlandı.

-startup.cs de "services.AddSingleton" ilişkileri verildi.

-Bir Category'ye ait birden fazla Product olabilir durumu Product classına CategoryId kolonu eklenerek sağlandı


Ürün Ekleme ekranı:
![Product_Add](https://user-images.githubusercontent.com/104023688/230380046-6fd11ead-938a-42a0-85b5-614ff58f7158.JPG)

Ürün Listeleme ekranı:
![productList](https://user-images.githubusercontent.com/104023688/230380173-a2bc309a-b760-44f3-beeb-fffa1207c3e5.JPG)

Kategori Listeleme ekranı:
![CategoryList](https://user-images.githubusercontent.com/104023688/230380332-69cdf82b-901e-4833-bc6c-89a5b6fe6bcb.JPG)

