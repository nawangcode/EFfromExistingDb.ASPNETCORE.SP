using EFfromExistingDb.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFfromExistingDb.Controllers
{
    public class EventsController : Controller
    {
        private r5logContext _context;

        public EventsController(r5logContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.tbEvent.ToList());
        }

        public IActionResult Create()
        {
            return View(_context.FindEvents(1));
        }

        public IActionResult Less()
        {
            var myResults =
                    (
                        from x in _context.FindEvents(1)
                        select new tbEvent_Display
                        {
                            idEvent = x.idEvent,
                            dtLogged = x.dtLogged,
                            idLevel = x.idLevel,
                            idMachine = x.idMachine,
                            sMessage = x.sMessage
                        }
                    ).ToList();
            return View(myResults);
            //return View(_context.FindEvents(1).Select(x => new tbEvent_Display
            //{
            //    idEvent = x.idEvent,
            //    dtLogged = x.dtLogged,
            //    idLevel = x.idLevel,
            //    idMachine = x.idMachine,
            //    sMessage = x.sMessage
            //}));
        }

    }
}
