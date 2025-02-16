using System.Net;

namespace Codifico.Model.Dto
{
	public class ResponseDTO<T>
	{
		public List<string> Error { get; set; }

		public string Message { get; set; }

		public HttpStatusCode StatusCode { get; set; }

		public T Data { get; set; }
	}
}
