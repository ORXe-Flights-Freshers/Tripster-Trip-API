

namespace Tavisca.Tripster.Contracts
{
    public class TransferObject<TEntity> where TEntity : class
    {
        public string ErrorMessage { get; set; } = null;
        public TEntity ModelObject { get; set; } = null;
    }
}