using front_to_back.DAL;
using front_to_back.ViewModels.Contact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace front_to_back.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ContactController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var contactComponent = await _appDbContext.ContactComponent.FirstOrDefaultAsync();
            var contactMainComponent = await _appDbContext.ContactMainComponent.FirstOrDefaultAsync();
            var contactCommunucationComponent = await _appDbContext.ContactCommunucationComponents.ToListAsync();
            var model = new ContactIndexViewModel
            {
                ContactComponent = contactComponent,
                ContactMainComponent = contactMainComponent,
                ContactCommunucationComponent = contactCommunucationComponent,
            };

            return View(model);
        }
    }
}