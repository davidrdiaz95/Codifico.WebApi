using Codifico.Model.Dto;

namespace Codifico.Services.Command
{
    public interface IGetClientOrderForNameAndIdCommand
    {
		Task<IEnumerable<ClientOrderDto>> Execute(int? id, int page = 1, int size = 10);
	}
}
