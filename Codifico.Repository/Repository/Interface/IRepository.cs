using Microsoft.Data.SqlClient;

namespace Codifico.Repository.Repository.Interface
{
	public interface IRepository<T>
	{
		int ExecuteSp(string spName, List<SqlParameter> parameters);
		IEnumerable<T> ExecuteSpTable(string spName, List<SqlParameter> parameters = null);
	}
}
