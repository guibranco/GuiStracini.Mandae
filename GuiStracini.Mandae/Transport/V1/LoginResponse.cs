namespace GuiStracini.Mandae.Transport.V1
{
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
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the identifier mixpanel.
        /// </summary>
        /// <value>
        /// The identifier mixpanel.
        /// </value>
        public string IdMixpanel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="LoginResponse"/> is pj.
        /// </summary>
        /// <value>
        ///   <c>true</c> if pj; otherwise, <c>false</c>.
        /// </value>
        public bool Pj { get; set; }

        /// <summary>
        /// Gets or sets the erro.
        /// </summary>
        /// <value>
        /// The erro.
        /// </value>
        public string Erro { get; set; }
    }
}
