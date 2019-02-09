using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using QuizApp.BLL.Concrete.AnswerManager;
using QuizApp.BLL.Concrete.CategoryManager;
using QuizApp.BLL.Concrete.QuestionManager;
using QuizApp.DAL.Concrete.EntityFramework;
using QuizApp.Interfaces.AnswerService;
using QuizApp.Interfaces.CategoryService;
using QuizApp.Interfaces.QuestionService;
using System;
using System.Web;

//https://github.com/SkydivingAngel/Ninject-WebApi-2-and-Mvc5

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(QuizApp.Service.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(QuizApp.Service.NinjectWebCommon), "Stop")]

namespace QuizApp.Service
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICategoryService>()
                    .To<CategoryManager>()
                    .WithConstructorArgument("categoryDal", EfCategoryDal.CreateAsSingleton());

            kernel.Bind<IAnswerService>()
                .To<AnswerManager>()
                .WithConstructorArgument("efAnswerDal", EfAnswerDal.CreateAsSingleton());

            kernel.Bind<IQuestionService>()
                .To<QuestionManager>()
                .WithConstructorArgument("efQuestionDal", EfQuestionDal.CreateAsSingleton());
        }
    }
}