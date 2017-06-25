
#region → Usings   .

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using citPOINT.eNeg.Common;
using citPOINT.StrategyApp.Common;
using citPOINT.StrategyApp.Data.Web;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;

#endregion

#region → History  .

/* Date         User            Change
 * 
 * 15.01.12     M.Wahab     • creation
 */

# endregion

#region → ToDos    .

/*
 * Date         set by User     Description
 * 
 * 
*/

# endregion

namespace citPOINT.StrategyApp.ViewModel
{
    #region → Using  MEF to export Manage Strategy View Model.
    /// <summary>
    /// this class is to Manage Strategy View Model.
    /// </summary>
    [Export(StrategyAppViewModelTypes.ManageStrategyViewModel)]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    #endregion
    public class ManageStrategyViewModel : ViewModelBase
    {
        #region → Fields         .

        private IManageStrategyModel mManageStrategyModel;

        private string mStatus = Resources.StrategyStutasDefault;
        private string mAdvice = Resources.StrategyAdviceDefault;

        private bool mIsStrategyGreen = false;
        private bool mIsStrategyRed = true;
        private bool RunQueueForApplyChanges = false;
        private bool mIsBusy;

        private List<StrategyType> mStrategyTypeSource;
        private NegotiationStrategySetting mCurrentNegotiationSetting;
        private ConversationStrategySetting mCurrentConversationSetting;
        private PreferenceSet mCurrentPreferenceSet;
        private LastOfferDetails mLastOffer;
        private ConversationPeriod mConversationPeriod;
        private ConversationPeriod mNegotiationPeriod;

        private RelayCommand mSubmitChangeCommand;
        private RelayCommand mBackToMainViewCommand;


        #endregion

        #region → Properties     .

        /// <summary>
        /// Gets or sets a value indicating whether this instance is busy.
        /// </summary>
        /// <value><c>true</c> if this instance is busy; otherwise, <c>false</c>.</value>
        public bool IsBusy
        {
            get { return mIsBusy; }
            set
            {
                mIsBusy = value;
                this.RaisePropertyChanged("IsBusy");

                if (!this.IsBusy)
                {
                    if (RunQueueForApplyChanges)
                    {
                        ApplyChanges();
                    }
                }
            }
        }


        /// <summary>
        /// Gets or sets the strategy type source.
        /// </summary>
        /// <value>The strategy type source.</value>
        public List<StrategyType> StrategyTypeSource
        {
            get { return mStrategyTypeSource; }
            set
            {
                mStrategyTypeSource = value;
                this.RaisePropertyChanged("StrategyTypeSource");
            }
        }

        /// <summary>
        /// Gets or sets the current preference set.
        /// </summary>
        /// <value>The current preference set.</value>
        public PreferenceSet CurrentPreferenceSet
        {
            get { return mCurrentPreferenceSet; }
            set
            {
                mCurrentPreferenceSet = value;
                this.RaisePropertyChanged("CurrentPreferenceSet");
            }
        }

        /// <summary>
        /// Gets or sets the current negotiation setting.
        /// </summary>
        /// <value>The current negotiation setting.</value>
        public NegotiationStrategySetting CurrentNegotiationSetting
        {
            get { return mCurrentNegotiationSetting; }
            set
            {
                mCurrentNegotiationSetting = value;
                this.RaisePropertyChanged("CurrentNegotiationSetting");
            }
        }

        /// <summary>
        /// Gets or sets the current Conversation setting.
        /// </summary>
        /// <value>The current Conversation setting.</value>
        public ConversationStrategySetting CurrentConversationSetting
        {
            get { return mCurrentConversationSetting; }
            set
            {
                mCurrentConversationSetting = value;
                this.RaisePropertyChanged("CurrentConversationSetting");
            }
        }

        /// <summary>
        /// Gets or sets the last offer.
        /// </summary>
        /// <value>The last offer.</value>
        public LastOfferDetails LastOffer
        {
            get
            {
                return mLastOffer;
            }
            set
            {
                mLastOffer = value;
                this.RaisePropertyChanged("LastOffer");
            }
        }

        /// <summary>
        /// Gets or sets the negotiation period.
        /// </summary>
        /// <value>The negotiation period.</value>
        public ConversationPeriod NegotiationPeriod
        {
            get
            {
                return mNegotiationPeriod;
            }
            set
            {
                mNegotiationPeriod = value;
                this.RaisePropertyChanged("NegotiationPeriod");
            }
        }

