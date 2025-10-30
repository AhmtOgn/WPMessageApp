using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WPMessageApp.Models;
using WPMessageApp.Data;

public class MessageController : Controller
{
    private readonly WpDbContext _context;

    public MessageController(WpDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // _context.Messages: DB Context üzerinden Messages tablosuna erişiriz.
        // ToListAsync(): Tüm kayıtları çeker. (await kullanıldığı için asenkron çalışır.)
        var messages = await _context.Messages.ToListAsync();

        // Veriyi (messages) View'e göndeririz.
        return View(messages);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Message message)
    {
        if (ModelState.IsValid)
        {
            // Kullanıcıdan gelen bazı değerleri override etme (Bot için kritik!)
            message.Status = "Pending";
            message.CreatedAt = DateTime.Now;

            // Veriyi veritabanına ekle
            _context.Add(message);

            // Veritabanına kaydı kesinleştir
            await _context.SaveChangesAsync();

            // Başarılı kayıttan sonra kullanıcıyı listeleme sayfasına yönlendir.
            return RedirectToAction(nameof(Index));
        }

        return View(message);
    }
}

