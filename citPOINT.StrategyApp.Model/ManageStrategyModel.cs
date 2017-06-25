#region → Usings   .
using System;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using citPOINT.eNeg.Common;
using System.ServiceModel.DomainServices.Client;
using System.ComponentModel.Composition;
using System.Threading;
using citPOINT.StrategyApp.Data.Web;
using citPOINT.StrategyApp.Common;
#endregion

#region → History  .

/* 
 * Date         User            Change
 * *********************************************
 * 12.01.12     Yousra         • creation
 * **********************************************
 */

# endregion

#region → ToDos    .

/*
 * Date         set by User     Description
 * 
 * 
*/

# endregion

namespace citPOINT.StrategyApp.Model
{
    #region  Using MEF to export ManageStrategyModel
    /// <summary>
    /// Model Layer for managing user strategy.
    /// </summary>
    [Export(typeof(IManageStrategyModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    #endregion
    public class ManageStrategyModel : IManageStrategyModel
    {
        #region → Fields         .
        private StrategyAppContext mContext;
        private Boolean mHasChanges = false;
        private Boolean mIsBusy = false;
        #endregion

        #region → Properties     .

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        private StrategyAppContext Context
        {
            get
            {
                if (mContext == null)
                {
                    if (mContext == null)
                    {
                        mContext = new StrategyAppContext(StrategyAppConfigurations.MainServiceUri);
                    }
                    mContext.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ctx_PropertyChanged);
                }

                return mContext;
            }
        }

        /// <summary>
        /// True if _ctx.HasChanges is true; otherwise, false
        /// </summary>
        public Boolean HasChanges
        {
            get
            {
                return this.mHasChanges;
            }

            private set
            {
                if (this.mHasChanges != value)
                {
                    this.mHasChanges = value;
                    this.OnPropertyChanged("HasChanges");
                }
            }
        }

        /// <summary>
        /// True if either "IsLoading" or "IsSubmitting" is
        /// in progress; otherwise, false
        /// </summary>
        public Boolean IsBusy
        {
            get
            {
                return this.mIsBusy;
            }

            private set
            {
                if (this.mIsBusy != value)
                {
                    this.mIsBusy = value;
                    this.OnPropertyChanged("IsBusy");
                }
            }
        }

        #endregion Properties

        public ManageStrategyModel()
        {

        }
        #region → Event Handlers .

        /// <summary>
        /// Private Event Handler that called after any change in 
        /// HasChanges, IsLoading, IsSubmitting properties
        /// </summary>
        /// <param name="sender">Value of Sender</param>
        /// <param name="e">Value of e</param>
        private void ctx_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "HasChanges":
                    this.HasChanges = mContext.HasChanges;
                    break;
                case "IsLoading":
                    this.IsBusy = mContext.IsLoading;
                    break;
                case "IsSubmitting":
                    this.IsBusy = mContext.IsSubmitting;
                    break;
            }
        }
        #endregion

        #region → Events         .

        /// <summary>
        /// Event Handler For Method PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when [get conversation strategy settings complete].
        /// </summary>
        public event EventHandler<eNegEntityResultArgs<ConversationStrategySetting>> GetConversationStrategySettingsComplete;

        /// <summary>
        /// Occurs when [get negotiation strategy settings complete].
        /// </summary>
        public event EventHandler<eNegEntityResultArgs<NegotiationStrategySetting>> GetNegotiationStrategySettingsComplete;

        /// <summary>
        /// Occurs when [get strategy type complete].
        /// </summary>
        public event EventHandler<eNegEntityResultArgs<StrategyType>> GetStrategyTypeComplete;

        /// <summary>
        /// Occurs when [get conversation period complete].
        /// </summary>
        public event EventHandler<eNegEntityResultArgs<ConversationPeriod>> GetConversationPeriodComplete;

        /// <summary>
        /// Occurs when [get negotiation period complete].
        /// </summary>
        public event EventHandler<eNegEntityResultArgs<ConversationPeriod>> GetNegotiationPeriodComplete;

        /// <summary>
        /// Occurs when [get preference set for negotiation complete].
        /// </summary>
        public event EventHandler<eNegEntityResultArgs<PreferenceSet>> GetPreferenceSetForNegotiationComplete;

        /// <summary>
        /// Occurs when [get last offer for conversation complete].
        /// </summary>
        public event EventHandler<eNegEntityResultArgs<LastOfferDetails>> GetLastOfferForConversationComplete;

        /// <summary>
        /// SaveChangesComplete
        /// </summary>
        public event EventHandler<SubmitOperationEventArgs> SaveChangesComplete;

        #endregion

        #region → Methods        .

        #region → Private        .

        /// <summary>
        /// Private Method used to perform query on certain entity of eNeg Entities
        /// </summary>
        /// <typeparam name="T">Value Of T</typeparam>
        /// <param name="qry">Value Of qry</param>
        /// <param name="evt">Value Of evt</param>
        private void PerformQuery<T>(EntityQuery<T> qry, EventHandler<eNegEntityResultArgs<T>> evt) where T : Entity
        {
            Context.Load<T>(qry, LoadBehavior.RefreshCurrent, r =>
            {
                if (evt != null)
                {
                    try
                    {
                        if (r.HasError)
                        {
                            evt(this, new eNegEntityResultArgs<T>(r.Error));
                            r.MarkErrorAsHandled();
                        }
                        else
                        {
                            evt(this, new eNegEntityResultArgs<T>(r.Entities));
                        }
                    }
                    catch (Exception ex)
                    {
                        evt(this, new eNegEntityResultArgs<T>(ex));
                    }
                }
            }, null);
        }

        #endregion

        #region → Protected      .

        #region INotifyPropertyChanged Interface implementation

        /// <summary>
        /// Handle changes in any Property
        /// </summary>
        /// <param name="propertyName">Property Name</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #endregion

        #region → Public         .

        /// <summary>
        /// Gets the conversation strategy settings async.
        /// </summary>
        public void GetConversationStrategySettingsAsync()
        {
            PerformQuery<ConversationStrategySetting>(Context.GetConversationStrategySettingsByConvIDQuery(StrategyAppConfigurations.ConversationIDParameter),
                GetConversationStrategySettingsComplete);
        }

        /// <summary>
        /// Gets the negotiation strategy settings async.
        /// </summary>
        public void GetNegotiationStrategySettingsAsync()
        {
            PerformQuery<NegotiationStrategySetting>(Context.GetNegotiationStrategySettingsByNegIDQuery(StrategyAppConfigurations.NegotiationIDParameter),
                GetNegotiationStrategySettingsComplete);
        }

        /// <summary>
        /// Gets the strategy type async.
        /// </summary>
        public void GetStrategyTypeAsync()
        {
            PerformQuery<StrategyType>(Context.GetStrategyTypesQuery(), GetStrategyTypeComplete);
        }
        
        /// <summary>
        /// Gets the negotiation period async.
        /// </summary>
        public void GetNegotiationPeriodAsync()
        {
            PerformQuery<ConversationPeriod>(Context.GetNegotiationPeriodQuery(StrategyAppConfigurations.NegotiationIDParameter),
                GetNegotiationPeriodComplete);
        }

        /// <summary>
        /// Gets the conversation period async.
        /// </summary>
        public void GetConversationPeriodAsync()
        {
            PerformQuery<ConversationPeriod>(Context.GetConversationPeriodQuery(StrategyAppConfigurations.ConversationIDParameter),
                GetConversationPeriodComplete);
        }

        /// <summary>
        /// Gets the preference set for negotiation async.
        /// </summary>
        public void GetPreferenceSetForNegotiationAsync()
        {
            PerformQuery<PreferenceSet>(Context.GetPreferenceSetForNegotiationQuery(StrategyAppConfigurations.NegotiationIDParameter),
                GetPreferenceSetForNegotiationComplete);
        }

        /// <summary>
        /// Gets the last offer for conversation async.
        /// </summary>
        public void GetLastOfferForConversationAsync()
        {
            PerformQuery<LastOfferDetails>(Context.GetLastOfferForConversationQuery(StrategyAppConfigurations.ConversationIDParameter, true),
                GetLastOfferForConversationComplete);
        }

        /// <summary>
        /// Adds the negotiation strategy settings.
        /// </summary>
        /// <param name="defaultStrategyTypeID">The default strategy type ID.</param>
        /// <param name="setInContext">if set to <c>true</c> [set in context].</param>
        /// <returns></returns>
        public NegotiationStrategySetting AddNegotiationStrategySettings(int defaultStrategyTypeID, bool setInContext)
        {
            NegotiationStrategySetting NegStrategySetting = new NegotiationStrategySetting()
            {
                NegotiationStrategySettingsID = Guid.NewGuid(),
                NegotiationID = StrategyAppConfigurations.NegotiationIDParameter,
                StrategyTypeID = defaultStrategyTypeID,
                BetaValue=1,
                DefaultStartDate = DateTime.Now,
                DefaultEndDate = DateTime.Now.AddDays(7),
                Deleted = false,
                DeletedBy = StrategyAppConfigurations.CurrentLoginUser.UserID,
                DeletedOn = DateTime.Now
            };

            if (setInContext)
            {
                this.Context.NegotiationStrategySettings.Add(NegStrategySetting);
            }
            return NegStrategySetting;
        }

        /// <summary>
        /// Adds the conversation strategy settings.
        /// </summary>
        /// <param name="parentNegStrategySettingID">The parent neg strategy setting ID.</param>
        /// <param name="setInContext">if set to <c>true</c> [set in context].</param>
        /// <returns></returns>
        public ConversationStrategySetting AddConversationStrategySettings(Guid parentNegStrategySettingID, bool setInContext)
        {
            ConversationStrategySetting ConvStrategySetting = new ConversationStrategySetting()
            {
                ConversationStrategySettingsID = Guid.NewGuid(),
                ConversationID = StrategyAppConfigurations.ConversationIDParameter,
                NegotiationStrategySettingsID = parentNegStrategySettingID,
                StrategyTypeID =1,
                BetaValue = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                Deleted = false,
                DeletedBy = StrategyAppConfigurations.CurrentLoginUser.UserID,
                DeletedOn = DateTime.Now
            };

            if (setInContext)
            {
                this.Context.ConversationStrategySettings.Add(ConvStrategySetting);
            }
            return ConvStrategySetting;
        }

        /// <summary>
        /// Save changes asynchronously
        /// </summary>
        public void SaveChangesAsync()
        {
            this.Context.SubmitChanges(s =>
            {
                if (SaveChangesComplete != null)
                {
                    try
                    {
                        Exception ex = null;
                        if (s.HasError)
                        {
                            ex = s.Error;
                            s.MarkErrorAsHandled();
                        }
                        SaveChangesComplete(this, new SubmitOperationEventArgs(s, ex));
                    }
                    catch (Exception ex)
                    {
                        SaveChangesComplete(this, new SubmitOperationEventArgs(ex));
                    }
                }
            }, null);
        }

        /// <summary>
        /// Reject all changes happen on current Context
        /// </summary>
        public void RejectChanges()
        {
            this.Context.RejectChanges();
        }

        /// <summary>
        /// Cleanups this instance.
        /// </summary>
        public void Cleanup()
        {
            this.RejectChanges();

            this.mContext.PreferenceSets.Clear();

            this.mContext.NegotiationStrategySettings.Clear();

            this.mContext.ExpectedTargets.Clear();

            this.mContext.LastOfferDetails.Clear();

            this.mContext.ConversationPeriods.Clear();

            this.mContext.ConversationStrategySettings.Clear();
        }

        #endregion

        #endregion

    }
}



