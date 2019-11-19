namespace Tavisca.Tripster.Core.Validation
{
    public class Response<TEntity> where TEntity : class
    {
        public string ErrorMessage { get; set; } = null;
        public TEntity Model { get; set; } = null;
    }
}