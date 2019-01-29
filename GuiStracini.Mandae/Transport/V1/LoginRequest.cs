namespace GuiStracini.Mandae.Transport.V1
{
    using System;
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>
    /// The login request
    /// </summary>
    [RequestEndPoint("lp/server/api/site/v1/login", CustomBase = "URL")]
    public sealed class LoginRequest : BaseRequest
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        [JsonProperty("username")]
        public String Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [JsonProperty("password")]
        public String Password { get; set; }
    }
}
