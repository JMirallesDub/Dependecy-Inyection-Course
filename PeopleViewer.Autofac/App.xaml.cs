using Autofac;
using Autofac.Features.ResolveAnything;
using PeopleViewer.Common;
using PersonDataReader.Service;
using System.Windows;

namespace PeopleViewer.Autofac
{
    public partial class App : Application
    {
        IContainer Container;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Application.Current.MainWindow.Title = "With Dependency Injection - Autofac";
            Application.Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ServiceReader>().As<IPersonReader>();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            Container = builder.Build();
        }

        private void ComposeObjects()
        {
            Application.Current.MainWindow = Container.Resolve<PeopleViewerWindow>();
        }
    }
}