        /// <summary>
        /// Gets or sets the conversation period.
        /// </summary>
        /// <value>The conversation period.</value>
        public ConversationPeriod ConversationPeriod
        {
            get
            {
                return mConversationPeriod;
            }
            set
            {
                mConversationPeriod = value;
                this.RaisePropertyChanged("ConversationPeriod");
            }
        }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string Status
        {
            get { return mStatus; }
            set
            {
                mStatus = value;
                this.RaisePropertyChanged("Status");
            }
        }

        /// <summary>
        /// Gets or sets the advice.
        /// </summary>
        /// <value>The advice.</value>
        public string Advice
        {
            get { return mAdvice; }
            set
            {
                mAdvice = value;
                this.RaisePropertyChanged("Advice");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is strategy green.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is strategy green; otherwise, <c>false</c>.
        /// </value>
        public bool IsStrategyGreen
        {
            get
            {
                return mIsStrategyGreen;
            }
            set
            {
                mIsStrategyGreen = value;
                this.RaisePropertyChanged("IsStrategyGreen");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is strategy red.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is strategy red; otherwise, <c>false</c>.
        /// </value>
        public bool IsStrategyRed
        {
            get
            {
                return mIsStrategyRed;
            }
            set
            {
                mIsStrategyRed = value;
                this.RaisePropertyChanged("IsStrategyRed");
            }
        }

        #endregion

        #region → Constructors   .

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageStrategyViewModel"/> class.
        /// </summary>
        /// <param name="ManageStrategyModel">The manage strategy model.</param>
        [ImportingConstructor]
        public ManageStrategyViewModel(IManageStrategyModel ManageStrategyModel)
        {
            this.mManageStrategyModel = ManageStrategyModel;

            #region → Set up event handling       .

            this.mManageStrategyModel.GetConversationPeriodComplete += new EventHandler<eNegEntityResultArgs<ConversationPeriod>>(mManageStrategyModel_GetConversationPeriodComplete);
            this.mManageStrategyModel.GetConversationStrategySettingsComplete += new EventHandler<eNegEntityResultArgs<ConversationStrategySetting>>(mManageStrategyModel_GetConversationStrategySettingsComplete);
            this.mManageStrategyModel.GetLastOfferForConversationComplete += new EventHandler<eNegEntityResultArgs<LastOfferDetails>>(mManageStrategyModel_GetLastOfferForConversationComplete);
            this.mManageStrategyModel.GetNegotiationStrategySettingsComplete += new EventHandler<eNegEntityResultArgs<NegotiationStrategySetting>>(mManageStrategyModel_GetNegotiationStrategySettingsComplete);
            this.mManageStrategyModel.GetNegotiationPeriodComplete += new EventHandler<eNegEntityResultArgs<Data.Web.ConversationPeriod>>(mManageStrategyModel_GetNegotiationPeriodComplete);

            this.mManageStrategyModel.GetPreferenceSetForNegotiationComplete += new EventHandler<eNegEntityResultArgs<PreferenceSet>>(mManageStrategyModel_GetPreferenceSetForNegotiationComplete);
            this.mManageStrategyModel.GetStrategyTypeComplete += new EventHandler<eNegEntityResultArgs<StrategyType>>(mManageStrategyModel_GetStrategyTypeComplete);
            this.mManageStrategyModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(mManageStrategyModel_PropertyChanged);
            this.mManageStrategyModel.SaveChangesComplete += new EventHandler<SubmitOperationEventArgs>(mManageStrategyModel_SaveChangesComplete);
            #endregion

            #region → Load Lookup tables          .
            this.GetStrategyTypeAsync();
            this.GetPreferenceSetForNegotiationAsync();
            #endregion

            #region → Register Messages           .
            // register for SubmitChangesMessage
            StrategyAppMessanger.SubmitChangesMessage.Register(this, OnSubmitChanges);
            #endregion Register Messages
        }

        #endregion

        #region → Event Handlers .

        /// <summary>
        /// Call back of Get preference set for negotiation.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void mManageStrategyModel_GetPreferenceSetForNegotiationComplete(object sender, eNegEntityResultArgs<PreferenceSet> e)
        {
            if (!e.HasError)
            {
                if (e.Results.FirstOrDefault() != null)
                {
                    this.CurrentPreferenceSet = e.Results.FirstOrDefault();

                    this.GetNegotiationPeriodAsync();

                    this.GetNegotiationStrategySettingsAsync();
                }
                else
                {
                    // Constrain Alarm View [Preference Set must Exist]
                    StrategyAppMessanger.ChangeScreenMessage.Send(StrategyAppViewTypes.ConstrainAlarmView);
                }
            }
            else
            {
                StrategyAppMessanger.RaiseErrorMessage.Send(e.Error);
            }
        }

        /// <summary>
        /// Call back of get strategy type.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void mManageStrategyModel_GetStrategyTypeComplete(object sender, eNegEntityResultArgs<StrategyType> e)
        {
            if (!e.HasError)
            {
                this.StrategyTypeSource = e.Results.OrderBy(s => s.StrategyTypeName).ToList();
            }
            else
            {
                StrategyAppMessanger.RaiseErrorMessage.Send(e.Error);
            }
        }

        /// <summary>
        /// Call Back of negotiation strategy settings.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void mManageStrategyModel_GetNegotiationStrategySettingsComplete(object sender, eNegEntityResultArgs<NegotiationStrategySetting> e)
        {
            if (!e.HasError)
            {
                if (e.Results != null && e.Results.Count() > 0)
                {
                    this.CurrentNegotiationSetting = e.Results.FirstOrDefault();
                }
                else //First Time to add Settings.
                {
                    this.CurrentNegotiationSetting = this.AddNegotiationStrategySettings();
                }

                #region → Related To Conversation .

                if (StrategyAppConfigurations.ConversationIDParameter != Guid.Empty)
                {
                    this.GetLastOfferForConversationAsync();

                    this.GetConversationPeriodAsync();

                    this.GetConversationStrategySettingsAsync();
                }
                else
                {
                    StrategyAppMessanger.ChangeScreenMessage.Send(StrategyAppViewTypes.NegotiationSettingsView);
                }

                #endregion

            }
            else
            {
                StrategyAppMessanger.RaiseErrorMessage.Send(e.Error);
            }
        }

        /// <summary>
        /// Call back of Get last offer for conversation complete.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void mManageStrategyModel_GetLastOfferForConversationComplete(object sender, eNegEntityResultArgs<LastOfferDetails> e)
        {
            if (!e.HasError)
            {
                if (e.Results != null && e.Results.Count() > 0)
                {
                    this.LastOffer = e.Results.FirstOrDefault();

                    //Re-calculate if the new strategy fits the offers or not
                    RunStrategyAgent();
                }
            }
            else
            {
                StrategyAppMessanger.RaiseErrorMessage.Send(e.Error);
            }
        }

        /// <summary>
        /// Call back of Get conversation strategy settings complete.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void mManageStrategyModel_GetConversationStrategySettingsComplete(object sender, eNegEntityResultArgs<ConversationStrategySetting> e)
        {
            if (!e.HasError)
            {
                if (e.Results != null && e.Results.Count() > 0)
                {
                    this.CurrentConversationSetting = e.Results.FirstOrDefault();

                    StrategyAppMessanger.ChangeScreenMessage.Send(StrategyAppViewTypes.ConversationsView);

                    //Check if any message out of period
                    IsAnyMessageOutOfPeriod();

                    //Re-calculate if the new strategy fits the offers or not
                    RunStrategyAgent();
                }
                else //First Time to add settings.
                {
                    this.CurrentConversationSetting = this.AddConversationStrategySettings();

                    StrategyAppMessanger.ChangeScreenMessage.Send(StrategyAppViewTypes.ConversationsView);
                }

                this.RaiseCanExecuteChanged();
            }
            else
            {
                StrategyAppMessanger.RaiseErrorMessage.Send(e.Error);
            }
        }

        /// <summary>
        /// Call back of Get negotiation period complete.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void mManageStrategyModel_GetNegotiationPeriodComplete(object sender, eNegEntityResultArgs<ConversationPeriod> e)
        {
            if (!e.HasError)
            {
                if (e.Results != null && e.Results.Count() > 0)
                {
                    this.NegotiationPeriod = e.Results.FirstOrDefault();

                    //Ajust as we not know which first will be get
                    //Negotiation settings or Negotiation Period
                    AdjustNegotiationToWholePeriod(this.CurrentNegotiationSetting);
                }
            }
            else
            {
                StrategyAppMessanger.RaiseErrorMessage.Send(e.Error);
            }
        }

        /// <summary>
        /// Call back of Get conversation period complete.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void mManageStrategyModel_GetConversationPeriodComplete(object sender, eNegEntityResultArgs<ConversationPeriod> e)
        {
            if (!e.HasError)
            {
                if (e.Results != null && e.Results.Count() > 0)
                {
                    this.ConversationPeriod = e.Results.FirstOrDefault();

                    //Check if any message out of period
                    IsAnyMessageOutOfPeriod();

                    //Ajust as we not know which first will be get
                    //Conversation settings or ConversationPeriod
                    AdjustConversationToWholePeriod(this.CurrentConversationSetting);
                }
            }
            else
            {
                StrategyAppMessanger.RaiseErrorMessage.Send(e.Error);
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of the mManageStrategyModel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void mManageStrategyModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("HasChanges") || e.PropertyName.Equals("IsBusy"))
            {
                this.IsBusy = this.mManageStrategyModel.IsBusy;
                this.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Handles the SaveChangesComplete event of the mManageStrategyModel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="citPOINT.eNeg.Common.SubmitOperationEventArgs"/> instance containing the event data.</param>
        private void mManageStrategyModel_SaveChangesComplete(object sender, SubmitOperationEventArgs e)
        {
            if (!e.HasError)
            {
                this.RaiseCanExecuteChanged();

                //Re-calculate if the new strategy fits the offers or not
                RunStrategyAgent();
            }
            else
            {
                // notify user if there is any error
                StrategyAppMessanger.RaiseErrorMessage.Send(e.Error);
            }
        }

        #endregion

        #region → Commands       .

        /// <summary>
        /// User Save changes via Calling SubmitChangesMessage so It call
        /// OnSubmitChangesMessage Method.
        /// </summary>
        /// <value>The submit change command.</value>
        public RelayCommand SubmitChangeCommand
        {
            get
            {
                if (mSubmitChangeCommand == null)
                {
                    mSubmitChangeCommand = new RelayCommand(() =>
                    {
                        try
                        {

                            if (!IsNegotiationValid() &&
                                StrategyAppConfigurations.ConversationIDParameter == Guid.Empty) //Mean Settings for negotiation Only
                            {
                                return;
                            }

                            if (StrategyAppConfigurations.ConversationIDParameter != Guid.Empty && CurrentConversationSetting != null &&
                                !IsConversationValid())
                            {
                                return;
                            }

                            if (this.mManageStrategyModel.HasChanges)
                            {
                                StrategyAppMessanger.SubmitChangesMessage.Send();
                            }

                        }
                        catch (Exception ex)
                        {
                            // notify user if there is any error
                            StrategyAppMessanger.RaiseErrorMessage.Send(ex);
                        }
                    }
                    , () => !this.mManageStrategyModel.IsBusy &&
                        (this.mManageStrategyModel.HasChanges));
                }
                return mSubmitChangeCommand;
            }
        }

        /// <summary>
        /// Gets the back to main view command.
        /// </summary>
        /// <value>The back to main view command.</value>
        public RelayCommand BackToMainViewCommand
        {
            get
            {
                if (mBackToMainViewCommand == null)
                {
                    mBackToMainViewCommand = new RelayCommand(() =>
                    {
                        try
                        {
                            if (!mManageStrategyModel.IsBusy)
                            {
                                this.RejectChanges();

                                StrategyAppMessanger.ChangeScreenMessage.Send(StrategyAppViewTypes.ConversationsView);
                            }
                        }
                        catch (Exception ex)
                        {
                            // notify user if there is any error
                            StrategyAppMessanger.RaiseErrorMessage.Send(ex);
                        }
                    }
                    , () => this.CurrentConversationSetting != null &&
                            this.CurrentConversationSetting.EntityState != EntityState.New);
                }
                return mBackToMainViewCommand;
            }
        }

        #endregion

        #region → Methods        .

        #region → Private        .

        /// <summary>
        /// Called when [submit changes].
        /// </summary>
        /// <param name="flag">if set to <c>true</c> [flag].</param>
        private void OnSubmitChanges(Boolean flag)
        {
            this.mManageStrategyModel.SaveChangesAsync();
        }

        /// <summary>
        /// Raises the can execute changed.
        /// </summary>
        private void RaiseCanExecuteChanged()
        {
            this.SubmitChangeCommand.RaiseCanExecuteChanged();
            this.BackToMainViewCommand.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Determines whether [is negotiation valid].
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if [is negotiation valid]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsNegotiationValid()
        {
            bool isAllValid = true;

            if (CurrentNegotiationSetting != null)
            {
                CurrentNegotiationSetting.ValidationErrors.Clear();

                if (!CurrentNegotiationSetting.TryValidateObject())
                {
                    isAllValid = false;
                }

                #region → Check Strategy Type .

                if (CurrentNegotiationSetting.StrategyTypeID == 0)
                {
                    CurrentNegotiationSetting.ValidationErrors
                                             .Add(new ValidationResult(Resources.MustFillStrategyType, new string[] { "StrategyType" }));

                    isAllValid = false;
                }

                if (this.CurrentNegotiationSetting.StrategyTypeID == StrategyAppConstant.StrategyType.Other)
                {
                    if (!CurrentNegotiationSetting.BetaValue.HasValue || CurrentNegotiationSetting.BetaValue.Value <= 0)
                    {
                        CurrentNegotiationSetting
                        .ValidationErrors
                        .Add(new ValidationResult(Resources.PositiveValue, new string[] { "BetaValue" }));
                        isAllValid = false;
                    }
                }

                #endregion

                #region → Check Period        .

                if (CurrentNegotiationSetting.DefaultStartDate > CurrentNegotiationSetting.DefaultEndDate)
                {
                    CurrentNegotiationSetting.ValidationErrors
                                             .Add(new ValidationResult(Resources.InValidDateRange,
                                                 new string[] { "DefaultEndDate" }));

                    isAllValid = false;
                }


                if (NegotiationPeriod != null)
                {

                    if (CurrentNegotiationSetting.DefaultStartDate > NegotiationPeriod.MinConversationDate)
                    {
                        CurrentNegotiationSetting
                            .ValidationErrors
                            .Add(new ValidationResult(string.Format(Resources.DateRangeStart, NegotiationPeriod.MinConversationDate)
                                , new string[] { "DefaultStartDate" }));
                        isAllValid = false;
                    }


                    if (CurrentNegotiationSetting.DefaultEndDate < NegotiationPeriod.MaxConversationDate)
                    {
                        CurrentNegotiationSetting
                            .ValidationErrors
                            .Add(new ValidationResult(string.Format(Resources.DateRangeEnd, NegotiationPeriod.MaxConversationDate)
                                , new string[] { "DefaultEndDate" }));
                        isAllValid = false;
                    }

                }


                #endregion
            }

            return isAllValid;
        }

        /// <summary>
        /// Determines whether [is conversation valid].
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if [is conversation valid]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsConversationValid()
        {
            bool isAllValid = true;

            if (CurrentConversationSetting != null)
            {
                CurrentConversationSetting.ValidationErrors.Clear();

                if (!CurrentConversationSetting.TryValidateObject())
                {
                    isAllValid = false;
                }

                #region → Check Strategy Type .


                if (CurrentConversationSetting.StrategyTypeID == 0)
                {
                    CurrentConversationSetting.ValidationErrors.Add(new ValidationResult(Resources.MustFillStrategyType, new string[] { "StrategyType" }));

                    isAllValid = false;
                }

                if (this.CurrentConversationSetting.StrategyTypeID == StrategyAppConstant.StrategyType.Other)
                {
                    if (!CurrentConversationSetting.BetaValue.HasValue || CurrentConversationSetting.BetaValue.Value <= 0)
                    {
                        CurrentConversationSetting
                        .ValidationErrors
                        .Add(new ValidationResult(Resources.PositiveValue, new string[] { "BetaValue" }));
                        isAllValid = false;
                    }
                }

                #endregion

                #region → Check Period        .

                if (CurrentConversationSetting.StartDate > CurrentConversationSetting.EndDate)
                {
                    CurrentConversationSetting.ValidationErrors.Add(new ValidationResult(Resources.InValidDateRange, new string[] { "EndDate" }));

                    isAllValid = false;
                }

                if (ConversationPeriod != null)
                {

                    if (CurrentConversationSetting.StartDate > ConversationPeriod.MinConversationDate)
                    {
                        CurrentConversationSetting
                            .ValidationErrors
                            .Add(new ValidationResult(string.Format(Resources.DateRangeStart, ConversationPeriod.MinConversationDate)
                                , new string[] { "StartDate" }));
                        isAllValid = false;
                    }

                    if (CurrentConversationSetting.EndDate < ConversationPeriod.MaxConversationDate)
                    {
                        CurrentConversationSetting
                            .ValidationErrors
                            .Add(new ValidationResult(string.Format(Resources.DateRangeEnd, ConversationPeriod.MaxConversationDate)
                                , new string[] { "EndDate" }));
                        isAllValid = false;
                    }

                }

                #endregion
            }

            return isAllValid;
        }

        /// <summary>
        /// Rejects the changes.
        /// </summary>
        private void RejectChanges()
        {
            this.mManageStrategyModel.RejectChanges();
        }

        /// <summary>
        /// Runs the strategy agent.
        /// </summary>
        private void RunStrategyAgent()
        {
            if (this.LastOffer != null &&
                this.CurrentConversationSetting != null &&
                this.CurrentConversationSetting.EntityState != EntityState.New)
            {
                try
                {
                    //Intialize the strategy App
                    StrategyAgent strategyAgent
                        = new StrategyAgent(CurrentConversationSetting.StartDate,        //the start date of strategy
                                            CurrentConversationSetting.EndDate,
                                            0.0,                                         //minimum it always 0.0
                                            (double)CurrentPreferenceSet.MaxPercentage,  //the Maximum preference set thresould
                                            (double)CurrentConversationSetting.BetaValue);

                    strategyAgent.RunAgent(this.LastOffer.OfferDate,
                                           (double)LastOffer.Percentage);


                    this.Status = strategyAgent.Status;
                    this.Advice = strategyAgent.Advice;
                    this.IsStrategyGreen = strategyAgent.IsFitsStrategy;
                    this.IsStrategyRed = !strategyAgent.IsFitsStrategy;

                }
                catch (Exception ex)
                {
                    StrategyAppMessanger.RaiseErrorMessage.Send(ex);
                }
            }
        }

        /// <summary>
        /// Is any message out of period.
        /// e.g. if the conversation settings between 1/1/2011 and 31/12/2011 
        /// and user add new message at 01/01/2014 so we should inform the user 
        /// that the period will expanded
        /// </summary>
        private void IsAnyMessageOutOfPeriod()
        {
            if (this.ConversationPeriod != null &&
                this.CurrentConversationSetting != null &&
                this.CurrentConversationSetting.EntityState != EntityState.New)
            {

                if (CurrentConversationSetting.StartDate > ConversationPeriod.MinConversationDate ||
                    CurrentConversationSetting.EndDate < ConversationPeriod.MaxConversationDate)
                {
                    StrategyAppMessanger.ChangeScreenMessage.Send(StrategyAppViewTypes.ShowOutOfRangeView);

                    if (ConversationPeriod.MinConversationDate < CurrentConversationSetting.StartDate)
                    {
                        CurrentConversationSetting.StartDate = ConversationPeriod.MinConversationDate;
                    }

                    if (ConversationPeriod.MaxConversationDate > CurrentConversationSetting.EndDate)
                    {
                        CurrentConversationSetting.EndDate = ConversationPeriod.MaxConversationDate;
                    }

                    SubmitChangeCommand.Execute(null);
                }
            }
        }

        /// <summary>
        /// Adjusts the conversation to whole period.
        /// </summary>
        /// <param name="convsetting">The convsetting.</param>
        private void AdjustConversationToWholePeriod(ConversationStrategySetting convsetting)
        {
            #region → Adjust Conv. to Conversation Period .

            if (ConversationPeriod != null &&
                convsetting != null &&
                convsetting.EntityState == EntityState.New)
            {
                if (ConversationPeriod.MinConversationDate < convsetting.StartDate)
                {
                    convsetting.StartDate = ConversationPeriod.MinConversationDate;
                }

                if (ConversationPeriod.MaxConversationDate > convsetting.EndDate)
                {
                    convsetting.EndDate = ConversationPeriod.MaxConversationDate;
                }
            }

            #endregion
        }

        /// <summary>
        /// Adjusts the negotiation to whole period.
        /// </summary>
        /// <param name="Negsetting">The negsetting.</param>
        private void AdjustNegotiationToWholePeriod(NegotiationStrategySetting Negsetting)
        {
            #region → Adjust Neg. to Negotiation Period .

            if (NegotiationPeriod != null &&
                Negsetting != null &&
                Negsetting.EntityState == EntityState.New)
            {
                if (NegotiationPeriod.MinConversationDate < Negsetting.DefaultStartDate)
                {
                    Negsetting.DefaultStartDate = NegotiationPeriod.MinConversationDate;
                }

                if (NegotiationPeriod.MaxConversationDate > Negsetting.DefaultEndDate)
                {
                    Negsetting.DefaultEndDate = NegotiationPeriod.MaxConversationDate;
                }
            }

            #endregion
        }
        #endregion

        #region → Public         .

        /// <summary>
        /// Gets the strategy type async.
        /// </summary>
        public void GetStrategyTypeAsync()
        {
            mManageStrategyModel.GetStrategyTypeAsync();
        }

        /// <summary>
        /// Gets the preference set for negotiation async.
        /// </summary>
        public void GetPreferenceSetForNegotiationAsync()
        {
            this.mManageStrategyModel.GetPreferenceSetForNegotiationAsync();
        }

        /// <summary>
        /// Gets the negotiation period async.
        /// </summary>
        public void GetNegotiationPeriodAsync()
        {
            this.mManageStrategyModel.GetNegotiationPeriodAsync();
        }

        /// <summary>
        /// Gets the conversation strategy settings async.
        /// </summary>
        public void GetConversationStrategySettingsAsync()
        {
            this.mManageStrategyModel.GetConversationStrategySettingsAsync();
        }

        /// <summary>
        /// Gets the conversation period async.
        /// </summary>
        public void GetConversationPeriodAsync()
        {
            this.mManageStrategyModel.GetConversationPeriodAsync();
        }

        /// <summary>
        /// Gets the negotiation strategy settings async.
        /// </summary>
        public void GetNegotiationStrategySettingsAsync()
        {
            this.mManageStrategyModel.GetNegotiationStrategySettingsAsync();
        }

        /// <summary>
        /// Gets the last offer for conversation async.
        /// </summary>
        public void GetLastOfferForConversationAsync()
        {
            this.mManageStrategyModel.GetLastOfferForConversationAsync();
        }

        /// <summary>
        /// Adds the negotiation strategy settings.
        /// </summary>
        /// <returns></returns>
        public NegotiationStrategySetting AddNegotiationStrategySettings()
        {
            NegotiationStrategySetting negSetings = this.mManageStrategyModel.AddNegotiationStrategySettings(StrategyAppConstant.StrategyType.Neutral, true);
            AdjustNegotiationToWholePeriod(negSetings);
            return negSetings;
        }

        /// <summary>
        /// Adds the conversation strategy settings.
        /// </summary>
        /// <returns></returns>
        public ConversationStrategySetting AddConversationStrategySettings()
        {
            ConversationStrategySetting convsetting = this.mManageStrategyModel.AddConversationStrategySettings(this.CurrentNegotiationSetting.NegotiationStrategySettingsID, true);

            #region → Adjust Conv. to Defualt Negotiation .

            if (CurrentNegotiationSetting != null /*&&
                CurrentNegotiationSetting.EntityState == EntityState.Unmodified*/)
            {
                convsetting.StartDate = CurrentNegotiationSetting.DefaultStartDate;
                convsetting.EndDate = CurrentNegotiationSetting.DefaultEndDate;
                convsetting.StrategyType = CurrentNegotiationSetting.StrategyType;
                convsetting.StrategyTypeID = CurrentNegotiationSetting.StrategyTypeID;
                convsetting.BetaValue = CurrentNegotiationSetting.BetaValue;
            }



            #endregion

            AdjustConversationToWholePeriod(convsetting);

            return convsetting;
        }

        /// <summary>
        /// Applies the changes.
        /// </summary>
        public void ApplyChanges()
        {
            RunQueueForApplyChanges = true;

            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (!this.IsBusy)
                {

                    RunQueueForApplyChanges = false;

                    this.RejectChanges();

                    this.CurrentPreferenceSet = null;
                    this.CurrentPreferenceSet = null;

                    this.CurrentNegotiationSetting = null;
                    this.CurrentConversationSetting = null;
                    this.CurrentPreferenceSet = null;
                    this.LastOffer = null;
                    this.ConversationPeriod = null;
                    this.NegotiationPeriod = null;


                    this.Status = Resources.StrategyStutasDefault;
                    this.Advice = Resources.StrategyAdviceDefault;

                    this.GetPreferenceSetForNegotiationAsync();
                }

            });

        }

        /// <summary>
        /// Cleanups this instance.
        /// </summary>
        public override void Cleanup()
        {
            base.Cleanup();

            Messenger.Default.Unregister(this);

            this.mManageStrategyModel.Cleanup();
        }

        #endregion

        #endregion

    }
}