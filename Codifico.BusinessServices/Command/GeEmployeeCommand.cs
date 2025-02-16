using Codifico.Model.Dto;
using Codifico.Repository.Constant;
using Codifico.Repository.Entity;
using Codifico.Repository.Repository.Interface;
using Codifico.Services.Command;
using Codifico.Services.Mapper;

namespace Codifico.BusinessServices.Command
{
	public class GeEmployeeCommand : IGeEmployeeCommand
	{
		private readonly IRepository<Employee> repository;
		private readonly IMapper<Employee, EmployeeDto> mapper;

		public GeEmployeeCommand(IRepository<Employee> repository,
			IMapper<Employee, EmployeeDto> mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<EmployeeDto>> Execute()
		{
			var prediction = this.repository.ExecuteSpTable(Procedure.GetEmployees);
			return prediction.Select(x => this.mapper.MapFrom(x));
		}
	}
}
