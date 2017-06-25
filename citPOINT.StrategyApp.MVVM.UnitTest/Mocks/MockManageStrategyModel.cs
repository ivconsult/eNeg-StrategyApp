
#region → Usings   .
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using citPOINT.StrategyApp.Common;
using System.ServiceModel.DomainServices.Client;
using System.ComponentModel;
using citPOINT.eNeg.Common;
using citPOINT.StrategyApp.Data.Web;
using citPOINT.StrategyApp.MVVM.UnitTest.Helpers;
#endregion

#region → History  .

/* Date         User            Change
 * 
 * 16.01.12     M.Wahab         • creation
 */

# endregion

#region → ToDos    .

/*
 * Date         set by User     Description
 * 
 * 
*/

# endregion

namespace citPOINT.StrategyApp.MVVM.UnitTest
{
    /// <summary>
    /// Mock Message Template Model
    /// </summary>
    public class MockManageStrategyModel : IManageStrategyModel
    {
        #region → Fields         .

        private StrategyAppContext mContext;
        private List<NegotiationStrategySetting> mNegotiationStrategySettingSource;
        private List<ConversationStrategySetting> mConversationStrategySettingSource;
        private List<StrategyType> mStrategyTypeSource;
        private List<ConversationPeriod> mConversationPeriodSource;
        private List<LastOfferDetails> mLastOfferDetailsSource;
        private List<PreferenceSet> mPreferenceSetSource;
        #endregion

        #region → Properties     .

        /// <summary>
        /// Gets a value indicating whether this instance has changes.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has changes; otherwise, <c>false</c>.
        /// </value>
        public bool HasChanges
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is busy.
        /// </summary>
        /// <value><c>true</c> if this instance is busy; otherwise, <c>false</c>.</value>
        public bool IsBusy
        {
            get { return false; }
        }

        /// <summary>
        /// property with a getter only to can use eNegService
        /// </summary>
        public StrategyAppContext Context
        {
            get
            {
                if (mContext == null)
                {
                    mContext = new StrategyAppContext(new Uri("http://localhost:9006/citPOINT-StrategyApp-Data-Web-StrategyAppService.svc", UriKind.Absolute));
                }
                return mContext;
            }
        }


        #region → Negotiation Strategy Setting  .

        /// <summary>
        /// Gets the phase sources.
        /// </summary>
        /// <value>The phase sources.</value>
        public List<NegotiationStrategySetting> NegotiationStrategySettingSource
        {
            get
            {
                if (mNegotiationStrategySettingSource == null)
                {
                    mNegotiationStrategySettingSource = new List<NegotiationStrategySetting>()
                    {
                        new  NegotiationStrategySetting
                        {
                            BetaValue=0,
                            NegotiationID=SharedTestContext.CarNegotiation,
                            NegotiationStrategySettingsID=Guid.NewGuid(),
                            DefaultStartDate=DateTime.Now,
                            DefaultEndDate=DateTime.Now.AddDays(7),
                            StrategyTypeID=1,
                            Deleted=false,
                            DeletedBy=StrategyAppConfigurations.CurrentLoginUser.UserID,
                            DeletedOn=DateTime.Now
                        },


                        new  NegotiationStrategySetting
                        {
                            BetaValue=0,
                            NegotiationID=SharedTestContext.LaptopNegotiation,
                            NegotiationStrategySettingsID=Guid.NewGuid(),
                            DefaultStartDate=DateTime.Now,
                            DefaultEndDate=DateTime.Now.AddDays(7),
                            StrategyTypeID=4,
                            Deleted=false,
                            DeletedBy=StrategyAppConfigurations.CurrentLoginUser.UserID,
                            DeletedOn=DateTime.Now
                        },

                    };
                }
                return mNegotiationStrategySettingSource;
            }
        }

        #endregion

        #region → Conversation Strategy Setting .

        /// <summary>
        /// Gets the conversation strategy setting source.
        /// </summary>
        /// <value>The conversation strategy setting source.</value>
        public List<ConversationStrategySetting> ConversationStrategySettingSource
        {
            get
            {
                if (mConversationStrategySettingSource == null)
                {
                    mConversationStrategySettingSource = new List<ConversationStrategySetting>()
                    {
                        new  ConversationStrategySetting
                        {
                            BetaValue=this.StrategyTypeSource[3].Beta,
                            StrategyType=this.StrategyTypeSource[3],
                            StrategyTypeID=this.StrategyTypeSource[3].StrategyTypeID,
                            ConversationID=SharedTestContext.CarConversation1,
                            ConversationStrategySettingsID=Guid.NewGuid(),
                            StartDate =new DateTime(2011,1,1),
                            EndDate=new DateTime(2011,03,30),
                            Deleted=false,
                            DeletedBy=StrategyAppConfigurations.CurrentLoginUser.UserID,
                            DeletedOn=DateTime.Now
                        },
                        new  ConversationStrategySetting
                        {
                            BetaValue=this.StrategyTypeSource[4].Beta,
                            StrategyType=this.StrategyTypeSource[4],
                            StrategyTypeID=this.StrategyTypeSource[4].StrategyTypeID,
                            ConversationID=SharedTestContext.CarConversation2,
                            ConversationStrategySettingsID=Guid.NewGuid(),
                            StartDate =new DateTime(2011,1,1),
                            EndDate=new DateTime(2011,03,30),
                            
                            Deleted=false,
                            DeletedBy=StrategyAppConfigurations.CurrentLoginUser.UserID,
                            DeletedOn=DateTime.Now
                        } 

                    };
                }
                return mConversationStrategySettingSource;
            }
        }

