namespace bacics_of_implementation.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public LoggingMiddleware (RequestDelegate next)
        {
            _next = next;   
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("request started");
            await _next(context);
            Console.WriteLine("request finished");
        }
    }
}
