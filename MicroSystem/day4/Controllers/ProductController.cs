using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShopping.Hubs;
using MicroShopping.Models;
using MicroShopping.Services;
using MicroShopping.Services;
using MicroShopping.Services.Interface;
using MicroShopping.ViewsModel;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroShopping.Controllers
{
    public class ProductController : Controller
    {
        
        private readonly ICreatable<Product> creatable;
        private readonly IDeletable  deletable;
        private readonly IUpdatable<Product> updatable; 
        private readonly IReadable<Product> readable;
        private readonly ISaveChange saveChange;

        


        public ProductController(ISaveChange _saveChange, ICreatable<Product> _creatable,IDeletable _deletable,IUpdatable<Product> _updatable, IReadable<Product> _readable)
        {
            //productService = _productService;
            //review_RatingService = _review_RatingService;
            creatable = _creatable;
            deletable = _deletable;
            updatable = _updatable;
            readable = _readable;
            saveChange = _saveChange;

        }
        
        public IActionResult Index()
        {
            return View(readable.GetAll());
        }

        public IActionResult GetOne(int Id)
        {
            return View(readable.GetDetails(Id));
        }
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public IActionResult Delete(int Id)
        {
            return View(deletable.Delete(Id));
        }
       [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public IActionResult AddProduct()
        {
            return View(new Product());
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    creatable.Add(product);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(product);
                }
            }
            return View(product);
        }
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public ActionResult EditProducts(int productid)
        {
            return View(readable.GetDetails(productid));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public ActionResult EditProducts(int Id , Product product)
        {
            updatable.Update(Id , product);
            return RedirectToAction("Index");
        }


        ///////////////////////////////////
        ///
        //[HttpPost]
        //public ActionResult AddToCartfromcart(int productid)
        //{
            
            
      

        //var name = HttpContext.Session.GetString(SessionKeyName);
        //var age = HttpContext.Session.GetInt32(SessionKeyAge);
        //    if (Session["cart"] == null)
        //    {
        //        List<Item> cart = new List<Item>();
        //        var prod = readable.GetDetails(productid);

        //        cart.Add(new Item
        //        {
        //            Product = prod,
        //            Quantity = 1
        //        });
           
        //    }
        //    else
        //    {
                
        //        var prod = readable.GetDetails(productid);
        //        foreach (var item in cart.ToArray())
        //        {
        //            int prevQty = item.Quantity;
        //            if (item.Product.ID == productid)
        //            {
        //                cart.Remove(item);
        //                cart.Add(new Item
        //                {
        //                    Product = prod,
        //                    Quantity = prevQty + 1
        //                });
        //                break;
        //            }
        //            else
        //            {
        //                cart.Add(new Item
        //                {
        //                    Product = prod,
        //                    Quantity = 1
        //                });
        //            }
        //            break;
        //        }
        //        readable.GetAll().FirstOrDefault(d => d.ID == productid).Quantity = readable.GetAll().FirstOrDefault(d => d.ID == productid).Quantity - 1;
        //        saveChange.Save();
        //        Session["cart"] = cart;
        //    }

        //    return RedirectToAction("cartDetail");
        //}

        //public ActionResult cartDetail()
        //{
        //    return View((List<Item>)Session["cart"]);
        //}

        //[Authorize]
        //[HttpPost]
        //public ActionResult AddToCart(int productid)
        //{
        //    if (Session["cart"] == null)
        //    {
        //        List<Item> cart = new List<Item>();
        //        var prod = readable.GetDetails(productid);
        //            readable.GetAll().FirstOrDefault(d => d.ID == productid).Quantity = context.Products.FirstOrDefault(d => d.ID == productid).Quantity - 1;
        //        saveChange.Save();
        //        cart.Add(new Item
        //        {
        //            Product = prod,
        //            Quantity = 1
        //        });
        //        Session["cart"] = cart;
        //    }
        //    else
        //    {
        //        List<Item> cart = new List<Item>();
        //        var prod = readable.GetDetails(productid);
        //        bool isfound = false;
        //        foreach (var item in cart)
        //        {
        //            if (item.Product.ID == productid)
        //            {
        //                int preQty = item.Quantity;
        //                cart.Remove(item);
        //                cart.Add(new Item()
        //                {
        //                    Product = prod
        //                    ,
        //                    Quantity = preQty + 1
        //                });
        //                isfound = true;
        //                break;
        //            }
        //        }
        //        if (isfound == false)
        //        {
        //            cart.Add(new Item()
        //            {
        //                Product = prod
        //                ,
        //                Quantity = 1
        //            });
        //        }
        //        readable.GetAll().FirstOrDefault(d => d.ID == productid).Quantity = readable.GetAll().FirstOrDefault(d => d.ID == productid).Quantity - 1;
        //        ;
        //        Session["cart"] = cart;
        //    }
        //    IHubContext hubContext =
        //          GlobalHost.ConnectionManager.GetHubContext<ProductsHub>();
        //    hubContext.Clients.All.ReceiveChanges(productid, readable.GetAll().FirstOrDefault(p => p.ID == productid).Quantity);

        //    return Redirect("Index");
        //}


        //public ActionResult RemoveFromCart(int productid)
        //{
        //    List<Item> cart = (List<Item>)Session["cart"];

        //    foreach (var item in cart)
        //    {
        //        if (item.Product.ID == productid)
        //        {
        //            readable.GetAll().FirstOrDefault(d => d.ID == productid).Quantity = readable.GetAll().FirstOrDefault(d => d.ID == productid).Quantity + item.Quantity;
        //            saveChange.Save();
        //            cart.Remove(item);
        //            break;
        //        }
        //    }
        //    IHubContext hubContext =
        //         GlobalHost.ConnectionManager.GetHubContext<ProductsHub>();
        //    hubContext.Clients.All.ReceiveChanges(productid, readable.GetAll().FirstOrDefault(p => p.ID == productid).Quantity);

        //    Session["cart"] = cart;
        //    return Redirect("cartDetail");
        //}


        //public ActionResult DecreaseQty(int productid)
        //{
        //    if (Session["cart"] != null)
        //    {
        //        List<Item> cart = (List<Item>)Session["cart"];
        //        var prod = readable.GetAll().Find(productid);
        //        foreach (var item in cart)
        //        {
        //            if (item.Product.ID == productid)
        //            {
        //                int prevQty = item.Quantity;
        //                if (prevQty > 0)
        //                {
        //                    cart.Remove(item);
        //                    cart.Add(new Item
        //                    {
        //                        Product = prod,
        //                        Quantity = prevQty - 1
        //                    });
        //                }
        //                else if (prevQty < 1)
        //                {
        //                    cart.Remove(item);
        //                }
        //                break;
        //            }
        //        }
        //        Session["cart"] = cart;
        //    }
        //    return Redirect("cartDetail");
        //}


    }
}
