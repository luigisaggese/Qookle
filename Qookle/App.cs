using Cirrious.CrossCore.IoC;
using Qookle.ViewModels;

namespace Qookle
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
			RegisterAppStart<MainViewModel>();
        }
    }
}