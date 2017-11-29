namespace GuiStracini.Mandae.Transport
{
    using Attributes;
    using Enums;
    using Newtonsoft.Json;
    using System;

    [RequestEndPoint("orders")]
    public sealed class LargeOrderRequest : OrderRequest
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="OrderRequest"/> is asynchronous.
        /// </summary>
        /// <value>
        ///   <c>true</c> if asynchronous; otherwise, <c>false</c>.
        /// </value>
        [RequestAdditionalParameter(ActionMethod.POST, true)]
        [JsonProperty("async")]
        [JsonIgnore]
        public Boolean Async => true;
    }
}
