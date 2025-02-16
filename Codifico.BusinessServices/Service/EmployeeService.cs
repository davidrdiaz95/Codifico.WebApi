using Codifico.Model.Dto;
using Codifico.Model.Util;
using Codifico.Services.Command;
using Codifico.Services.Service;

namespace Codifico.BusinessServices.Service
{
	public class EmployeeService : IEmployeeService
	{
		private readonly IGeEmployeeCommand geEmployeeCommad;

		public EmployeeService(IGeEmployeeCommand geEmployeeCommad)
		{
			this.geEmployeeCommad = geEmployeeCommad;
		}

		public async Task<ResponseDTO<IEnumerable<EmployeeDto>>> GetEmployees()
		{
			var employees = await this.geEmployeeCommad.Execute();
			return employees.Any() ?
				ResponseStatus.ResponseSucessful<IEnumerable<EmployeeDto>>(employees) :
				ResponseStatus.ResponseWithoutData<IEnumerable<EmployeeDto>>("No se encontraron empleados");
		}
	}
}
