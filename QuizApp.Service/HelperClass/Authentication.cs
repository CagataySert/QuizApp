using QuizApp.Service.Models;
using QuizApp.Service.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.Service.HelperClass
{
    public static class Authentication
    {
        public static CategoryResponse CheckAuthentication(string email , string password)
        {
            CategoryResponse response;
            if (email != "admin@gmail.com" || password != "123123")
            {
                return response = new CategoryResponse()
                {
                    status = new Models.Attribute.Status()
                    {
                        Code = (int)Enums.MessageCode.LoginError,
                        Message = Enums.MessageCode.LoginError.ToString()
                    }
                };
            }
            else
            {
                return null;
            }
        }
    }
}