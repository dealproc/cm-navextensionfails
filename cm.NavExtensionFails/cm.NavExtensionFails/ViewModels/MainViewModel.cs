using System.Threading.Tasks;
using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;

namespace cm.NavExtensionFails.ViewModels
{
    public class MainViewModel : Screen
    {
        readonly INavigationService _navigationService;

        public override string DisplayName
        {
            get => "Main view model.";
            set { }
        }

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public Task Navigate() => Task.Run(() =>
        {
            // this is successful.
            Execute.OnUIThread(() => _navigationService.For<SecondViewModel>().Navigate());

            //// this fails.
            //_navigationService.For<SecondViewModel>().Navigate();
        });
    }
}
