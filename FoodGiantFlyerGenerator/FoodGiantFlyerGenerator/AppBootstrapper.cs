using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition;
using System.Windows;
using System.Reflection;

namespace FoodGiantFlyerGenerator
{
    public class AppBootstrapper : BootstrapperBase
    {
        private CompositionContainer _CompContainer;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _CompContainer = new CompositionContainer(new AggregateCatalog(AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>()));

            CompositionBatch batch = new CompositionBatch();

            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(_CompContainer);

            _CompContainer.Compose(batch);

            var config = new TypeMappingConfiguration();
            config.DefaultSubNamespaceForViewModels = "ViewModel";
            config.DefaultSubNamespaceForViews = "View";
            config.UseNameSuffixesInMappings = true;
            config.IncludeViewSuffixInViewModelNames = true;

            ViewLocator.ConfigureTypeMappings(config);
            ViewModelLocator.ConfigureTypeMappings(config);
        }

        protected override object GetInstance(Type service, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(service) : key;
            var exports = _CompContainer.GetExportedValues<object>(contract);

            if (exports.Any())
                return exports.First();
            else
                throw new Exception("Error in Getting Instance, see Preqs section of User Guide");
        }

        protected override IEnumerable<object> GetAllInstances (Type service)
        {
            return _CompContainer.GetExportedValues<object>(AttributedModelServices.GetContractName(service));
        }

        protected override void BuildUp(object instance)
        {
            _CompContainer.SatisfyImportsOnce(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            var settings = new Dictionary<string, object>
            {
                {"SizeToContent" , SizeToContent.Manual},
                { "Height", 600 },
                { "Width", 600 }
            };

            DisplayRootViewFor<ProgramSelectorViewModel>(settings);
            IEventAggregator eventAggregator = IoC.Get<IEventAggregator>();
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            base.OnExit(sender, e);
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            List<Assembly> assemblies = new List<Assembly>();
            assemblies.Add(Assembly.GetExecutingAssembly());

            //For future projects
            //aassemblies.Add(Assembly.LoadFile(Environment.CurrentDirectory + ".dll"));

            return assemblies;
        }

    }
}
