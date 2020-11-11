using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShopping.Models;
using MicroShopping.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroShopping.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICreatable<Order> creatable;
        private readonly IDeletable deletable;
        private readonly IUpdatable<Order> updatable;
        private readonly IReadable<Order> readable;

        public OrderController(ICreatable<Order> _creatable, IDeletable _deletable, IUpdatable<Order> _updatable, IReadable<Order> _readable)
        {
            
            creatable = _creatable;
            deletable = _deletable;
            updatable = _updatable;
            readable = _readable;

        }

        public IActionResult Index()
        {
            return View(readable.GetAll());
        }
      
        public IActionResult GetOne(int Id)
        {
            return View(readable.GetDetails(Id));
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int Id)
        {
            return View(deletable.Delete(Id));
        }
        [Authorize(Roles = "Customer")]
        public IActionResult AddOrder()
        {
            return View(new Order());
        }
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public IActionResult AddOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    creatable.Add(order);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(order);
                }
            }
            return View(order);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult EditOrder(int orderid)
        {
            return View(readable.GetDetails(orderid));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult EditOrder(int Id, Order order)
        {
            updatable.Update(Id, order);
            return RedirectToAction("Index");
        }



    }
}
