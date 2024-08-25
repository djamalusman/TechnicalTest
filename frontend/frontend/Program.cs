namespace frontend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Tambahkan layanan ke container.
            builder.Services.AddControllersWithViews();

            // Tambahkan HttpClient ke layanan DI
            builder.Services.AddHttpClient();

            // Tambahkan layanan sesi
            builder.Services.AddDistributedMemoryCache(); // Menyimpan data sesi dalam memori
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Atur waktu habis sesi
                options.Cookie.HttpOnly = true; // Untuk keamanan
                options.Cookie.IsEssential = true; // Harus disertakan dalam cookie
            });

            var app = builder.Build();

            // Konfigurasi pipeline permintaan HTTP.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Tambahkan middleware sesi sebelum middleware otorisasi
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
