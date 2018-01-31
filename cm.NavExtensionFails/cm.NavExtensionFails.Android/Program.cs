using System;
using System.Collections.Generic;
using System.Reflection;

using Android.App;
using Android.Runtime;

using Caliburn.Micro;

namespace cm.NavExtensionFails.Droid
{
    [Application]
    public class Program : CaliburnApplication
    {
        SimpleContainer _container;

        public Program(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            PlatformProvider.Current = new AndroidPlatformProvider(this);
        }

        public override void OnCreate()
        {
            base.OnCreate();

            Initialize();
        }

        protected override void Configure()
        {
            base.Configure();

            _container = new SimpleContainer();

            _container.Instance(_container);
            _container.Singleton<IEventAggregator, EventAggregator>();
            _container.Singleton<App>();
        }

        protected override IEnumerable<Assembly> SelectAssemblies() => new[] { GetType().Assembly, typeof(Views.MainView).Assembly };

        protected override void BuildUp(object instance) => _container.BuildUp(instance);
        protected override IEnumerable<object> GetAllInstances(Type service) => _container.GetAllInstances(service);
        protected override object GetInstance(Type service, string key) => _container.GetInstance(service, key);
    }
}