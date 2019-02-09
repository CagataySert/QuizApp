using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace QuizApp.Service.Models
{
    public class Enums
    {
        public enum MessageCode
        {
            [Description("Process is successful")]
            Successful = 100,

            [Description("Process is unsuccessful")]
            Unsuccessful = 200,

            [Description("An error is occured.")]
            Error = 300,

            [Description("Check your informations please.")]
            LoginError = 400
        }
    }
}