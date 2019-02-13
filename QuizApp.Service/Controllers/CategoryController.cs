using QuizApp.Interfaces.CategoryService;
using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuizApp.Service.Controllers
{
    [Authorize]
    public class CategoryController : ApiController
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IHttpActionResult GetAll()
        {
            List<Category> categories = _categoryService.GetAll();
            return Ok(categories);
        }

        public IHttpActionResult GetById(int _id)
        {
            Category category = _categoryService.GetById(_id);
            if (category == null)
            {
                return BadRequest("The entity could not be found by id");
            }
            else
            {
                return Ok(category);
            }
        }

        [HttpPost]
        public IHttpActionResult AddCategory([FromBody]Category entity)
        {
            bool isAdded = _categoryService.AddOrUpdate(entity);
            if (isAdded)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateCategory([FromBody]Category entity)
        {
            bool isUpdated = _categoryService.AddOrUpdate(entity);
            if (isUpdated)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeletedCategory(int _id)
        {
            bool isDeleted = _categoryService.Delete(_id);
            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
