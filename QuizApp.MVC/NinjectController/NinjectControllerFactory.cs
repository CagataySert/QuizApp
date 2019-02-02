using Ninject;
using QuizApp.BLL.Concrete.AnswerManager;
using QuizApp.BLL.Concrete.CategoryManager;
using QuizApp.BLL.Concrete.QuestionManager;
using QuizApp.DAL.Concrete.EntityFramework;
using QuizApp.Interfaces.AnswerService;
using QuizApp.Interfaces.CategoryService;
using QuizApp.Interfaces.QuestionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuizApp.MVC.NinjectController
{
    public class NinjectControllerFactory: DefaultControllerFactory
    {
        private readonly IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBllBindings();
        }

        private void AddBllBindings()
        {
            ninjectKernel.Bind<ICategoryService>()
                .To<CategoryManager>()
                .WithConstructorArgument("categoryDal",EfCategoryDal.CreateAsSingleton());

            ninjectKernel.Bind<IAnswerService>()
                .To<AnswerManager>()
                .WithConstructorArgument("efAnswerDal", EfAnswerDal.CreateAsSingleton());

            ninjectKernel.Bind<IQuestionService>()
                .To<QuestionManager>()
                .WithConstructorArgument("efQuestionDal", EfQuestionDal.CreateAsSingleton());
        }

        protected override IController GetControllerInstance(RequestContext requestContext,Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
    }
}