        #endregion

        #region → Conversation Period           .

        /// <summary>
        /// Gets the phase sources.
        /// </summary>
        /// <value>The phase sources.</value>
        public List<ConversationPeriod> ConversationPeriodSource
        {
            get
            {
                if (mConversationPeriodSource == null)
                {
                    mConversationPeriodSource = new List<ConversationPeriod>()
                    {
                      new ConversationPeriod()
                    {
                        ID = 1,
                        MinConversationDate = new DateTime(2011, 1, 1),
                        MaxConversationDate = new DateTime(2011, 01, 25)
                    } 
                    };
                }
                return mConversationPeriodSource;
            }
        }

        #endregion

        #region → Last Offer Details            .

        /// <summary>
        /// Gets the last offer details source.
        /// </summary>
        /// <value>The last offer details source.</value>
        public List<LastOfferDetails> LastOfferDetailsSource
        {
            get
            {
                if (mLastOfferDetailsSource == null)
                {
                    mLastOfferDetailsSource = new List<LastOfferDetails>()
                    {
                        new LastOfferDetails()
                        {
                             OfferDate=new DateTime(2011, 01, 15),
                              Percentage=55.75m
                        } 
                    };
                }
                return mLastOfferDetailsSource;
            }
        }

        #endregion

        #region → Preference Set                .

        /// <summary>
        /// Gets the preference set source.
        /// </summary>
        /// <value>The preference set source.</value>
        public List<PreferenceSet> PreferenceSetSource
        {
            get
            {
                if (mPreferenceSetSource == null)
                {
                    mPreferenceSetSource = new List<PreferenceSet>()
                    {
                        new PreferenceSet()
                        {
                          MaxPercentage=90,
                         PreferenceID=Guid.NewGuid()
                      } 
                    };
                }
                return mPreferenceSetSource;
            }
        }

        #endregion

        #region → Strategy Type                 .

        /// <summary>
        /// Gets the StrategyType source.
        /// </summary>
        /// <value>The StrategyType source.</value>
        public List<StrategyType> StrategyTypeSource
        {
            get
            {
                if (mStrategyTypeSource == null)
                {
                    mStrategyTypeSource = new List<StrategyType>();
                    mStrategyTypeSource.Add(new StrategyType()
                    {
                        StrategyTypeID = 1,
                        StrategyTypeName = @"Neutral",
                        Beta = 1.00M,
                    });
                    mStrategyTypeSource.Add(new StrategyType()
                    {
                        StrategyTypeID = 2,
                        StrategyTypeName = @"Conceder Light",
                        Beta = 2.00M,
                    });
                    mStrategyTypeSource.Add(new StrategyType()
                    {
                        StrategyTypeID = 3,
                        StrategyTypeName = @"Conceder Strong",
                        Beta = 5.00M,
                    });
                    mStrategyTypeSource.Add(new StrategyType()
                    {
                        StrategyTypeID = 4,
                        StrategyTypeName = @"Boulware Light",
                        Beta = 0.80M,
                    });
                    mStrategyTypeSource.Add(new StrategyType()
                    {
                        StrategyTypeID = 5,
                        StrategyTypeName = @"Boulware Strong",
                        Beta = 0.50M,
                    });
                    mStrategyTypeSource.Add(new StrategyType()
                    {
                        StrategyTypeID = 6,
                        StrategyTypeName = @"Other",
                        Beta = null,
                    });
                } return mStrategyTypeSource;
            }
        }

        #endregion

        #endregion

        #region → Constructors   .

        /// <summary>
        /// Initializes a new instance of the <see cref="MockManageStrategyModel"/> class.
        /// </summary>
        public MockManageStrategyModel()
        {
        }

        #endregion

        #region → Event Handlers .

        /// <summary>
        /// Private Event Handler that called after any change in 
        /// HasChanges, IsLoading, IsSubmitting properties
        /// </summary>
        /// <param name="sender">Value of Sender</param>
        /// <param name="e">Value of e</param>
        private void ctx_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        #endregion

        #region → Events         .

        /// <summary>
        /// Event Handler For Method PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// SaveChangesComplete
        /// </summary>
        public event EventHandler<SubmitOperationEventArgs> SaveChangesComplete;

