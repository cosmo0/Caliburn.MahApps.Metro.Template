namespace CaliburnTemplate.ViewModels
{
    using System.ComponentModel.Composition;
    using Caliburn.Micro;
    using CaliburnTemplate.Events;
    using PropertyChanged;

    /// <summary>
    /// Handles screens management and wiring
    /// </summary>
    [ImplementPropertyChanged]
    [Export(typeof(MasterViewModel))]
    public class MasterViewModel : Conductor<object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MasterViewModel"/> class
        /// </summary>
        /// <param name="events">The event aggregator</param>
        public MasterViewModel(IEventAggregator events)
        {
            this.DisplayName = "CaliburnTemplate";
            this.ActivateItem(new MainViewModel(events));
            events.Subscribe(this);
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