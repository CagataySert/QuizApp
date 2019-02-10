using QuizApp.Service.Models;
using QuizApp.Service.Models.Response;
using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using static QuizApp.Service.Models.Enums;

namespace QuizApp.Service.HelperClass
{
    public static class CreateResponse
    {
        public static CategoryResponse ReturnResponse(Category _category)
        {
            CategoryResponse response;
            if (_category != null)
            {
                return response = new CategoryResponse()
                {
                    status = new Models.Attribute.Status()
                    {
                        Code = (int)MessageCode.Successful,
                        Message = GetDescriptionOfEnum(MessageCode.Successful)
                    },
                    category = _category
                };
            }
            else
            {
                return response = new CategoryResponse()
                {
                    status = new Models.Attribute.Status()
                    {
                        Code = (int)MessageCode.Error,
                        Message = GetDescriptionOfEnum(MessageCode.Unsuccessful)
                    }
                };
            }
        }

        public static CategoryResponse ReturnResponse(List<Category> _categories)
        {
            CategoryResponse response;
            if (_categories != null)
            {
                return response = new CategoryResponse()
                {
                    status = new Models.Attribute.Status()
                    {
                        Code = (int)MessageCode.Successful,
                        Message = GetDescriptionOfEnum(MessageCode.Successful)
                    },
                    categories = _categories
                };
            }
            else
            {
                return response = new CategoryResponse()
                {
                    status = new Models.Attribute.Status()
                    {
                        Code = (int)MessageCode.Error,
                        Message = GetDescriptionOfEnum(MessageCode.Unsuccessful)
                    }
                };
            }
        }

        private static string GetDescriptionOfEnum(MessageCode enums)
        {
            System.Reflection.FieldInfo fieldInfo = enums.GetType().GetField(enums.ToString());
            DescriptionAttribute[] descriptionAttributes = (DescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enums.ToString();
        }
    }
}