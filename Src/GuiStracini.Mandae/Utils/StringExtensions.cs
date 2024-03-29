﻿// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="StringExtensions.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace GuiStracini.Mandae.Utils
{
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A string extension methods class
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string to Camel Case (splits every words in the string and then upper case the first letter of each)
        /// </summary>
        /// <param name="str">The input string</param>
        /// <returns>The input string with Camel Case result</returns>
        public static string ToCamelCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            var words = str.Trim().Split(' ');
            var sb = new StringBuilder();

            foreach (var s in words.Where(s => !string.IsNullOrEmpty(s)))
            {
                sb.AppendFormat(
                    "{0}{1} ",
                    s.Substring(0, 1).ToUpper(),
                    s.Substring(1, s.Length - 1).ToLower()
                );
            }

            return sb.ToString().Substring(0, sb.ToString().Length - 1);
        }
    }
}
