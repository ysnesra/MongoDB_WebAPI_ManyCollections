using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Net;
using MongoDB_WebAPI.Model.Abstract;

namespace MongoDB_WebAPI.Model.Concrete
{
    public class Category : IEntity
    {
        [BsonId] // Id'kolonumuzu tanımlıyor.
        [BsonRepresentation(BsonType.ObjectId)] //Property'imizin tipini belirtiyoruz
        public string Id { get; set; }

        //BsonElement -> Collection'umuzda karşılık gelen kolon adını temsil ediyor.
        [BsonElement("categoryName")]
        public string CategoryName { get; set; }

        //[BsonElement("products")]
        //public ICollection<Product> Products { get; set; }
    }
}
