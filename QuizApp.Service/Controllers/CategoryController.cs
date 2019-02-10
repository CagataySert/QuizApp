using QuizApp.Interfaces.CategoryService;
using QuizApp.Service.HelperClass;
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

        public CategoryResponse GetAll([FromBody] CategoryRequest categoryRequest)
        {
            CategoryResponse response;
            try
            {
                CategoryResponse Authenticated = Authentication.CheckAuthentication(categoryRequest.Authentication.Email, categoryRequest.Authentication.Password);
                if (Authenticated != null)
                {
                    return Authenticated;
                }

                List<Category> _categories = _categoryService.GetAll();
                return CreateResponse.ReturnResponse(_categories);
            }
            catch (Exception exception)
            {

                return response = new CategoryResponse()
                {
                    status = new Models.Attribute.Status()
                    {
                        Code = (int)Enums.MessageCode.Error,
                        Message = Enums.MessageCode.Error.ToString() + exception.Message
                    }
                };
            }
        }

        public CategoryResponse GetCategoryById([FromBody] CategoryRequest categoryRequest)
        {
            CategoryResponse response;
            try
            {
                CategoryResponse Authenticated = Authentication.CheckAuthentication(categoryRequest.Authentication.Email, categoryRequest.Authentication.Password);
                if (Authenticated != null)
                {
                    return Authenticated;
                }

                Category _category = _categoryService.GetById(categoryRequest.Category.Id);
                return CreateResponse.ReturnResponse(_category);
            }
            catch (Exception exception)
            {

                return response = new CategoryResponse()
                {
                    status = new Models.Attribute.Status()
                    {
                        Code = (int)Enums.MessageCode.Error,
                        Message = Enums.MessageCode.Error.ToString() + exception.Message
                    }
                };
            }
        }

        [HttpPost]
        public CategoryResponse AddCategory([FromBody] CategoryRequest categoryRequest)
        {
            CategoryResponse response;
            try
            {
                CategoryResponse Authenticated = Authentication.CheckAuthentication(categoryRequest.Authentication.Email, categoryRequest.Authentication.Password);
                if (Authenticated != null)
                {
                    return Authenticated;
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
                        status = new Models.Attribute.Status()
                        {
                            Code = (int)Enums.MessageCode.Successful,
                            Message = Enums.MessageCode.Successful.ToString()
                        },
                    };
                }
                else
                {
                    return response = new CategoryResponse()
                    {
                        status = new Models.Attribute.Status()
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
                    status = new Models.Attribute.Status()
                    {
                        Code = (int)Enums.MessageCode.Error,
                        Message = Enums.MessageCode.Error.ToString() + exception.Message
                    }
                };
            }
        }
    }
}
