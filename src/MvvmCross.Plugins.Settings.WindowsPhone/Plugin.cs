// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Plugin.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Plugin type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MvvmCross.Plugins.Settings.WindowsPhone
{
    using Cirrious.CrossCore;
    using Cirrious.CrossCore.Plugins;

    /// <summary>
    /// The plugin.
    /// </summary>
    public class Plugin : IMvxPlugin
    {
        /// <summary>
        /// The load.
        /// </summary>
        public void Load()
        {
            Mvx.RegisterSingleton<IMvxSettings>(new MvxSettings());
        }
    }
}