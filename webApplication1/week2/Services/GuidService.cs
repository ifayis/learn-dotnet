namespace WebApi.Services
{
    public class GuidService : ISingletonService, IScopedService, ITransientService
    {
        private readonly string _guid;

        public GuidService()
        {
            _guid = Guid.NewGuid().ToString();
        }
        public string GetGuid() => _guid;
    }

}
