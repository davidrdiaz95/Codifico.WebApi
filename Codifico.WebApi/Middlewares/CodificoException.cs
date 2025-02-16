using System.Runtime.Serialization;

namespace Codifico.WebApi.Middlewares
{
	public class CodificoException : Exception
	{
		public List<string> Errores { get; set; } = new List<string>();


		public CodificoException()
		{
		}

		public CodificoException(string message)
			: base(message)
		{
			Errores.Add(message);
		}

		public CodificoException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected CodificoException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
