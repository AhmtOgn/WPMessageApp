using Microsoft.EntityFrameworkCore;
using WPMessageApp.Models; //in order to use Message class

namespace WPMessageApp.Data
{
    // WpDbContext must take inheritence from DbContext in order to use EF Core 
    public class WpDbContext : DbContext
    {
        // It is a constructor that specifes to take options from outside (program.cs) 
        public WpDbContext(DbContextOptions<WpDbContext> options) : base(options)
        {

        }


        /* Database tables */

        //It is create a table in database in the name of `Messages` 
        //Afterwards we can call with this name in our controllers  
        public DbSet<Message> Messages { get; set; }

        /*
        "ConnectionStrings": {
        "DefaultConnection": "DataSource=Data/messages.db" }
    
         * Açıklama:
         * "DefaultConnection": Bağlantı dizesine verdiğimiz isimdir. Program.cs'te bu isimle çağıracağız.
         * "DataSource=Data/messages.db": SQLite'a diyoruz ki,
         * "messages.db" adında bir veritabanı dosyasını
         * projenin ana klasöründeki "Data" klasöründe ara.
         * Eğer dosya yoksa, EF Core ilk çalıştırmada bu dosyayı oluşturacaktır.
         */
    


    }
}