using Codifico.Model.Dto;

namespace Codifico.Services.Service
{
    public interface IEmployeeService
    {
        Task<ResponseDTO<IEnumerable<EmployeeDto>>> GetEmployees();

	}
}
