using backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args); // Membuat instance dari WebApplicationBuilder untuk mengkonfigurasi dan membangun aplikasi web.
ConfigurationManager configuration = builder.Configuration; // Mendapatkan instance dari Configuration yang berisi konfigurasi aplikasi.

// Menambahkan layanan ke kontainer.
builder.Services.AddControllers(); // Menambahkan layanan kontroler untuk menangani permintaan HTTP.
builder.Services.AddEndpointsApiExplorer(); // Menambahkan layanan API Explorer untuk mendokumentasikan API menggunakan Swagger/OpenAPI.
builder.Services.AddScoped<IDataAccessProvider, DataAccessProvider>(); // Menambahkan layanan scoped IDataAccessProvider dengan implementasi DataAccessProvider untuk akses data.
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); // Mengkonfigurasi Swagger/OpenAPI dengan informasi API.
    // konfigurasi lainnya
});

// Mengkonfigurasi DbContext untuk menggunakan SQL Server dengan koneksi yang diambil dari konfigurasi aplikasi.
builder.Services.AddDbContext<DataDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Dev")));

var app = builder.Build(); // Membangun aplikasi web dari konfigurasi yang telah ditentukan.

// Mengkonfigurasi pipeline permintaan HTTP.
if (app.Environment.IsDevelopment()) // Memeriksa apakah aplikasi berjalan dalam lingkungan pengembangan.
{
    app.UseSwagger(); // Menggunakan Swagger untuk menampilkan dokumentasi API.
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Mengalihkan permintaan HTTP ke HTTPS.
app.UseAuthorization(); // Mengaktifkan otentikasi dan otorisasi dalam aplikasi.
app.MapControllers(); // Menyesuaikan rute permintaan HTTP ke kontroler yang sesuai.

app.Run(); // Menjalankan aplikasi web. Setelah ini, aplikasi siap menerima permintaan HTTP dan menanggapinya sesuai dengan konfigurasi yang telah ditentukan.
