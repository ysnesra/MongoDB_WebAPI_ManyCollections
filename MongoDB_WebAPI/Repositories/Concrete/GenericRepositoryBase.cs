using MongoDB.Driver;
using MongoDB_WebAPI.Model.Abstract;
using MongoDB_WebAPI.Model.Concrete;
using MongoDB_WebAPI.Repositories.Abstract;
using MongoDB_WebAPI.Settings;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MongoDB_WebAPI.Repositories.Concrete
{
    public class GenericRepositoryBase<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IEntity, new()
    {

        protected readonly IMongoCollection<TEntity> Collection;
        public GenericRepositoryBase(IDbSettings dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            var db = client.GetDatabase(dbSettings.DatabaseName);
            this.Collection = db.GetCollection<TEntity>(typeof(TEntity).Name.ToLowerInvariant());
        }
        public TEntity Add(TEntity entity)
        {
            try
            {
                Collection.InsertOne(entity);
                return entity;             
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("Ekleme işlemi sırasında bir hata oluştu: " + ex.Message);
            }
            
        }
        public long Delete(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                return Collection.DeleteOne(filter).DeletedCount;  //silinen dökümantasyonun(satırın) sayısını döner
            }
            catch (Exception ex)
            {

                throw new Exception("Silme işlemi sırasında bir hata oluştu: " + ex.Message);
            }
         
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                return Collection.Find(filter).FirstOrDefault();                
            }
            catch (Exception ex)
            {

                throw new Exception("Böyle bir documents (satır) bulunamadı: " + ex.Message);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                return Collection.Find(u => true).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Dökümantasyonlar listenemedi " + ex.Message);
            }
        }

        public long Update(Expression<Func<TEntity, bool>> filter, TEntity entity)
        {
            try
            {
                //ReplaceOne : databasede koleksiyonda(tabloda) güncelleme yapan komut
                //ModifiedCount : değiştirilen satır sayısını tutar. Bu, kullanıcının güncellenip güncellenmediğini belirlemek için kullanılılır
                return Collection.ReplaceOne(filter, entity).ModifiedCount;
            }
            catch (Exception ex)
            {

                throw new Exception("Güncelleme işlemi sırasında bir hata oluştu: " + ex.Message);
            }
                     
        }
    }
}
