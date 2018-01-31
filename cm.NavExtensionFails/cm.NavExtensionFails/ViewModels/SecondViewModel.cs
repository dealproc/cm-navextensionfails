using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;

namespace cm.NavExtensionFails.ViewModels
{
    public class SecondViewModel : Screen
    {
        readonly INavigationService _navigationService;

        public override string DisplayName
        {
            get => "Second view model.";
            set { }
        }

        public SecondViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void Navigate() => _navigationService.For<ThirdViewModel>().Navigate();
    }
}
