using MvvmCross.IoC;
using MvvmCross.ViewModels;
using GoogleBooksChallenge.Core.ViewModels.Home;

namespace GoogleBooksChallenge.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<HomeViewModel>();
        }
    }
}
