using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TRMDesktopUI.ViewModels;

namespace TRMDesktopUI
{
    // this is what sets up Caliburn Micro
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer(); // this will do all instantiations for us
        public Bootstrapper() 
        {
            Initialize();
        }
        protected override void Configure()
        {
            _container.Instance(_container); // we want to pass this to others? not only via constructor

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>(); // this is used to set START UP View Model
            // And ShellViewModel will start View by its own using Caliburn
            // we remove StartupUri="MainWindow.xaml" from App.xaml 
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service); 
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

    }
}
