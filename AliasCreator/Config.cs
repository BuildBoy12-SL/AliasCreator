// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace AliasCreator
{
    using AliasCreator.Models;
    using Exiled.API.Interfaces;

    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc/>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the configured command aliases.
        /// </summary>
        public AliasModel[] Aliases { get; set; } =
        {
            new("hello", "hi", "howdy"),
        };
    }
}