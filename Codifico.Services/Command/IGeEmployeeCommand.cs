using Codifico.Model.Dto;

namespace Codifico.Services.Command
{
    public interface IGeEmployeeCommand
    {
        Task<IEnumerable<EmployeeDto>> Execute();
    }
}
