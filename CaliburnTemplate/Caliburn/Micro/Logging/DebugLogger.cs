namespace Caliburn.Micro.Logging
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Implementation of the ILog and ILogExtended interfaces using <see cref="Debug"/>.
    /// </summary>
    public class DebugLogger : ILog, ILogExtended
    {
        /// <summary>
        /// The error type label
        /// </summary>
        private const string ErrorText = "ERROR";

        /// <summary>
        /// The info type label
        /// </summary>
        private const string InfoText = "INFO";

        /// <summary>
        /// The warning type label
        /// </summary>
        private const string WarnText = "WARN";

        /// <summary>
        /// The type of the logger
        /// </summary>
        private readonly Type type;

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugLogger"/> class
        /// </summary>
        /// <param name="type">The logger type</param>
        public DebugLogger(Type type)
        {
            this.type = type;
        }

        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void Error(Exception exception)
        {
            Debug.WriteLine(this.CreateLogMessage(exception.ToString()), ErrorText);
        }

        /// <summary>
        /// Logs the message as error.
        /// </summary>
        /// <param name="format">A formatted message.</param>
        /// <param name="args">Parameters to be injected into the formatted message.</param>
        public void Error(string format, params object[] args)
        {
            Debug.WriteLine(this.CreateLogMessage(format, args), ErrorText);
        }

        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="format">A formatted message.</param>
        /// <param name="args">Parameters to be injected into the formatted message.</param>
        public void Error(Exception exception, string format, params object[] args)
        {
            Debug.WriteLine(this.CreateLogMessage(format + " - Exception = " + exception.ToString(), args), ErrorText);
        }

        /// <summary>
        /// Logs the message as info.
        /// </summary>
        /// <param name="format">A formatted message.</param><param name="args">Parameters to be injected into the formatted message.</param>
        public void Info(string format, params object[] args)
        {
            Debug.WriteLine(this.CreateLogMessage(format, args), InfoText);
        }

        /// <summary>
        /// Logs the message as a warning.
        /// </summary>
        /// <param name="format">A formatted message.</param><param name="args">Parameters to be injected into the formatted message.</param>
        public void Warn(string format, params object[] args)
        {
            Debug.WriteLine(this.CreateLogMessage(format, args), WarnText);
        }

        /// <summary>
        /// Creates a log message
        /// </summary>
        /// <param name="format">The string format</param>
        /// <param name="args">The string format arguments</param>
        /// <returns>The formatted log message</returns>
        private string CreateLogMessage(string format, params object[] args)
        {
            return string.Format("[{0}] {1}", DateTime.Now.ToString("o"), string.Format(format, args));
        }
    }
}