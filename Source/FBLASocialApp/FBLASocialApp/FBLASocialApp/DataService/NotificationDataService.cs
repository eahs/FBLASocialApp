﻿using System.Reflection;
using System.Runtime.Serialization.Json;
using FBLASocialApp.ViewModels.Notification;
using Xamarin.Forms.Internals;

namespace FBLASocialApp.DataService
{
    /// <summary>
    /// The Notification Data Service
    /// </summary>
    [Preserve(AllMembers = true)]
    public class NotificationDataService
    {
        #region fields

        private static NotificationDataService _instance;

        private NotificationViewModel notificationViewModel;

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="NotificationDataService"/>.
        /// </summary>
        public static NotificationDataService Instance => _instance ?? (_instance = new NotificationDataService());

        /// <summary>
        /// Gets or sets the value of notification view model.
        /// </summary>
        public NotificationViewModel NotificationViewModel =>
            this.notificationViewModel ??
            (this.notificationViewModel = PopulateData<NotificationViewModel>("notification.json"));

        #endregion

        #region Methods

        /// <summary>
        /// Populates the data for view model from json file.
        /// </summary>
        /// <typeparam name="T">Type of view model.</typeparam>
        /// <param name="fileName">Json file to fetch data.</param>
        /// <returns>Returns the view model object.</returns>
        private static T PopulateData<T>(string fileName)
        {
            var file = "FBLASocialApp.Data." + fileName;

            var assembly = typeof(App).GetTypeInfo().Assembly;

            T obj;

            using (var stream = assembly.GetManifestResourceStream(file))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                obj = (T)serializer.ReadObject(stream);
            }

            return obj;
        }

        #endregion
    }
}
