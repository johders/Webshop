namespace PE1.Webshop.Web.Services.Interfaces
{
    public interface IStateHelper
    {

        public void SetValue(string key, object value);

        public T GetValue<T>(string key);

        public void Remove(string key);

    }
}
