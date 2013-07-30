// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TopShelfWindowsServiceBootstrapper.cs" company="Yin Zhang">
//   Copyright (c) 2013 Yin Zhang
//   
//   Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation 
//   files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, 
//   modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the 
//   Software is furnished to do so, subject to the following conditions:
//     
//   The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//    
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE 
//   WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
//   COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
//   ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary>
//   The top shelf windows service bootstrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WindowsServiceBootstrapper
{
    using System;

    using Topshelf;
    using Topshelf.HostConfigurators;

    using WindowsServiceBootstrapper.Interfaces;

    /// <summary>
    /// The top shelf windows service bootstrapper.
    /// </summary>
    public class TopShelfWindowsServiceBootstrapper : IWindowsServiceBootstrapper
    {
        #region Fields

        /// <summary>
        /// The Windows service controller factory.
        /// </summary>
        private readonly Func<string, IWindowsServiceController> serviceControllerFactory;

        /// <summary>
        /// The Windows service information provider.
        /// </summary>
        private readonly IWindowsServiceInfoProvider windowsServiceInfoProvider;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TopShelfWindowsServiceBootstrapper"/> class.
        /// </summary>
        /// <param name="windowsServiceInfoProvider">
        /// The Windows service info provider.
        /// </param>
        /// <param name="serviceControllerFactory">
        /// The Windows service controller factory.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws when <paramref name="windowsServiceInfoProvider"/> or <paramref name="serviceControllerFactory"/> is null.
        /// </exception>
        public TopShelfWindowsServiceBootstrapper(
            IWindowsServiceInfoProvider windowsServiceInfoProvider, 
            Func<string, IWindowsServiceController> serviceControllerFactory)
        {
            if (windowsServiceInfoProvider == null)
            {
                throw new ArgumentNullException("windowsServiceInfoProvider");
            }

            if (serviceControllerFactory == null)
            {
                throw new ArgumentNullException("serviceControllerFactory");
            }

            this.windowsServiceInfoProvider = windowsServiceInfoProvider;
            this.serviceControllerFactory = serviceControllerFactory;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Defines the process of booting the application.
        /// </summary>
        public void Boot()
        {
            HostFactory.Run(
                x =>
                {
                    this.Configure(x);

                    this.SetServiceInfo(x);

                    x.Service<IWindowsServiceController>(
                        s =>
                        {
                            s.ConstructUsing(name => this.serviceControllerFactory(name));

                            s.WhenStarted(winService => winService.OnStart());
                            s.WhenPaused(winService => winService.OnPause());
                            s.WhenContinued(winService => winService.OnContinue());
                            s.WhenStopped(winService => winService.OnStop());
                        });
                });
        }

        #endregion

        #region Methods

        /// <summary>
        /// Configure service behaviour.
        /// </summary>
        /// <param name="configurator">
        /// The configurator.
        /// </param>
        protected void Configure(HostConfigurator configurator)
        {
            // depends on event log service
            configurator.DependsOnEventLog();

            configurator.RunAsLocalService();
            configurator.StartAutomatically();

            // use NLog to log message
            configurator.UseNLog();

            // enable pause and continue
            configurator.EnablePauseAndContinue();

            // enable shutdown
            configurator.EnableShutdown();
        }

        /// <summary>
        /// Set service information.
        /// </summary>
        /// <param name="configurator">
        /// The configurator.
        /// </param>
        protected void SetServiceInfo(HostConfigurator configurator)
        {
            configurator.SetServiceName(this.windowsServiceInfoProvider.GetServiceName());
            configurator.SetDisplayName(this.windowsServiceInfoProvider.GetServiceDisplayName());
            configurator.SetDescription(this.windowsServiceInfoProvider.GetServiceDescription());
        }

        #endregion
    }
}