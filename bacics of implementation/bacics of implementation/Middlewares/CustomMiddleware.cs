using bacics_of_implementation.Service;

namespace bacics_of_implementation.Middlewares
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IDetailsService detailsService)
        {
            var user = detailsService.GetDetailsAsync();
            Console.WriteLine("custom middleware");
            await _next(context);
        }
    }
}
