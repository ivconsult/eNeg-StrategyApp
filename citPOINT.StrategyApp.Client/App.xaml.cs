
#region → Usings   .

using System;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Browser;
using System.Threading;
using System.Globalization;
using citPOINT.eNeg.Infrastructure.ExceptionHandling;
using citPOINT.eNeg.Infrastructure.ClientSide.ExceptionHandling;
using citPOINT.StrategyApp.Common;

#endregion

#region → History  .

/* Date         User              Change
 * 10.01.12     M.Wahab           Creation
 */

# endregion

#region → ToDos    .

/*
 * Date         set by User     Description
 * 
 * 
*/

# endregion

namespace citPOINT.StrategyApp.Client
{
    /// <summary>
    /// Mian Class Or Start Point Class
    /// </summary>
    public partial class App : Application
    {
        #region → Fields         .
        /// <summary>
        /// Opened Sub Windows
        /// </summary>
        public static List<object> OpenedSubWindows = new List<object>();
        #endregion

        #region → Constructor    .

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            //Initialize used exception handling policies
            ClientExceptionHandlerProvider.RepaireExceptionPolicies();

            // Set the current UI culture.
            Thread.CurrentThread.CurrentCulture = new CultureInfo("En-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("En-US");

            //Register for most used event handlers of App
            this.Startup += this.Application_Startup;
            this.UnhandledException += this.Application_UnhandledException;

            InitializeComponent();
        }

        #endregion Constructor

        #region → Event Handlers .

        /// <summary>
        /// Handler for Application Start Up.
        /// </summary>
        /// <param name="sender">Value of Sender</param>
        /// <param name="e">Value of StartupEventArgs </param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            #region → Read the query string coming from eNeg to define user & partner culture   .

            if (HtmlPage.Document.QueryString.ContainsKey("NegID"))
            {
                StrategyAppConfigurations.NegotiationIDParameter = new Guid(HtmlPage.Document.QueryString["NegID"].ToString());

                if (HtmlPage.Document.QueryString.ContainsKey("ConvID"))
                {
                    StrategyAppConfigurations.ConversationIDParameter = new Guid(HtmlPage.Document.QueryString["ConvID"].ToString());
                }
            }


            //StrategyAppConfigurations.NegotiationIDParameter = Guid.Parse("21e6cf42-49ff-4b35-9c1d-02c0275dae80");
            //StrategyAppConfigurations.ConversationIDParameter = Guid.Parse("fb0039a5-7c67-4c37-afeb-dc0cb235e43b");

            #endregion

            this.RootVisual = new MainPageView();
        }

        /// <summary>
        /// Handle Application Unhandled Exception
        /// </summary>
        /// <param name="sender">Value of Sender</param>
        /// <param name="e">Value of ApplicationUnhandledExceptionEventArgs </param>
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                e.Handled = true;

                if (!(e.ExceptionObject is System.InvalidOperationException))
                {
                    Deployment.Current.Dispatcher.BeginInvoke(delegate { ReportErrorToDOM(e.ExceptionObject); });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Used to Report Error To DOM (Mean Html Side)
        /// </summary>
        /// <param name="e">Value of ApplicationUnhandledExceptionEventArgs</param>
        private void ReportErrorToDOM(Exception e)
        {
            try
            {
                string errorMsg = e.Message + e.StackTrace;

                if (e.InnerException != null)
                {
                    errorMsg += "\r\n---------Inner-----------\r\n";
                    errorMsg += e.InnerException.Message + e.InnerException.StackTrace;


                    if (e.InnerException.InnerException != null)
                    {
                        errorMsg += "\r\n---------Inner Inner-----------\r\n";
                        errorMsg += e.InnerException.InnerException.Message + e.InnerException.InnerException.StackTrace;
                    }

                }

                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Alert("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");


            }
            catch (Exception)
            {
            }
        }

        #endregion Event Handlers
    }
}
