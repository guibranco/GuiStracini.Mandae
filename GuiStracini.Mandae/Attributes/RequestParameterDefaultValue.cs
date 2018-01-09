// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 09/01/2018
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 09/01/2018
// ***********************************************************************
// <copyright file="RequestParamterDefaultValue.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
namespace GuiStracini.Mandae.Attributes
{
    using System;

    /// <summary>
    /// The request paraemter default value attribute.
    /// This attribute is used when a parameter value is not supplied in the object, instead the default value is used to build de endpoint.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class RequestParameterDefaultValue : Attribute
    {
        /// <summary>
        /// Gets the default value.
        /// </summary>
        /// <value>
        /// The default value.
        /// </value>
        public String DefaultValue { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestParameterDefaultValue"/> class.
        /// </summary>
        /// <param name="defaultValue">The default value.</param>
        public RequestParameterDefaultValue(String defaultValue)
        {
            DefaultValue = defaultValue;
        }
    }
}
