using Newtonsoft.Json;

namespace Entities.Models
{
    /// <summary>
    /// ErrorDetails class
    /// </summary>
    public class ErrorDetails
    {
        /// <summary>
        /// StatusCode property
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Message property
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// override ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString() { return JsonConvert.SerializeObject(this); }
    }
}
