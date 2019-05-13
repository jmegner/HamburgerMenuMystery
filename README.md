# Hamburger Menu Mystery
Altered HamburgerMenu project from Prism-Samples-Forms repo for the purpose of understanding navigation stack manipulation.

Notable alterations:

* skipping of login page stuff

* ViewA through ViewB display...

    * The `message` navigation parameter

    * `_navigationService.GetNavigationUriPath()`

    * a string version of Navigation.NavigationStack and Navigation.ModalStack, separated by a semicolon

* More navigation buttons in MainPage's master page.

Current questions I have...

* What exactly happens when you do a NavigationService.NavigateAsync("NavigationPage/SomeContentPage")? It causes you do navigate to SomeContentPage that is wrapped in a NavigationPage (so you get navigation icon, title, and toolbar items shown), right?

* App.xaml.cs navigates to "/Index/Navigation/ViewA?message=InitialNav" ("Index" is an alias for MainPage)

    * In ViewAViewModel, Prism's `_navigationService.GetNavigationUriPath()` returns "/Navigation/ViewA"; where did "/Index" go?

    * In ViewA.xaml.cs, Xamarin's Navigation.NavigationStack is "/ViewA" (and the ModalStack is empty); where did "/Index" go?  Why does the Xamarin NavigationStack differ from Prism's GetNavigationUriPath?

* If you then click the hamburger icon so you get the MainPage master page, and click the "N/A" button so MainPageViewModel does a `_navigationService.NavigateAsync("Navigation/ViewA?message=NA")`...

    * Prism's GetNavigationUriPath returns "/Index/Navigation/ViewA"; why does "Index" appear now and not before?
* If you then click the hamburger icon and then click the "N/B" button, so the MainPageViewModel does a `_navigationService.NavigateAsync("Navigation/ViewB?message=NB")`...

    * Prism's GetNavigationUriPath returns "/Index/Navigation/ViewA/Navigation?useModalNavigation=true/ViewB"; why the `useModalNavigation=true`, especially considering that MainPageViewModel uses `useModalNavigation: false` when calling NavigateAsync?
    * Xamarin's Navigation.NavigationStack is simply "/ViewB" and ModalStack is again empty; why are these stacks so different from what GetNavigationUriPath indicates?
