public class CustomAuthenticationMiddleware
{
    private RequestDelegate _next;
    public IConfiguration _configuration;
    public CustomAuthenticationMiddleware(RequestDelegate next)
    {
        _next=next;
    }
    public async Task Invoke(HttpContext context)
    {
        if(context.Request.Path.StartsWithSegments(""))
        {
          await _next(context); 
        }
        if(_configuration["KeyToLogin"]==""){
            context.Response.StatusCode = 401;
            context.Response.WriteAsync("User didnt Login");
            return;
        } 
    }
}
 