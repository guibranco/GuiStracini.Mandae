﻿namespace GuiStracini.Mandae.Transport.V1
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>
    /// The login request
    /// </summary>
    [ExtendedEndpointRoute("lp/server/api/site/v1/login", CustomBase = "URL")]
    public sealed class LoginRequest : Request
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
