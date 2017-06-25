
#region → Usings   .
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using citPOINT.StrategyApp.ViewModel;
using citPOINT.StrategyApp.Common;
using System.ComponentModel.Composition;
using citPOINT.eNeg.Infrastructure.ExceptionHandling;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;
using citPOINT.eNeg.Apps.Common.Interfaces;
#endregion

#region → History  .

/* Date         User              Change
 * 
 * 10.01.12     M.Wahab       Creation
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
    /// Main Page View.
    /// </summary>
    [Export]
    public partial class MainPageView : UserControl, ICleanup, IObserverApp
    {
        #region → Fields         .
        private NegotiationSettingsView mNegotiationSettingsView;
        private AlarmView mAlarmView;
        private ExtendConversationView mExtendConversationView;
        private ConversationsView mConversationsView;
        #endregion

        #region → Properties     .
        /// <summary>
        /// Gets or sets the view model repository.
        /// </summary>
        /// <value>The view model repository.</value>
        private ViewModelRepository ViewModelRepository { get; set; }

        /// <summary>
        /// Gets the name of the app.
        /// </summary>
        /// <value>The name of the app.</value>
        public string AppName
        {
            get { return StrategyAppConfigurations.AppName; }
        }

        /// <summary>
        /// Gets the conversation view.
        /// </summary>
        /// <value>The conversation view.</value>
        public ConversationsView ConversationsView
        {
            get
            {
                if (mConversationsView == null)
                {
                    mConversationsView = new ConversationsView();
                }
                return mConversationsView;
            }
        }

        /// <summary>
        /// Gets the negotiation settings view.
        /// </summary>
        /// <value>The negotiation settings view.</value>
        public NegotiationSettingsView NegotiationSettingsView
        {
            get
            {
                if (mNegotiationSettingsView == null)
                {
                    mNegotiationSettingsView = new NegotiationSettingsView();
                }
                return mNegotiationSettingsView;
            }
        }

        /// <summary>
        /// Gets the alarm view.
        /// </summary>
        /// <value>The alarm view.</value>
        public AlarmView AlarmView
        {
            get
            {
                if (mAlarmView == null)
                {
                    mAlarmView = new AlarmView();
                }
                return mAlarmView;
            }
        }

        /// <summary>
        /// Gets the extend conversation view.
        /// </summary>
        /// <value>The extend conversation view.</value>
        public ExtendConversationView ExtendConversationView
        {
            get
            {
                if (mExtendConversationView == null)
                {
                    mExtendConversationView = new ExtendConversationView();
                }
                return mExtendConversationView;
            }
        }

        #endregion

        #region → Constructor    .
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageView"/> class.
        /// </summary>
        public MainPageView()
        {
            InitializeComponent();

            #region Registration for needed messages in StrategyAppMessanger

            StrategyAppMessanger.RaiseErrorMessage.Register(this, OnRaiseErrorMessage);

            StrategyAppMessanger.ChangeScreenMessage.Register(this, OnChangeScreen);

            #endregion

            try
            {
                this.ApplyChanges(false);

                StrategyAppConfigurations.MainPlatformInfo.TrackChanges.AddObserverApp(this);
            }
            catch (Exception ex)
            {
                StrategyAppConfigurations.MainPlatformInfo.HandleException.HandleException(ex, StrategyAppConfigurations.AppName);
            }
        }
        #endregion

        #region → Methods        .

        #region → Private        .

        /// <summary>
        /// Raise error message if there is any layer send RaiseErrorMessage
        /// </summary>
        /// <param name="ex"></param>
        private void OnRaiseErrorMessage(Exception ex)
        {
            StrategyAppConfigurations.MainPlatformInfo.HandleException.HandleException(ex, StrategyAppConfigurations.AppName);
        }

        /// <summary>
        /// Called when [change screen].
        /// </summary>
        /// <param name="screenName">Name of the screen.</param>
        public void OnChangeScreen(string screenName)
        {
            this.uxgrdLoading.Visibility = System.Windows.Visibility.Collapsed;

            switch (screenName)
            {
                case StrategyAppViewTypes.ConversationsView:
                    this.uxMainContent.Content = this.ConversationsView;
                    break;

                case StrategyAppViewTypes.NegotiationSettingsView:
                    this.uxMainContent.Content = this.NegotiationSettingsView;
                    break;

                case StrategyAppViewTypes.ConstrainAlarmView:
                    this.uxMainContent.Content = this.AlarmView;
                    break;

                case StrategyAppViewTypes.ShowOutOfRangeView:
                    this.uxMainContent.Content = this.ExtendConversationView;
                    break;
            }
        }
        #endregion

        #region → Public         .

        /// <summary>
        /// Applies the changes.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public void ApplyChanges(bool isActive)
        {
            if (isActive)
            {
                this.uxgrdLoading.Visibility = System.Windows.Visibility.Visible;

                #region → Change Negotiation      .

                if (StrategyAppConfigurations.MainPlatformInfo.CurrentNegotiation != null)
                {
                    StrategyAppConfigurations.NegotiationIDParameter = StrategyAppConfigurations.MainPlatformInfo.CurrentNegotiation.NegotiationID;
                }
                else
                {
                    StrategyAppConfigurations.NegotiationIDParameter = Guid.Empty;
                }

                #endregion

                #region → Change Conversation     .

                if (StrategyAppConfigurations.MainPlatformInfo.CurrentConversation != null)
                {
                    StrategyAppConfigurations.ConversationIDParameter = StrategyAppConfigurations.MainPlatformInfo.CurrentConversation.ConversationID;
                }
                else
                {
                    StrategyAppConfigurations.ConversationIDParameter = Guid.Empty;
                }

                #endregion

                #region → Change User             .

                if (StrategyAppConfigurations.CurrentLoginUser != null && StrategyAppConfigurations.CurrentLoginUser.UserID != StrategyAppConfigurations.MainPlatformInfo.UserInfo.UserID)
                {
                    if (this.ViewModelRepository != null)
                    {
                        this.ViewModelRepository.Cleanup();

                        this.ViewModelRepository = null;
                    }
                }

                StrategyAppConfigurations.CurrentLoginUser = StrategyAppConfigurations.MainPlatformInfo.UserInfo;

                #endregion

                #region → View Model Repository   .

                if (ViewModelRepository != null)
                {
                    ViewModelRepository.ManageStrategyViewModel.ApplyChanges();
                }
                else
                {
                    ViewModelRepository = new ViewModelRepository();
                }

                this.DataContext = ViewModelRepository.ManageStrategyViewModel;

                #endregion

                #region → Adjust Widht and Heihgt .

                this.uxMainContent.Width = StrategyAppConfigurations.MainPlatformInfo.HostRegionSizeDetails.Width;
                this.uxMainContent.MinWidth = this.uxMainContent.Width;
                this.uxMainContent.MaxWidth = this.uxMainContent.Width;

                this.uxMainContent.Height = StrategyAppConfigurations.MainPlatformInfo.HostRegionSizeDetails.Height;
                this.uxMainContent.MinHeight = this.uxMainContent.Height;
                this.uxMainContent.MaxHeight = this.uxMainContent.Height;

                #endregion

            }
            else
            {
                this.uxgrdLoading.Visibility = System.Windows.Visibility.Visible;
            }
        }


        /// <summary>
        /// Cleanups this instance.
        /// </summary>
        public void Cleanup()
        {
            Messenger.Default.Unregister(this);
        }

        #endregion  Public

        #endregion Methods

    }
}
