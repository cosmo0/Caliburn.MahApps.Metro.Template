namespace CaliburnTemplate.ViewModels
{
    using System.ComponentModel.Composition;
    using Caliburn.Micro;
    using PropertyChanged;

    [ImplementPropertyChanged]
    [Export(typeof(MainViewModel))]
    public class MainViewModel : PropertyChangedBase
    {
        private readonly IEventAggregator events;

        [ImportingConstructor]
        public MainViewModel(IEventAggregator events)
        {
            this.events = events;
            this.events.Subscribe(this);
        }
    }
}