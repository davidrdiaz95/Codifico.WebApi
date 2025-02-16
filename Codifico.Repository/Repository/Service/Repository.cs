using Codifico.Repository.Context;
using Codifico.Repository.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Codifico.Repository.Repository.Service
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly CodificoContext contextDataBase;

		public Repository(CodificoContext contextDataBase)
		{
			this.contextDataBase = contextDataBase;
		}
		public int ExecuteSp(string spName, List<SqlParameter> parameters)
		{
			var query = 0;
			if (parameters != null && parameters.Any())
				spName = spName + " " + ConfigureParameterProcedure(parameters);

			query = contextDataBase.Database.ExecuteSqlRaw("exec " + spName);

			return query;
		}

		public IEnumerable<T> ExecuteSpTable(string spName, List<SqlParameter> parameters = null)
		{
			IQueryable<T> query;
			if (parameters != null && parameters.Any())
				spName = spName + " " + ConfigureParameterProcedure(parameters);

			query = contextDataBase.Database.SqlQueryRaw<T>($"exec {spName}");



			return query.ToList();
		}

		private string ConfigureParameterProcedure(List<SqlParameter> parameters)
		{
			var chain = "";
			var count = parameters.Count();
			for (int i = 0; i < count; i++)
			{
				object value;
				if (parameters[i].Value is string)
					value = $"'{parameters[i].Value}'";
				else
					value = parameters[i].Value;

				if (i == count - 1)
					chain = chain + parameters[i].ParameterName + "=" + value;
				else
					chain = chain + parameters[i].ParameterName + "=" + value + ",";
			}
			return chain;
		}

	}
}
