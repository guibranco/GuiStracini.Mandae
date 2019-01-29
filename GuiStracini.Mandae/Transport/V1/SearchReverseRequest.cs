namespace GuiStracini.Mandae.Transport.V1
{
    using System;
    using Attributes;
    using Enums;

    /// <summary>
    /// The reverse request class.
    /// </summary>
    /// <seealso cref="GuiStracini.Mandae.Transport.BaseRequest" />
    [RequestEndPoint("v1/reversas?offset={Offset}&limit={Limit}&{Method}={Value}")]
    public sealed class SearchReverseRequest : BaseRequest
    {
        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        /// <value>
        /// The method.
        /// </value>
        public ReverseSearchMethod Method { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public String Value { get; set; }

        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        /// <value>
        /// The offset.
        /// </value>
        [RequestParameterDefaultValue("0")]
        public Int32 Offset { get; set; }

        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        /// <value>
        /// The limit.
        /// </value>
        [RequestParameterDefaultValue("10")]
        public Int32 Limit { get; set; }

    }
}
