using Microsoft.AspNetCore.Mvc;
using Project_IT_kariera.Data;
using Project_IT_kariera.Models;
using Microsoft.EntityFrameworkCore;



namespace Project_IT_kariera.Controllers
{
    public class EventController : Controller
    {
        public readonly EventDbContext eventDbContext;

        public EventController(EventDbContext eventDbContext)
        {
            this.eventDbContext = eventDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var events = await eventDbContext.Events.ToListAsync();
            return View(events);
        }
        [HttpGet]
        public IActionResult Confrim()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ViewTickets()
        {
            var events = await eventDbContext.Events.ToListAsync();
            return View(events);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(UpdateEvent addEventRequest)
        {
            var events = new Event();
            {
                events.Id = Guid.NewGuid();
                events.Name=addEventRequest.Name;
                events.Description=addEventRequest.Description;
                events.Date=addEventRequest.Date; 
            }
            await eventDbContext.Events.AddAsync(events);
            await eventDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid Id)
        {
            var events = await eventDbContext.Events.FirstOrDefaultAsync(x => x.Id == Id);
            if (events.Id != null)
            {
                var ViewModel = new UpdateEvent()
                {
                    Id = events.Id,
                    Name = events.Name,
                    Description = events.Description,
                    Image = events.Image,
                    Date = events.Date
                };
                return await Task.Run(() => View("View", ViewModel));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]

        public async Task<IActionResult> View(UpdateEvent model)
        {
            var projects = await eventDbContext.Events.FindAsync(model.Id);
            if (projects != null)
            {
                projects.Name = model.Name;
                projects.Description = model.Description;
                projects.Date = model.Date;
                projects.Image = model.Image;
               
                await eventDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEvent model)
        {
            var project = await eventDbContext.Events.FindAsync(model.Id);

            if (project != null)
            {
                eventDbContext.Events.Remove(project);
                await eventDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
