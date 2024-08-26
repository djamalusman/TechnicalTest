using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace frontend.Middlewares
{
    public class SessionValidationMiddleware
{
    private readonly RequestDelegate _next;

    public SessionValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var userName = context.Session.GetString("UserName");

        // Cek apakah request adalah untuk halaman login atau operasi login
        if (string.IsNullOrEmpty(userName) && !context.Request.Path.Value.Contains("Login"))
        {
            // Jika userName tidak ada di sesi dan bukan halaman login, redirect ke login
            context.Response.Redirect("/Home/Login");
            return;
        }

        // Melanjutkan ke middleware berikutnya
        await _next(context);
    }
}

}
