using Codifico.Model.Dto;
using Codifico.Model.Util;
using Codifico.Services.Command;
using Codifico.Services.Service;

namespace Codifico.BusinessServices.Service
{
	public class ClientOrderService : IClientOrderService
	{
		private readonly IGetClientOrderForNameAndIdCommand getClientOrderForNameAndIdCommand;

		public ClientOrderService(IGetClientOrderForNameAndIdCommand getClientOrderForNameAndIdCommand)
		{
			this.getClientOrderForNameAndIdCommand = getClientOrderForNameAndIdCommand;
		}

		public async Task<ResponseDTO<IEnumerable<ClientOrderDto>>> GetClientOrdersForNameAndId(int? id, int page = 1, int size = 10)
		{
			var client = await this.getClientOrderForNameAndIdCommand.Execute(id,page,size);
			return client.Any() ?
				ResponseStatus.ResponseSucessful<IEnumerable<ClientOrderDto>>(client) :
				ResponseStatus.ResponseWithoutData<IEnumerable<ClientOrderDto>>("No se encontraron clientes");
		}
	}
}
