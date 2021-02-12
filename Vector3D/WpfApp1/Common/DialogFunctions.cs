using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Common
{
    /// <summary>
    /// Manage all the views dialog of the application
    /// </summary>
    public static class DialogFunctions
    {

        #region  Public Methods
        /// <summary>
        /// Close the view Dialog using the name propertie of the view
        /// </summary>
        /// <param name="viewName">name of the view</param>
        public static void CloseViewByName(string viewName)
        {
            foreach (Window view in Application.Current.Windows)
            {
                if (view.Name.Equals(viewName))
                {
                    view.Close();
                }
            }

        }
        #endregion

    }
}
