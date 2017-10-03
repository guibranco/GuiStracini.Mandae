﻿// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 29/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 29/09/2017
// ***********************************************************************
// <copyright file="ItemModel" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Models
{
    using System;
    using ValueObject;

    /// <summary>
    /// The item model class for the <see cref="OrderBuilder"/> class method <see cref="M:OrderBuilder.AddItem"/>
    /// </summary>

    internal sealed class ItemModel
    {
        /// <summary>
        /// The item identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The item itself
        /// </summary>
        public Item Item { get; set; }
    }
}
