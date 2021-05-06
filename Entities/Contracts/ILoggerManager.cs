namespace Entities.Contracts
{
    /// <summary>
    /// ILoggerManager interface
    /// </summary>
    public interface ILoggerManager
    {
        /// <summary>
        /// LogInfo contract
        /// </summary>
        /// <param name="message"></param>
        void LogInfo(string message);

        /// <summary>
        /// LogWarn contract
        /// </summary>
        /// <param name="message"></param>
        void LogWarn(string message);

        /// <summary>
        /// LogDebug contract
        /// </summary>
        /// <param name="message"></param>
        void LogDebug(string message);

        /// <summary>
        /// LogError contract
        /// </summary>
        /// <param name="message"></param>
        void LogError(string message);
    }
}
