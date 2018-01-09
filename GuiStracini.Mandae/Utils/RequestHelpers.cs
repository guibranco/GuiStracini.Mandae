﻿// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="RequestHelpers.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Utils
{
    using Attributes;
    using Enums;
    using GoodPractices;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Transport;

    /// <summary>
    /// Class Extensions.
    /// </summary>
    public static class RequestHelpers
    {
        /// <summary>
        /// Gets the request end point.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>String.</returns>
        /// <exception cref="RequestEndPointBadFormatException"></exception>
        /// <exception cref="InvalidRequestEndPointException"></exception>
        public static String GetRequestEndPoint(this BaseRequest request)
        {
            var type = request.GetType();
            if (!(type.GetCustomAttributes(typeof(RequestEndPointAttribute), false) is RequestEndPointAttribute[] endpoints) || !endpoints.Any())
                return type.Name.ToUpper();
            var originalEndpoint = endpoints.Single().EndPoint;
            var endpoint = originalEndpoint;
            var regex = new Regex(@"/?(?<pattern>{(?<propertyName>\w+?)})/?");
            if (!regex.IsMatch(endpoint))
                return endpoint;
            var used = 0;
            var skiped = 0;
            var counter = 0;
            foreach (Match match in regex.Matches(endpoint))
            {
                counter++;
                var propertyName = match.Groups["propertyName"].Value;
                var property = type.GetProperty(propertyName);
                if (property == null)
                    throw new RequestEndPointBadFormatException(originalEndpoint);
                var propertyType = property.PropertyType;
                var propertyValue = property.GetValue(request, null);
                if (propertyValue == null ||
                    propertyType == typeof(Int32) && Convert.ToInt32(propertyValue) == 0 ||
                    propertyType == typeof(Int64) && Convert.ToInt64(propertyValue) == 0 ||
                    propertyType == typeof(Decimal) && Convert.ToDecimal(propertyValue) == new Decimal(0) ||
                    propertyType == typeof(String) && String.IsNullOrEmpty(propertyValue.ToString()))
                {
                    var defaultValue = String.Empty;
                    if (property.GetCustomAttributes(typeof(RequestParameterDefaultValue), false) is
                            RequestParameterDefaultValue[] defaultsValues && defaultsValues.Any())
                        defaultValue = defaultsValues.Single().DefaultValue;
                    endpoint = endpoint.Replace(match.Value, defaultValue);
                    if (skiped == 0 && defaultValue == String.Empty)
                        skiped = counter;
                    continue;
                }
                used = counter;
                var value = propertyValue.ToString();
                if (property.PropertyType.IsEnum)
                    value = value.ToLower();
                endpoint = endpoint.Replace(match.Groups["pattern"].Value, value);
            }
            if (skiped != 0 && skiped < used)
                throw new InvalidRequestEndPointException(originalEndpoint, endpoint);
            return endpoint.Trim('/');
        }

        /// <summary>
        /// Gets the request additional parameter.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="requestMethod">The request method.</param>
        /// <returns>String.</returns>
        public static String GetRequestAdditionalParameter(this BaseRequest request, ActionMethod requestMethod)
        {
            var type = request.GetType();
            var properties = type.GetProperties().Where(prop => prop.IsDefined(typeof(RequestAdditionalParameterAttribute), false)).ToList();
            if (!properties.Any())
                return String.Empty;
            var builder = new StringBuilder();
            foreach (var property in properties)
            {
                if (!(property.GetCustomAttributes(typeof(RequestAdditionalParameterAttribute), false) is RequestAdditionalParameterAttribute[] attributes) || attributes.All(a => a.Type != requestMethod))
                    continue;
                var addAsQueryString = attributes.Single(a => a.Type == requestMethod).AsQueryString;
                var propertyValue = property.GetValue(request);
                if (propertyValue == null)
                    continue;

                if (property.PropertyType == typeof(Boolean))
                    propertyValue = propertyValue.ToString().ToLower();
                var propertyName = property.Name;
                if (property.GetCustomAttributes(typeof(JsonPropertyAttribute), false) is JsonPropertyAttribute[] attributesJson &&
                    attributesJson.Any())
                    propertyName = attributesJson.Single().PropertyName;
                if (property.PropertyType == typeof(String) ||
                    property.PropertyType == typeof(Boolean) ||
                    property.PropertyType == typeof(Int32) && Convert.ToInt32(propertyValue) > 0 ||
                    property.PropertyType == typeof(Int64) && Convert.ToInt64(propertyValue) > 0)
                    builder.Append("/").AppendFormat("{0}", addAsQueryString ? $"?{propertyName}=" : String.Empty).Append(propertyValue);
            }
            return builder.ToString();
        }
    }
}