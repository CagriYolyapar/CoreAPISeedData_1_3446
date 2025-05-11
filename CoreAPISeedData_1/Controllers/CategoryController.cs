using CoreAPISeedData_1.Models.Categories.RequestModels;
using CoreAPISeedData_1.Models.Categories.ResponseModels;
using CoreAPISeedData_1.Models.ContextClasses;
using CoreAPISeedData_1.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoreAPISeedData_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly MyContext _context;

        public CategoryController(MyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            //Category c = new Category()
            //{
            //    CategoryName = "Deneme",
            //    Description = "Test"
            //};

            //CategoryResponseModel cRModel = new CategoryResponseModel();

            //cRModel.CategoryName = c.CategoryName;
            //cRModel.Description = c.Description;


          List<CategoryResponseModel> categories = await _context.Categories.Select(x => new CategoryResponseModel
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToListAsync();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {


            CategoryResponseModel? category = _context.Categories.Where(x => x.Id == id).Select(x => new CategoryResponseModel
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).FirstOrDefault();

            if(category == null)  return Ok("Kategori bulunamadı");
            

            //CategoryResponseModel? category = _context.Categories.Select(x => new CategoryResponseModel
            //{
            //    Id = x.Id,
            //    CategoryName = x.CategoryName,
            //    Description = x.Description
            //}).FirstOrDefault(x => x.Id == id);

            return Ok(category);
        }

        //Kategori ekleme

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryRequestModel category)
        {
            Category c = new Category()
            {
                CategoryName = category.CategoryName,
                Description = category.Description
            };

            _context.Categories.Add(c);
            _context.SaveChanges();
            return Ok($"{category.CategoryName} eklendi");
        }

        //Kategori Güncelleme
    }
}
