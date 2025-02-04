using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.EventModels;
using TRMDesktopUI.Library.Models;
using TRMDesktopUI.Views;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        SalesViewModel _salesVM;
        IEventAggregator _events;
        ILoggedInUserModel _user;
        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM, ILoggedInUserModel loggedInUserModel) 
        {
            _salesVM = salesVM;
            _events = events;
            _events.Subscribe(this);
            _user = loggedInUserModel;
            ActivateItem(IoC.Get<LoginViewModel>());
        }
        public bool IsLoggedIn
        {
            get
            {
                bool output = false;

                if (string.IsNullOrWhiteSpace(_user.Token) == false)
                {
                    output = true;
                }

                return output;
            }

        }

        public void ExitApplication()
        {
            TryClose();
        }
        public void LogOut()
        {
            _user.LogOffUser();
            ActivateItem(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsLoggedIn);

        }
        public void Handle(LogOnEvent message)
        {
            ActivateItem(_salesVM);
            NotifyOfPropertyChange(() => IsLoggedIn);
        }
    }
}
