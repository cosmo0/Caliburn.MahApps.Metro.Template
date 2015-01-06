namespace CaliburnTemplate.ViewModels
{
    using Caliburn.Micro;
    using PropertyChanged;

    /// <summary>
    /// Main view model for the application
    /// </summary>
    [ImplementPropertyChanged]
    public class MainViewModel : PropertyChangedBase
    {
        /// <summary>
        /// Stores the events aggregator
        /// </summary>
        private readonly IEventAggregator events;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class
        /// </summary>
        /// <param name="events">The events</param>
        public MainViewModel(IEventAggregator events)
        {
            this.events = events;
            this.events.Subscribe(this);
        }
    }
}