        /// <summary>
        /// Occurs when [get conversation period complete].
        /// </summary>
        public event EventHandler<eNegEntityResultArgs<ConversationPeriod>> GetConversationPeriodComplete;

        /// <summary>
        /// Occurs when [get negotiation period complete].
        /// </summary>
        public event EventHandler<eNegEntityResultArgs<ConversationPeriod>> GetNegotiationPeriodComplete;

        /// <summary>
        /// Occurs when [get conversation strategy settings complete].
        /// </summary>
        public event EventHandler<eNegEntityResultArgs<ConversationStrategySetting>> GetConversationStrategySettingsComplete;

        /// <summary>
        /// Occurs when [get last offer for conversation complete].
        /// </summary>
        public event EventHandler<eNegEntityResultArgs<LastOfferDetails>> GetLastOfferForConversationComplete;

        /// <summary>
        /// Occurs when [get negotiation strategy settings complete].
        /// </summary>
        public event EventHandler<eNegEntityResultArgs<NegotiationStrategySetting>> GetNegotiationStrategySettingsComplete;

        /// <summary>
        /// Occurs when [get preference set for negotiation complete].
        /// </summary>
        public event EventHandler<eNegEntityResultArgs<PreferenceSet>> GetPreferenceSetForNegotiationComplete;

        /// <summary>
        /// Occurs when [get strategy type complete].
        /// </summary>
        public event EventHandler<eNegEntityResultArgs<StrategyType>> GetStrategyTypeComplete;


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
        /// Gets the conversation period async.
        /// </summary>
        public void GetConversationPeriodAsync()
        {
            if (GetConversationPeriodComplete != null)
            {
                GetConversationPeriodComplete(this, new eNegEntityResultArgs<ConversationPeriod>(ConversationPeriodSource));
            }
        }

        /// <summary>
        /// Gets the negotiation period async.
        /// </summary>
        public void GetNegotiationPeriodAsync()
        {
            if (GetNegotiationPeriodComplete != null)
            {
                GetNegotiationPeriodComplete(this, new eNegEntityResultArgs<ConversationPeriod>(ConversationPeriodSource));
            }
        }

        /// <summary>
        /// Gets the last offer for conversation async.
        /// </summary>
        public void GetLastOfferForConversationAsync()
        {
            if (GetLastOfferForConversationComplete != null)
            {
                GetLastOfferForConversationComplete(this, new eNegEntityResultArgs<LastOfferDetails>(LastOfferDetailsSource));
            }
        }

        /// <summary>
        /// Gets the negotiation strategy settings async.
        /// </summary>
        public void GetNegotiationStrategySettingsAsync()
        {
            if (GetNegotiationStrategySettingsComplete != null)
            {
                GetNegotiationStrategySettingsComplete(this, new eNegEntityResultArgs<NegotiationStrategySetting>(this.NegotiationStrategySettingSource));
            }
        }

        /// <summary>
        /// Gets the conversation strategy settings async.
        /// </summary>
        public void GetConversationStrategySettingsAsync()
        {
            if (GetConversationStrategySettingsComplete != null)
            {
                GetConversationStrategySettingsComplete(this, new eNegEntityResultArgs<ConversationStrategySetting>(this.ConversationStrategySettingSource));
            }

        }

        /// <summary>
        /// Gets the preference set for negotiation async.
        /// </summary>
        public void GetPreferenceSetForNegotiationAsync()
        {
            if (GetPreferenceSetForNegotiationComplete != null)
            {
                GetPreferenceSetForNegotiationComplete(this, new eNegEntityResultArgs<PreferenceSet>(this.PreferenceSetSource));
            }
        }

        /// <summary>
        /// Gets the strategy type async.
        /// </summary>
        public void GetStrategyTypeAsync()
        {
            if (GetStrategyTypeComplete != null)
            {
                GetStrategyTypeComplete(this, new eNegEntityResultArgs<StrategyType>(this.StrategyTypeSource));
            }
        }

        /// <summary>
        /// Save changes asynchronously
        /// </summary>
        public void SaveChangesAsync()
        {
            if (SaveChangesComplete != null)
            {
                SaveChangesComplete(this, new SubmitOperationEventArgs(null, null));
            }
        }

        /// <summary>
        /// Reject all changes happen on current Context
        /// </summary>
        public void RejectChanges()
        {

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
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                Deleted = false,
                DeletedBy = StrategyAppConfigurations.CurrentLoginUser.UserID,
                DeletedOn = DateTime.Now
            };


            return ConvStrategySetting;
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
                DefaultStartDate = DateTime.Now,
                DefaultEndDate = DateTime.Now.AddDays(7),
                Deleted = false,
                DeletedBy = StrategyAppConfigurations.CurrentLoginUser.UserID,
                DeletedOn = DateTime.Now
            };

            return NegStrategySetting;
        }

        /// <summary>
        /// Cleanups this instance.
        /// </summary>
        public void Cleanup()
        {

        }
        #endregion  Public

        #endregion Methods







       
    }
}
