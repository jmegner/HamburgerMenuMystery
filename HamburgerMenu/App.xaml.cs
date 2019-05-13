using Xamarin.Forms;
using Prism.Ioc;
using HamburgerMenu.Services;
using HamburgerMenu.Views;
using Prism.Logging;
using DryIoc;

namespace HamburgerMenu
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
        }

        public static new App Current
        {
            get { return Application.Current as App; }
        }

        #if false
        public new ILoggerFacade Logger
        {
            get { return base.Logger; }
        }
        #endif

        protected override void OnInitialized()
        {
            //NavigationService.NavigateAsync( "Navigation/Login" );
            NavigationService.NavigateAsync("/Index/Navigation/ViewA?message=InitialNav");
            //NavigationService.NavigateAsync("/Navigation/Index/ViewA?message=InitialNav");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>( "Navigation" );
            containerRegistry.RegisterForNavigation<MainPage>( "Index" );
            containerRegistry.RegisterForNavigation<LoginPage>( "Login" );
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewB>();
            containerRegistry.RegisterForNavigation<ViewC>();

            containerRegistry.RegisterSingleton<IAuthenticationService, AuthenticationService>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
