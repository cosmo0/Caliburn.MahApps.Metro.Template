namespace CaliburnTemplate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;
    using System.Linq;
    using System.Windows;
    using Caliburn.Micro;
    using CaliburnTemplate.ViewModels;

    public class AppBootstrapper : BootstrapperBase
    {
        /// <summary>
        /// Stores the composition containers
        /// </summary>
        private CompositionContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppBootstrapper"/> class
        /// </summary>
        public AppBootstrapper()
        {
            this.Initialize();
        }

        /// <summary>
        /// Builds up the container
        /// </summary>
        /// <param name="instance">The instance</param>
        protected override void BuildUp(object instance)
        {
            this.container.SatisfyImportsOnce(instance);
        }

        /// <summary>
        /// Configures the bindings
        /// </summary>
        protected override void Configure()
        {
            this.container = new CompositionContainer(new AggregateCatalog(AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>()));

            CompositionBatch batch = new CompositionBatch();

            batch.AddExportedValue<IWindowManager>(new AppWindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(this.container);

            this.container.Compose(batch);
        }

        /// <summary>
        /// Gets all instances of the windows
        /// </summary>
        /// <param name="serviceType">The service type</param>
        /// <returns>The list of windows</returns>
        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return this.container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        /// <summary>
        /// Gets an instance of a window
        /// </summary>
        /// <param name="serviceType">The service type</param>
        /// <param name="key">The key</param>
        /// <returns>The window instance</returns>
        protected override object GetInstance(Type serviceType, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            var exports = this.container.GetExportedValues<object>(contract);

            if (exports.Any())
            {
                return exports.First();
            }

            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
        }

        /// <summary>
        /// Runs on application startup
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The startup events</param>
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            this.DisplayRootViewFor<MasterViewModel>();
        }
    }
}