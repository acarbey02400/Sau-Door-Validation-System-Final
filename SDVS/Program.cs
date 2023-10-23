using Autofac;
using Business.DependencyResolves.Autofac;

namespace SDVS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var container = Configure();
            Application.Run(new Form1(container));
        }

        static IContainer Configure()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new AutofacBusinessModule());
            var container = containerBuilder.Build();

            return container;
        }
    }
}