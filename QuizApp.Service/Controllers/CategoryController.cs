using QuizApp.Interfaces.CategoryService;
using QuizApp.Service.Models;
using QuizApp.Service.Models.Request;
using QuizApp.Service.Models.Response;
using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuizApp.Service.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public string GetAll()
        {
            return "ÇALIŞTI";
        }

        public Category GetCategory(int _id)
        {
            return _categoryService.GetById(_id);
        }

        [HttpPost]
        public CategoryResponse AddCategory([FromBody] CategoryRequest categoryRequest)
        {
            CategoryResponse response;
            try
            {
                if (categoryRequest.Authentication.Email != "admin@gmail.com" || categoryRequest.Authentication.Password != "123123")
                {
                    response = new CategoryResponse()
                    {
                        Status = new Models.Attribute.Status()
                        {
                            Code = (int)Enums.MessageCode.LoginError,
                            Message = Enums.MessageCode.LoginError.ToString()
                        }
                    };
                }

                bool isAdded = _categoryService.AddOrUpdate(new Category()
                {
                    Id = categoryRequest.Category.Id,
                    Level = categoryRequest.Category.Level,
                    Name = categoryRequest.Category.Name,
                    Questions = categoryRequest.Category.Questions
                });

                if (isAdded)
                {
                    return response = new CategoryResponse()
                    {
                        Status = new Models.Attribute.Status()
                        {
                            Code = (int)Enums.MessageCode.Successful,
                            Message = Enums.MessageCode.Successful.ToString()
                        },
                        CategoryId = 1
                    };
                }
                else
                {
                    return response = new CategoryResponse()
                    {
                        Status = new Models.Attribute.Status()
                        {
                            Code = (int)Enums.MessageCode.Error,
                            Message = Enums.MessageCode.Error.ToString()
                        }
                    };
                }
            }
            catch (Exception exception)
            {
                return response = new CategoryResponse()
                {
                    Status = new Models.Attribute.Status()
                    {
                        Code = (int)Enums.MessageCode.Error,
                        Message = Enums.MessageCode.Error.ToString()+exception.Message
                    }
                };
            }
        }
    }
}
