﻿using System;
using HamburgerMenu.Services;
using Prism.Commands;
using Prism.Navigation;

namespace HamburgerMenu.ViewModels
{
    public class ViewBViewModel : BaseViewModel
    {
        IAuthenticationService _authenticationService { get; }

        public ViewBViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
            : base(navigationService)
        {
            Title = "View B";
            _authenticationService = authenticationService;
            LogoutCommand = new DelegateCommand(OnLogoutCommandExecuted);
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private string _navPath;
        public string NavPath
        {
            get { return _navPath; }
            set { SetProperty(ref _navPath, value); }
        }

        public DelegateCommand LogoutCommand { get; }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Message = parameters.GetValue<string>("message");
            NavPath = _navigationService.GetNavigationUriPath();
        }

        public void OnLogoutCommandExecuted() =>
            _authenticationService.Logout();
    }
}
