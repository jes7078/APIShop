using System.Linq;
using Microsoft.AspNetCore.Mvc;
using APIShop.Models;

namespace APIShop.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ItemController : ControllerBase
  {
    [HttpGet]
    public ActionResult GetAllItems()
    {
      var db = new DatabaseContext();
      return Ok(db.Items);
    }

    [HttpGet("{id}")]
    public ActionResult GetOneItem(int id)
    {
      var db = new DatabaseContext();
      var item=db.Items.FirstOrDefault(it=>it.Id == id);
      if (item == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(item);
      }
    }

    [HttpPost]
    public ActionResult CreateItem(Item item)
    {
      var db = new DatabaseContext();
      db.Items.Add(item);
      db.SaveChanges();
      return Ok(item);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateItem(int id, Item item)
    {
      var db= new DatabaseContext();
      var prevItem = db.Items.FirstOrDefault(it=>it.Id==id);
      if (prevItem==null)
      {
        return NotFound();
      }
      else
      {
        prevItem.SKU=item.SKU;
        prevItem.Name=item.Name;
        prevItem.ShortDescription=item.ShortDescription;
        prevItem.NumberInStock=item.NumberInStock;
        prevItem.Price=item.Price;
        prevItem.DateOrdered=item.DateOrdered;
        db.SaveChanges();
        return Ok(prevItem);
      }
    }

  [HttpDelete("{id}")]
  public ActionResult DeleteItem(int id)
  {
    var db = new DatabaseContext();
    var item = db.Items.FirstOrDefault(it=>it.Id==id);
    if (item==null)
    {
      return NotFound();
    }
    else
    {
db.Items.Remove(item);
db.SaveChanges();
return Ok();
    }
  }

 
  
[HttpGet("outofstock")]
    public ActionResult GetOutOfStockItems()
    {
      var db = new DatabaseContext();
      var nin = db.Items.Where(it=>it.NumberInStock==0);
      if (nin==null)
      {
        return NotFound();
      }
      else 
      {
      return Ok(nin);
      }
    }

    [HttpGet("getsku/{sku}")]
    public ActionResult GetSKU(string SKU)
    {
      var db = new DatabaseContext();
      var skusearch = db.Items.FirstOrDefault(it=>it.SKU==SKU);
      if (skusearch==null)
      {
        return NotFound();
      }
      else
      {
        return Ok(skusearch);
      }
      
    }










  }
}
