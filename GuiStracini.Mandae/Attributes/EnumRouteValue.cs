// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 09/05/2018
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 09/05/2018
// ***********************************************************************
// <copyright file="EnumRouteValue.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Attributes
{
    using System;

    /// <summary>
    /// The enum route value attribute class.
    /// This attribute is used to get a representation value of a enum value to use in a route / query string parameter 
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class EnumRouteValueAttribute : Attribute
    {
        /// <summary>
        /// Gets the route value.
        /// </summary>
        /// <value>
        /// The route value.
        /// </value>
        public string RouteValue { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumRouteValueAttribute"/> class.
        /// </summary>
        /// <param name="routeValue">The route value.</param>
        public EnumRouteValueAttribute(string routeValue)
        {
            RouteValue = routeValue;
        }
    }
}
