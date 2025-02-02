using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.EventModels;
using TRMDesktopUI.Views;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        SalesViewModel _salesVM;
        IEventAggregator _events;
        SimpleContainer _simpleContainer;
        public ShellViewModel( IEventAggregator events, SalesViewModel salesVM, SimpleContainer simpleContainer) 
        {
            _salesVM = salesVM;
            _events = events;
            _simpleContainer = simpleContainer;
            _events.Subscribe(this);
            ActivateItem(_simpleContainer.GetInstance<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_salesVM);
        }
    }
}
