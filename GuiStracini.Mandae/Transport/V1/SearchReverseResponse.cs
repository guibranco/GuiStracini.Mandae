namespace GuiStracini.Mandae.Transport.V1
{
    using ValueObject;

    /// <summary>
    /// The reverse response class.
    /// </summary>
    /// <seealso cref="GuiStracini.Mandae.Transport.BaseResponse" />
    public sealed class SearchReverseResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the reverses.
        /// </summary>
        /// <value>
        /// The reverses.
        /// </value>
        public Reverse[] Reverses { get; set; }
    }
}
