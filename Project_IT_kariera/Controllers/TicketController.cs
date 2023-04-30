using Microsoft.AspNetCore.Mvc;
using Project_IT_kariera.Data;
using Project_IT_kariera.Controllers;
using System;
using Microsoft.EntityFrameworkCore;

namespace Project_IT_kariera.Controllers
{
    public class TicketController : Controller
    {
        private readonly TicketDbContext ticketDbContext;

        public TicketController(TicketDbContext ticketDbContext)
        {
            this.ticketDbContext = ticketDbContext;
        }
        
       
    }
}

