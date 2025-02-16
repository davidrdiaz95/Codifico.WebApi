using Codifico.Model.Dto;
using Codifico.Repository.Entity;
using Codifico.Services.Mapper;

namespace Codifico.BusinessServices.Mapper
{
	public class EmployeeMapper : IMapper<Employee, EmployeeDto>
	{
		public EmployeeDto MapFrom(Employee model)
		{
			return new EmployeeDto
			{
				EmpId = model.EmpId,
				Name = model.Name
			};
		}

		public Employee MapTo(EmployeeDto model)
		{
			return new Employee
			{
				EmpId = model.EmpId,
				Name = model.Name
			};
		}
	}
}
