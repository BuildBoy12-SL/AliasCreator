// -----------------------------------------------------------------------
// <copyright file="AliasModel.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace AliasCreator.Models
{
    /// <summary>
    /// Represents a model for custom command aliases.
    /// </summary>
    public class AliasModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AliasModel"/> class.
        /// </summary>
        public AliasModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AliasModel"/> class.
        /// </summary>
        /// <param name="targetCommand"><inheritdoc cref="TargetCommand"/></param>
        /// <param name="aliases"><inheritdoc cref="Aliases"/></param>
        public AliasModel(string targetCommand, params string[] aliases)
        {
            TargetCommand = targetCommand;
            Aliases = aliases;
        }

        /// <summary>
        /// Gets or sets the command that will be ran if any of the aliases are used.
        /// </summary>
        public string TargetCommand { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the aliases that will trigger the <see cref="TargetCommand"/>.
        /// </summary>
        public string[] Aliases { get; set; }
    }
}