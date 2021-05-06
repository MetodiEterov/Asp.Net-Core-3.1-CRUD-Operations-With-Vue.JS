namespace Entities.Models
{
    /// <summary>
    /// OwnerParameters class
    /// </summary>
    public class OwnerParameters
    {
        /// <summary>
        /// maxPageSize field sets max number of pages
        /// </summary>
        const int maxPageSize = 50;

        /// <summary>
        /// pageSize field sets default number of pages
        /// </summary>
        private int pageSize = 10;

        /// <summary>
        /// PageNumber property
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// PageSize property
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > maxPageSize) ? maxPageSize : value; }
        }
    }
}
