using PE1.Webshop.Core;

namespace PE1.Webshop.Web.Services.Interfaces
{
	public interface IDbHelper<T>
	{
		Task Create(T item);
		Task Update(T item);
		Task Delete(T item);
	}
}
