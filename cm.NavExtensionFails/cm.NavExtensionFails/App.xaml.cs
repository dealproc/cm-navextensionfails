using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;

using Xamarin.Forms;

namespace cm.NavExtensionFails
{
    public partial class App : FormsApplication
    {
        SimpleContainer _container;

        public App(SimpleContainer container)
        {
            InitializeComponent();

            _container = container;

            _container.PerRequest<ViewModels.MainViewModel>();
            _container.PerRequest<ViewModels.SecondViewModel>();
            _container.PerRequest<ViewModels.ThirdViewModel>();

            DisplayRootView<Views.MainView>();
        }

        protected override void PrepareViewFirst(NavigationPage navigationPage)
        {
            var navService = new NavigationPageAdapter(navigationPage);

            _container.Instance<INavigationService>(navService);
        }
    }
}
