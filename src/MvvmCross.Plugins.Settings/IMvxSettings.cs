// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMvxSettings.cs" company="">
//
// </copyright>
// <summary>
//   The MvxSettings interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MvvmCross.Plugins.Settings
{
    using System;

    /// <summary>
    /// The IMvxSettings interface.
    /// </summary>
    public interface IMvxSettings
    {
        #region Public Methods and Operators

        /// <summary>
        /// Adds or updates the value
        /// </summary>
        /// <param name="key">
        /// Key for settting
        /// </param>
        /// <param name="value">
        /// Value to set
        /// </param>
        /// <returns>
        /// True of was added or updated and you need to save it.
        /// </returns>
        bool AddOrUpdateValue(string key, object value);

        /// <summary>
        /// Gets the current value or the default that you specify.
        /// </summary>
        /// <typeparam name="T">
        /// Vaue of t (bool, int, float, long, string)
        /// </typeparam>
        /// <param name="key">
        /// Key for settings
        /// </param>
        /// <returns>
        /// Value or default
        /// </returns>
        T GetValue<T>(string key) where T: class;

        /// <summary>
        ///     Saves the changes.
        /// </summary>
        void Save();

        #endregion Public Methods and Operators
    }
}