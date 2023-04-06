using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB_WebAPI.Model.Abstract;

namespace MongoDB_WebAPI.Model.Concrete
{
    public class User:IEntity
    {
        [BsonId] // Id'kolonumuzu tanımlıyor.
        [BsonRepresentation(BsonType.ObjectId)] //Property'imizin tipini belirtiyoruz.
        public string Id { get; set; }

        //BsonElement -> Collection'umuzda karşılık gelen kolon adını temsil ediyor.
        [BsonElement("userNo")]
        public int UserNo { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }


        [BsonElement("city")]
        public string City { get; set; }

    }
}