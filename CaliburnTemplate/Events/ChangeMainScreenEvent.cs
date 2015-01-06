namespace CaliburnTemplate.Events
{
    using Caliburn.Micro;

    /// <summary>
    /// Event item when a screen is changed
    /// </summary>
    public class ChangeMainScreenEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeMainScreenEvent"/> class
        /// </summary>
        /// <param name="screen">The screen to switch to</param>
        public ChangeMainScreenEvent(Screen screen)
        {
            this.Screen = screen;
        }

        /// <summary>
        /// Gets or sets the screen to switch to
        /// </summary>
        public Screen Screen { get; set; }
    }
}