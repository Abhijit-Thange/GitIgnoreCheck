using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.Models;

namespace CRUD_Operations_Product_and_Category.Controllers
{
    public class CategoryController : Controller
    {
        private DataManager db = new DataManager();

        // GET: Category
        public async Task<ActionResult> GetCategoryIndex()
        {
           // var data = await db.Database.SqlQuery<Category>($"getCategoryDataWithPageSize @Page,@Size",);
            var data = await db.Categories.ToListAsync();
            return View(data);
        }

        public async Task<ActionResult> CategoryDetails(int? id)
        {
            var category = await db.Categories.FirstOrDefaultAsync(x=>x.CategoryId==id);
            if (category == null)
            {
                ViewBag.ErrorMessage = "Given Id is Not in Record...";
                return View();
            }
            return View(category);
        }

        public ActionResult CreateCategory()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                await db.SaveChangesAsync();
                return RedirectToAction("GetCategoryIndex");
            }

            return View(category);
        }

        public async Task<ActionResult> EditCategory(int? id)
        {
           
            Category category = await db.Categories.FirstOrDefaultAsync(c=>c.CategoryId==id);
            if (category == null)
            {
                return View();
            }
            return View(category);
        }

        [HttpPost]
        public async Task<ActionResult> EditCategory(int CategoryId,Category category)
        {
            if (ModelState.IsValid)
            {
               var data=await db.Categories.FirstOrDefaultAsync(c=>c.CategoryId==CategoryId);
                if (data != null)
                {
                    data.CategoryId=category.CategoryId;
                    data.CategoryName=category.CategoryName;
                    await db.SaveChangesAsync();
                    return RedirectToAction("GetCategoryIndex");
                }
                
            }
            return View(category);
        }

        public async Task<ActionResult> DeleteCategory(int id)
        {
            var category = await db.Categories.FindAsync(id);
           
            return View(category);
        }

        [HttpPost, ActionName("DeleteCategory")]
        public async Task<ActionResult> Delete(int id)
        {
            Category category = await db.Categories.FindAsync(id);
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
            return RedirectToAction("GetCategoryIndex");
        }

        public async Task<ActionResult> ActivateCategory(int id)
        {
            var category =await db.Categories.FindAsync(id);
            category.IsActive = true;
           await db.SaveChangesAsync();
            return RedirectToAction("GetCategoryIndex");
        }

        public async Task<ActionResult> DeactivateCategory(int id)
        {
            var category =await db.Categories.FindAsync(id);
            category.IsActive = false;
           await db.SaveChangesAsync();
            return RedirectToAction("GetCategoryIndex"); 
        }

    }
}
