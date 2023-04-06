using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB_WebAPI.Model.Abstract;

namespace MongoDB_WebAPI.Model.Concrete
{
    public class Product:IEntity
    {
        [BsonId] // Id'kolonumuzu tanımlıyor.
        [BsonRepresentation(BsonType.ObjectId)] //Property'imizin tipini belirtiyoruz.
        public string Id { get; set; }

        //BsonElement -> Collection'umuzda karşılık gelen kolon adını temsil ediyor.
        [BsonElement("productName")]
        public string ProductName { get; set; }

        [BsonElement("price")]
        public decimal? price { get; set; }

        [BsonElement("categoryId")]
        [BsonRepresentation(BsonType.ObjectId)] //Property'imizin tipini belirtiyoruz.
        public string CategoryId { get; set; }

    }
}
