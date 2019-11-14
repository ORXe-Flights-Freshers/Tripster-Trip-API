using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.MongoDB.Repository
{
    public class EmailRepository : GenericRepository<Email>
    {
        public async Task<Email> GetEmailById(string id)
        {
            var requiredId = Builders<Email>.Filter.Eq("_id", id);
            return await Task.Run(() => Collection.FindAsync(requiredId).Result.FirstOrDefault());
        }

        public async Task<Email> UpdateEmail(string id, Email email)
        {
            var requiredId = Builders<Email>.Filter.Eq("_id", id);
            var updatedEntity = await Collection.FindOneAndReplaceAsync(requiredId, email);
            return updatedEntity;
        }
    }
}
