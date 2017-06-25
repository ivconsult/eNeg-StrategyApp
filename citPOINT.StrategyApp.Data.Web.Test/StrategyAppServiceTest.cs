#region → Usings   .
using System;
using System.Collections.Generic;
using System.ServiceModel.DomainServices.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using citPOINT.StrategyApp.Common;
using citPOINT.StrategyApp.Data.Web;
using citPOINT.eNeg.Data.Web.Test;

#endregion

#region → History  .

/* Date         User            Change
 * 
 * 14.08.11     Yousra Reda     creation
 */

# endregion

#region → ToDos    .

/*
 * Date         set by User     Description
 * 
*/

# endregion
namespace citPOINT.StrategyApp.Data.Web.Test
{
    /// <summary>
    /// Class for testing [Insert - Update - Delete] 
    /// operations for StrategyApp Database
    /// </summary>
    [TestClass]
    public class StrategyAppServiceTest
    {

        #region → Fields         .
        StrategyAppContext mContext;

        private List<NegotiationStrategySetting> mNegotiationStrategySettingSource;
        private List<ConversationStrategySetting> mConversationStrategySettingSource;
        private List<StrategyType> mStrategyTypeSource;

        int CountOfAllEntries = 0;
        private TestContext testContextInstance;
        #endregion

        #region → Properties     .

        /// <summary>
        /// Gets the car negotiation.
        /// </summary>
        /// <value>The car negotiation.</value>
        public Guid CarNegotiation
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        /// <summary>
        /// Gets the laptop negotiation.
        /// </summary>
        /// <value>The laptop negotiation.</value>
        public Guid LaptopNegotiation
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        /// <summary>
        /// Gets the car conversation1.
        /// </summary>
        /// <value>The car conversation1.</value>
        public Guid CarConversation1
        {
            get
            {
                return Guid.NewGuid();
            }
        }
        
        /// <summary>
        /// Gets the car conversation2.
        /// </summary>
        /// <value>The car conversation2.</value>
        public Guid CarConversation2
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        #region Mock Objects

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
                            BetaValue=this.StrategyTypeSource[2].Beta,
                            StrategyTypeID=this.StrategyTypeSource[2].StrategyTypeID,
                            NegotiationID=this.CarNegotiation,
                            NegotiationStrategySettingsID=Guid.NewGuid(),
                            DefaultStartDate=DateTime.Now,
                            DefaultEndDate=DateTime.Now.AddDays(7),
                                                        Deleted=false,
                            DeletedBy=StrategyAppConfigurations.CurrentLoginUser.UserID,
                            DeletedOn=DateTime.Now
                        },

