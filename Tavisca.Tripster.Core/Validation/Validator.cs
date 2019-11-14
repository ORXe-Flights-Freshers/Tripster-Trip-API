using System;

namespace Tavisca.Tripster.Core.Validation
{
    public class Validator<TEntity> where TEntity : class
    {
        private Response<TEntity> _response;
        public TEntity Entity { get; set; }
        public Guid ID { get; set; }
        public Validator()
        {
            _response = new Response<TEntity>();
        }
        public Response<TEntity> GetResponse()
        {
            if(Entity == null)
            {
                _response.ErrorMessage = $"{typeof(TEntity).Name} with {ID} not found";
                _response.Model = null;
            }
            else
            {
                _response.Model = Entity;
                _response.ErrorMessage = null;
            }
            return _response;
        }

    }
}
