using DAL;
using DomainServices;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFClient.Interfaces;
using WPFClient.ViewModels;
using WPFObjects;

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer unityContainer = new UnityContainer();

            unityContainer.RegisterType<IMessageBoxService, MessageBoxService>();
            unityContainer.RegisterType<IGenericRepositoryServices<PatientInfo>, PatientsServices>();
            unityContainer.RegisterType<IMainViewModel, MainViewModel>();
            
            var window = unityContainer.Resolve<MainWindow>();
            
            window.Show();
        }
    }
}
