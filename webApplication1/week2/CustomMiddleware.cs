//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;

//public class CustomMiddleware
//{
//    private readonly RequestDelegate _next;

//    public CustomMiddleware(RequestDelegate next)
//    {
//        _next = next;
//    }

//    public async Task InvokeAsync(HttpContext context)
//    {
//        await context.Response.WriteAsync("Hello World");
//        await _next(context);
//        await context.Response.WriteAsync("hello world after middleware");
//    }
//}