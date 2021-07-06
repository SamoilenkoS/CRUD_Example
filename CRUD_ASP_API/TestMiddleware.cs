using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CRUD_ASP_API
{
  public class TestMiddleware
  {
    private readonly RequestDelegate _next;

    public TestMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    // IMyScopedService is injected into Invoke
    public async Task Invoke(HttpContext httpContext)
    {
      httpContext.Response.Redirect("http://www.google.com");
      
      await _next(httpContext);
    }
  }
}
