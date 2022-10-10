// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace AliasCreator
{
    using System;
    using Exiled.API.Features;
    using HarmonyLib;

    /// <inheritdoc />
    public class Plugin : Plugin<Config>
    {
        private Harmony harmony;

        /// <summary>
        /// Gets a static instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static Plugin Instance { get; private set; }

        /// <inheritdoc/>
        public override string Author => "Build";

        /// <inheritdoc/>
        public override string Name => "AliasCreator";

        /// <inheritdoc/>
        public override string Prefix => "AliasCreator";

        /// <inheritdoc/>
        public override Version Version { get; } = new(1, 0, 0);

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new(5, 3, 0);

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            Instance = this;
            harmony = new Harmony($"build.aliasCreator.{DateTimeOffset.UtcNow.Ticks}");
            harmony.PatchAll();
            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            harmony.UnpatchAll(harmony.Id);
            harmony = null;
            Instance = null;
            base.OnDisabled();
        }
    }
}