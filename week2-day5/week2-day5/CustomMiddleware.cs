using System;
using week2_day5.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace  week2_day5.Middleware
{
   public class CustomMiddleware
   {
	private readonly RequestDelegate _next;
		public CustomMiddleware(RequestDelegate next)
		{
			_next = next;
		}
		public async Task InvokeAsync(HttpContext context)
   {
		Console.WriteLine($"Request : before middleware");
		await _next(context);
		Console.WriteLine($"Response : after middleware");
   }
   }
}