                        new  NegotiationStrategySetting
                        {
                              BetaValue=this.StrategyTypeSource[3].Beta,
                            StrategyTypeID=this.StrategyTypeSource[3].StrategyTypeID,
                            NegotiationID=this.LaptopNegotiation,
                            NegotiationStrategySettingsID=Guid.NewGuid(),
                            DefaultStartDate=DateTime.Now,
                            DefaultEndDate=DateTime.Now.AddDays(7),
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
                            StrategyTypeID=this.StrategyTypeSource[3].StrategyTypeID,
                            ConversationID=this.CarConversation1,
                            ConversationStrategySettingsID=Guid.NewGuid(),
                            NegotiationStrategySetting=this.NegotiationStrategySettingSource[0],
                            StartDate =new DateTime(2011,1,1),
                            EndDate=new DateTime(2011,03,30),
                            Deleted=false,
                            DeletedBy=StrategyAppConfigurations.CurrentLoginUser.UserID,
                            DeletedOn=DateTime.Now
                        },
                        new  ConversationStrategySetting
                        {
                            BetaValue=this.StrategyTypeSource[4].Beta,
                            StrategyTypeID=this.StrategyTypeSource[4].StrategyTypeID,
                            ConversationID=this.CarConversation2,
                            NegotiationStrategySetting=this.NegotiationStrategySettingSource[0],
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
                    mContext = new StrategyAppContext(new Uri("http://localhost:9006/citPOINT-StrategyApp-Data-Web-StrategyAppService.svc", UriKind.Absolute));
                }
                return mContext;
            }
        }
        
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #endregion Properties

        #region → Constructor    .

        /// <summary>
        /// Initializes a new instance of the <see cref="StrategyAppServiceTest"/> class.
        /// </summary>
        public StrategyAppServiceTest()
        {
            StrategyAppConfigurations.CurrentLoginUser = new LoginUser();
            StrategyAppConfigurations.CurrentLoginUser.UserID = new Guid("C7CAD9E5-FA25-4EB9-82E6-E4D66D2D03BB");
            StrategyAppConfigurations.NegotiationIDParameter = this.CarNegotiation;
            StrategyAppConfigurations.ConversationIDParameter = this.CarConversation1;

            CountOfAllEntries = this.NegotiationStrategySettingSource.Count +
                                this.ConversationStrategySettingSource.Count;
        }

        #endregion

        #region → Methods        .

        #region Test Insert All Entries
        /// <summary>
        ///A test for Insert All Entries
        ///</summary>
        [TestMethod]
        [Description(@"Test Insert Operations for all entries")]
        public void InsertAllEntries()
        {
            try
            {
                foreach (var item in this.NegotiationStrategySettingSource)
                {
                    this.Context.NegotiationStrategySettings.Add(item);
                }

                foreach (var item in this.ConversationStrategySettingSource)
                {
                    this.Context.ConversationStrategySettings.Add(item);
                }

                this.Context.SubmitChanges(new Action<SubmitOperation>(InsertAllEntriesComplete), null);
            }
            catch (Exception ex)
            {
                eNegMessageBox.ShowMessageBox(false, "InsertAllEntries", ex);
            }
        }

        /// <summary>
        /// Inserts all entries complete.
        /// </summary>
        /// <param name="subOp">The sub op.</param>
        private void InsertAllEntriesComplete(SubmitOperation subOp)
        {
            if (!subOp.HasError)
            {
                if (subOp.ChangeSet.AddedEntities.Count != this.CountOfAllEntries)
                {
                    eNegMessageBox.ShowMessageBox(false, "InsertAllEntriesComplete", "Number of Records Inserted is not right.");
                }
                else
                {
                    UpdateAllEntries();
                }
            }
            else
            {
                eNegMessageBox.ShowMessageBox(false, "InsertAllEntriesComplete", subOp.Error);
            }
        }

        #endregion

        #region Test Update All Entries

        /// <summary>
        ///A test for Update All Entries
        ///</summary>
        public void UpdateAllEntries()
        {
            try
            {
                this.Context.RejectChanges();

                foreach (var item in this.NegotiationStrategySettingSource)
                {
                    item.BetaValue += 10;
                }

                foreach (var item in this.ConversationStrategySettingSource)
                {
                    item.BetaValue += 10;
                }

                this.Context.SubmitChanges(new Action<SubmitOperation>(UpdateAllEntriesComplete), null);
            }
            catch (Exception ex)
            {
                eNegMessageBox.ShowMessageBox(false, "UpdateAllEntries", ex);
            }
        }
        
        /// <summary>
        /// Event Complete of  Update All Entries
        /// </summary>
        /// <param name="subOp">Value of subOp</param>
        private void UpdateAllEntriesComplete(SubmitOperation subOp)
        {
            if (!subOp.HasError)
            {
                if (subOp.ChangeSet.AddedEntities.Count == 0 &&
                    subOp.ChangeSet.RemovedEntities.Count == 0 &&
                    subOp.ChangeSet.ModifiedEntities.Count != this.CountOfAllEntries)
                {
                    eNegMessageBox.ShowMessageBox(false, "UpdateAllEntriesComplete", "Number of Records updated is not right.");
                }
                else
                {
                    DeleteAllEntries();
                }
            }
            else
            {
                eNegMessageBox.ShowMessageBox(false, "UpdateAllEntriesComplete", subOp.Error);
            }
        }

        #endregion

        #region Test Delete All Entries

        /// <summary>
        ///A test for Delete All Entries
        ///only for Delete Flag
        ///</summary>
        public void DeleteAllEntries()
        {
            try
            {
                this.Context.RejectChanges();

                while (this.ConversationStrategySettingSource.Count > 0)
                {
                    this.Context.ConversationStrategySettings.Remove(this.ConversationStrategySettingSource[0]);
                    this.ConversationStrategySettingSource.RemoveAt(0);
                }


                while (this.NegotiationStrategySettingSource.Count > 0)
                {
                    this.Context.NegotiationStrategySettings.Remove(this.NegotiationStrategySettingSource[0]);
                    this.NegotiationStrategySettingSource.RemoveAt(0);
                }

                this.Context.SubmitChanges(new Action<SubmitOperation>(DeleteAllEntriesComplete), null);
            }
            catch (Exception ex)
            {
                eNegMessageBox.ShowMessageBox(false, "DeleteAllEntries", ex);
            }
        }

        /// <summary>
        /// Event Complete of  Delete All Entries
        /// </summary>
        /// <param name="subOp">Value of subOp</param>
        private void DeleteAllEntriesComplete(SubmitOperation subOp)
        {
            if (!subOp.HasError)
            {

                if (subOp.ChangeSet.AddedEntities.Count == 0 &&
                    subOp.ChangeSet.ModifiedEntities.Count == 0 &&
                    subOp.ChangeSet.RemovedEntities.Count != this.CountOfAllEntries)
                {
                    eNegMessageBox.ShowMessageBox(false, "DeleteAllEntriesComplete", "Number of Records Inserted is not right.");
                }
                else
                {
                    eNegMessageBox.ShowMessageBox(true, "Inset - Update - Delete All Entries ", DeleteString);
                }
            }
            else
            {
                eNegMessageBox.ShowMessageBox(false, "DeleteAllEntriesComplete", subOp.Error);
            }
        }

        #endregion

        /// <summary>
        /// get SQL Statement to Clear Database
        /// </summary>
        private string DeleteString
        {
            get
            {
                return @"
---------------------------------------------------
You must run these SQL commands Before retest again
---------------------------------------------------

DELETE [ConversationStrategySetting];
DELETE [NegotiationStrategySetting];
";
            }
        }

        #endregion Methods
    }
}
