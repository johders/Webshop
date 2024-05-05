using Newtonsoft.Json;
using PE1.Webshop.Web.Services.Interfaces;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Services
{
    public class SessionStateService : IStateHelper
    {
        private readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        };

        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionStateService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public T GetValue<T>(string key)
        {
            return JsonConvert.DeserializeObject<T>(_httpContextAccessor.HttpContext?.Session?.GetString(key) ?? string.Empty);

        }

        public void SetValue(string key, object viewModel)
        {
            _httpContextAccessor.HttpContext?.Session?.SetString(key, JsonConvert.SerializeObject(viewModel, jsonSettings));
        }

        public void Remove(string key)
        {
            _httpContextAccessor.HttpContext?.Session?.Remove(key);
        }

    }
}
