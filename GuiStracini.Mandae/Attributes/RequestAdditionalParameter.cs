// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="RequestAdditionalParameter.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Attributes
{
    using Enums;
    using System;

    /// <summary>
    /// Use this attribute to include a queryString in the request endpoint for specificThis class is used as attribute to flag a property to use it as EndPoint parameter for specific action method.
    /// E.g. A GET/PUT request should include the field "Name" of a entity in the URL, so add this attribute to the Name property in the transport class, and set the ActionMethod to GET and PUT (2 attributes)
    /// </summary>
    /// <example>
    /// Using a generic transport class, inherited from <see cref="GuiStracini.Mandae.Transport.BaseTransport"/>
    /// <code>
    /// [RequestEndPoint("/Sample/{id}")] //The id property is used in all requests if it's populated
    /// public class SampleTransport : BaseTransport 
    /// {
    ///     public Int32 Id { get; set; }
    /// 
    ///     [RequestAdditionalParameterAttribute(ActionMethod.GET)]
    ///     [RequestAdditionalParameterAttribute(ActionMethod.PUT)]
    ///     public String Name { get; set; } //The property Name is included in the url as querystring only in GET or PUT requests.
    /// }
    /// 
    /// var sample = new SampleTransport { Id = 1, Name = "Sample" };
    /// var endPointResult = sample.GetRequestEndPoint();
    /// Assert.AreEqual("/Sample/1/?name=Sample", endpointResult);
    /// </code>
    /// </example>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    internal sealed class RequestAdditionalParameterAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The action type of t he request.</value>
        public ActionMethod Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestAdditionalParameterAttribute"/> class.
        /// </summary>
        /// <param name="type">The type of request.</param>
        public RequestAdditionalParameterAttribute(ActionMethod type)
        {
            Type = type;
        }
    }
}