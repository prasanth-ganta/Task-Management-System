
public class CustomAuthenticationMiddleware
{
    private RequestDelegate _next;
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

       
   
    }
 
}
 