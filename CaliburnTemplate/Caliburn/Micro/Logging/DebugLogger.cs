namespace Caliburn.Micro.Logging
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Implementation of the ILog and ILogExtended interfaces using
    /// <see cref="Debug"/>.
    /// </summary>
    public class DebugLogger : ILog, ILogExtended
    {
        private const string ErrorText = "ERROR";

        private const string InfoText = "INFO";

        private const string WarnText = "WARN";

        private readonly Type _type;

        public DebugLogger(Type type)
        {
            this._type = type;
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

        private string CreateLogMessage(string format, params object[] args)
        {
            return string.Format("[{0}] {1}", DateTime.Now.ToString("o"), string.Format(format, args));
        }
    }
}