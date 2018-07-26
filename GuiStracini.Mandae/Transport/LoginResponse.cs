namespace GuiStracini.Mandae.Transport
{
    using System;

    /// <summary>
    /// The login response class.
    /// </summary>
    /// <seealso cref="GuiStracini.Mandae.Transport.BaseResponse" />
    public sealed class LoginResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Int32 Id { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public String Email { get; set; }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public String Token { get; set; }

        /// <summary>
        /// Gets or sets the identifier mixpanel.
        /// </summary>
        /// <value>
        /// The identifier mixpanel.
        /// </value>
        public String IdMixpanel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="LoginResponse"/> is pj.
        /// </summary>
        /// <value>
        ///   <c>true</c> if pj; otherwise, <c>false</c>.
        /// </value>
        public Boolean Pj { get; set; }
    }
}
