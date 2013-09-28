// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PluginLoader.cs" company="Shawn McLean">
//   
// </copyright>
// <summary>
//   Defines the PluginLoader type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MvvmCross.Plugins.Settings
{
    using Cirrious.CrossCore;
    using Cirrious.CrossCore.Plugins;

    /// <summary>
    /// The plugin loader.
    /// </summary>
    public class PluginLoader
        : IMvxPluginLoader
    {
        /// <summary>
        /// The instance.
        /// </summary>
        public static readonly PluginLoader Instance = new PluginLoader();

        /// <summary>
        /// The ensure loaded.
        /// </summary>
        public void EnsureLoaded()
        {
            var manager = Mvx.Resolve<IMvxPluginManager>();
            manager.EnsurePlatformAdaptionLoaded<PluginLoader>();
        }
    }
}
