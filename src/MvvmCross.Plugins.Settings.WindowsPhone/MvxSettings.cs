// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MvxSettings.cs" company="">
//
// </copyright>
// <summary>
//   Defines the MvxSettings type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MvvmCross.Plugins.Settings.WindowsPhone
{
    using System;
    using System.IO.IsolatedStorage;

    /// <summary>
    ///     The mvx settings.
    /// </summary>
    public class MvxSettings : IMvxSettings
    {
        /// <summary>
        /// Gets the settings.
        /// </summary>
        private static IsolatedStorageSettings Settings
        {
            get
            {
                return IsolatedStorageSettings.ApplicationSettings;
            }
        }

        /// <summary>
        /// The locker.
        /// </summary>
        private readonly object locker = new object();

        #region Public Methods and Operators

        /// <summary>
        /// The add or update value.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AddOrUpdateValue(string key, object value)
        {
            bool valueChanged = false;

            lock (locker)
            {
                // If the key exists
                if (Settings.Contains(key))
                {
                    // If the value has changed
                    if (Settings[key] == value)
                    {
                        return valueChanged;
                    }

                    // Store key new value
                    Settings[key] = value;
                    valueChanged = true;
                }
                else
                {
                    // Otherwise create the key.
                    Settings.Add(key, value);
                    valueChanged = true;
                }
            }

            return valueChanged;
        }

        /// <summary>
        /// The get value or default.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="defaultValue">
        /// The default value.
        /// </param>
        /// <typeparam name="T">
        /// can be any comparable type
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T GetValueOrDefault<T>(string key, T defaultValue) where T : IComparable
        {
            T value;
            lock (locker)
            {
                // If the key exists, retrieve the value.
                if (Settings.Contains(key))
                {
                    value = (T)Settings[key];
                }
                else
                {
                    // Otherwise, use the default value.
                    value = defaultValue;
                }
            }

            return value;
        }

        /// <summary>
        /// The save.
        /// </summary>
        public void Save()
        {
            lock (locker)
            {
                Settings.Save();
            }
        }

        #endregion Public Methods and Operators
    }
}