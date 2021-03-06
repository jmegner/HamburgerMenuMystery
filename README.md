# Hamburger Menu Mystery
Altered HamburgerMenu project from Prism-Samples-Forms repo for the purpose of understanding navigation stack manipulation.

Notable alterations:

* skipping of login page stuff

* ViewA through ViewC display...

    * The `message` navigation parameter

    * `_navigationService.GetNavigationUriPath()`

    * a string version of Navigation.NavigationStack and Navigation.ModalStack, separated by a semicolon

* More navigation buttons in MainPage's master page.

# Questions I had...

* What exactly happens when you do a NavigationService.NavigateAsync("NavigationPage/SomeContentPage")? It causes you do navigate to SomeContentPage that is wrapped in a NavigationPage (so you get navigation icon, title, and toolbar items shown), right?

* App.xaml.cs navigates to "/Index/Navigation/ViewA?message=InitialNav" ("Index" is an alias for MainPage)

    * In ViewAViewModel, Prism's `_navigationService.GetNavigationUriPath()` returns "/Navigation/ViewA"; where did "/Index" go?

    * In ViewA.xaml.cs, Xamarin's Navigation.NavigationStack is "/ViewA" (and the ModalStack is empty); where did "/Index" go?  Why does the Xamarin NavigationStack differ from Prism's GetNavigationUriPath?

![ViewA, why is "/Index" absent?](screenshots/02_ViewA_where_is_index_annotated.png)

* If you then click the hamburger icon so you get the MainPage master page, and click the "N/A" button so MainPageViewModel does a `_navigationService.NavigateAsync("Navigation/ViewA?message=NA")`...

    * Prism's GetNavigationUriPath returns "/Index/Navigation/ViewA"; why does "Index" appear now and not before?

![ViewA, why is "/Index" present?](screenshots/05_ViewA_index_appears_annotated.png)

* If you then click the hamburger icon and then click the "N/B" button, so the MainPageViewModel does a `_navigationService.NavigateAsync("Navigation/ViewB?message=NB")`...

    * Prism's GetNavigationUriPath returns "/Index/Navigation/ViewA/Navigation?useModalNavigation=true/ViewB"; why the `useModalNavigation=true`, especially considering that MainPageViewModel uses `useModalNavigation: false` when calling NavigateAsync?
    * Xamarin's Navigation.NavigationStack is simply "/ViewB" and ModalStack is again empty; why are these stacks so different from what GetNavigationUriPath indicates?

![ViewB, why modal?](screenshots/06_ViewB_why_modal.png)


# Update With Answers

I posted my question in a [Xamarin forums thread](https://forums.xamarin.com/discussion/156322/weird-navigation-in-hamburgermenu-sample-project-from-prism-samples-forms), and [Brian Lagunas](https://brianlagunas.com/) [himself](https://github.com/orgs/PrismLibrary/people) answered. Thanks, Brian!

In short, navigation from a MasterDetailPage (MDP) is different from normal navigation: mostly it's swapping out the detail page or doing modal navigations.  That's why things are so weird and don't match all the things we've read about navigation (because they are for navigation NOT from a MDP).  It's also possible the missing "/Index" is a GetNavigationUriPath bug.

Possible future work:
* Create minimal project that exposes the GetNavigationUriPath bug.
* Create a similar navigation experimentation project that does not use MDP.
* See if Prism people are interested in a pull request for Prism-Samples-Forms where we upgrade to latest Prism version and we do some changes to HamburgerMenu to make it more best-practices compliant (right now it does a weird mixture of detail page swapping and modal navigation as you bounce around {ViewA,ViewB,ViewC}).



