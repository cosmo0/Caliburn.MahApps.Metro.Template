namespace CaliburnTemplate.ViewModels
{
    using Caliburn.Micro;
    using CaliburnTemplate.Events;
    using PropertyChanged;

    /// <summary>
    /// Handles screens management and wiring
    /// </summary>
    [ImplementPropertyChanged]
    public class MasterViewModel : Conductor<object>, IShell, IHandle<ChangeMainScreenEvent>
    {
        /// <summary>
        /// Stores the events aggregator
        /// </summary>
        private readonly IEventAggregator events;

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterViewModel"/> class
        /// </summary>
        /// <param name="events">The event aggregator</param>
        public MasterViewModel(IEventAggregator events)
        {
            this.DisplayName = "CaliburnTemplate";
            this.events = events;

            this.ActivateItem(new MainViewModel(this.events));
            this.events.Subscribe(this);
        }

        /// <summary>
        /// Handles the change of screen
        /// </summary>
        /// <param name="message">The event message</param>
        public void Handle(ChangeMainScreenEvent message)
        {
            this.DisplayName = message.Screen.DisplayName;
            this.ActivateItem(message.Screen);
        }
    }
}