using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.MongoDB
{
    public class MongoCollection<TEntity>
    {
        public IMongoCollection<TEntity> MyProperty
        {
            get => DbContext<TEntity>.MongoCollection();
        }
    }
}
