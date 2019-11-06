using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Tripster.Contracts;

namespace Tavisca.Tripster.Core
{
    public class Validator<TEntity> where TEntity : class
    {
        private TransferObject<TEntity> _transferObject;
        public TEntity Entity { get; set; }
        public Guid ID { get; set; }
        public Validator()
        {
            _transferObject = new TransferObject<TEntity>();
        }
        public TransferObject<TEntity> GetTransferObject()
        {
            if(Entity == null)
            {
                _transferObject.ErrorMessage = $"{typeof(TEntity).Name} with {ID} not found";
                _transferObject.ModelObject = null;
            }
            else
            {
                _transferObject.ModelObject = Entity;
                _transferObject.ErrorMessage = null;
            }
            return _transferObject;
        }

    }
}
