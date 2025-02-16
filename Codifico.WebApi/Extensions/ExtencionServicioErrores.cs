using Codifico.WebApi.Middlewares;

namespace Codifico.WebApi.Extensions
{
	public static class ExtencionServicioErrores
	{
		public static void UseErrorHanldinMiddleware(this IApplicationBuilder app)
		{
			app.UseMiddleware<ErrorHandlerMiddleware>(Array.Empty<object>());
		}
	}
}
