
#region → Usings   .
using System;
using System.Linq;
using citPOINT.StrategyApp.Common;
using citPOINT.StrategyApp.Data.Web;
using citPOINT.StrategyApp.MVVM.UnitTest.Helpers;
using citPOINT.StrategyApp.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

#region → History  .

/* Date         User            Change
 * 
 * 16.01.12    M.Wahab         • creation
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
    /// Manage Strategy View Model Test class
    /// </summary>
    [TestClass]
    public class ManageStrategyViewModel_Test
    {
        #region → Fields         .
        private ManageStrategyViewModel ManageStrategyvm;
        private string ErrorMessage;
        string currentScreen = null;
        #endregion

        #region → Properties     .

        /// <summary>
        /// View Model Object
        /// </summary>
        /// <value>The VM.</value>
        public ManageStrategyViewModel TheVM
        {
            get { return ManageStrategyvm; }
            set { ManageStrategyvm = value; }
        }
        #endregion

        #region → Constructors   .
        /// <summary>
        /// Initializes a new instance of the <see cref="ManageStrategyViewModel_Test"/> class.
        /// </summary>
        [TestInitialize]
        public void BuildUp()
        {
            StrategyAppConfigurations.CurrentLoginUser = new LoginUser();
            StrategyAppConfigurations.CurrentLoginUser.UserID = new Guid("C7CAD9E5-FA25-4EB9-82E6-E4D66D2D03BB");
            StrategyAppConfigurations.NegotiationIDParameter = SharedTestContext.CarNegotiation;
            StrategyAppConfigurations.ConversationIDParameter = SharedTestContext.CarConversation1;


            TheVM = new ManageStrategyViewModel(new MockManageStrategyModel());

            #region → Registeration for needed messages in eNegMessenger

            // register for RaiseErrorMessage
            StrategyAppMessanger.RaiseErrorMessage.Register(this, OnRaiseErrorMessage);

            StrategyAppMessanger.ChangeScreenMessage.Register(this, OnChangeScreenMessage);

            #endregion
        }
        #endregion

        #region → Methods        .

        #region → Private        .

        #region → Raise Error Message   .

        /// <summary>
        /// Raise error message if there is any layer send RaiseErrorMessage
        /// </summary>
        /// <param name="ex">exception to raise</param>
        private void OnRaiseErrorMessage(Exception ex)
        {
            if (ex != null)
            {
                if (ex.InnerException != null)
                {
                    ErrorMessage = ex.Message + "\r\n" + ex.InnerException.Message;
                }
                else
                    ErrorMessage = ex.Message;
            }
        }

        #endregion

        #region → Change Screen Message .

        /// <summary>
        /// Called when [change screen message].
        /// </summary>
        /// <param name="screenName">Name of the screen.</param>
        private void OnChangeScreenMessage(string screenName)
        {
            this.currentScreen = screenName;
        }

        #endregion

        #endregion

        #region → Public         .

        /// <summary>
        /// Tests the basics.
        /// </summary>
        [TestMethod]
        public void TestVM_Existance_HaveInstance()
        {
            Assert.IsNotNull(TheVM, "Failed to retrieve the View Model");
        }
        
        /// <summary>
        /// Gets the negotiation setting without condition so return collection.
        /// </summary>
        [TestMethod]
        public void GetNegotiationSetting_WithoutCondition_ReturnCollection()
        {
            #region → Arrange .


            #endregion

            #region → Act     .

            TheVM.GetNegotiationStrategySettingsAsync();

            #endregion

            #region → Assert  .

            Assert.IsTrue(string.IsNullOrEmpty(ErrorMessage), string.Concat("Error Message was recieved: ", ErrorMessage));
            Assert.IsTrue(TheVM.CurrentNegotiationSetting != null, "No Negotiation Strategy Setting Found");

            #endregion

        }

        /// <summary>
        /// Gets the strategy type without condition return collection.
        /// </summary>
        [TestMethod]
        public void GetStrategyType_WithoutCondition_ReturnCollection()
        {
            #region → Arrange .


            #endregion

            #region → Act     .

            TheVM.GetStrategyTypeAsync();

            #endregion

            #region → Assert  .

            Assert.IsTrue(string.IsNullOrEmpty(ErrorMessage), string.Concat("Error Message was recieved: ", ErrorMessage));
            Assert.IsTrue(TheVM.StrategyTypeSource != null && TheVM.StrategyTypeSource.Count() > 0, "No StrategyType Found");

            #endregion

        }

        /// <summary>
        /// Gets the last offer for conversation without condition return collection.
        /// </summary>
        [TestMethod]
        public void GetLastOfferForConversation_WithoutCondition_ReturnCollection()
        {
            #region → Arrange .

            #endregion

            #region → Act     .

            TheVM.GetLastOfferForConversationAsync();

            #endregion

            #region → Assert  .

            Assert.IsTrue(string.IsNullOrEmpty(ErrorMessage), string.Concat("Error Message was recieved: ", ErrorMessage));
            Assert.IsTrue(TheVM.LastOffer != null, "No Last Offer For Conversation Found");

            #endregion
        }

        /// <summary>
        /// Gets the conversation period without condition return collection.
        /// </summary>
        [TestMethod]
        public void GetConversationPeriod_WithoutCondition_ReturnCollection()
        {
            #region → Arrange .

            #endregion

            #region → Act     .

            TheVM.GetConversationPeriodAsync();

            #endregion

            #region → Assert  .

            Assert.IsTrue(string.IsNullOrEmpty(ErrorMessage), string.Concat("Error Message was recieved: ", ErrorMessage));
            Assert.IsTrue(TheVM.ConversationPeriod != null, "No Conversation Period Found");

            #endregion

        }

        /// <summary>
        /// Gets the conversation strategy settings_ without condition_ return collection.
        /// </summary>
        [TestMethod]
        public void GetConversationStrategySettings_WithoutCondition_ReturnCollection()
        {
            #region → Arrange .

            #endregion

            #region → Act     .

            TheVM.GetConversationStrategySettingsAsync();

            #endregion

            #region → Assert  .

            Assert.IsTrue(string.IsNullOrEmpty(ErrorMessage), string.Concat("Error Message was recieved: ", ErrorMessage));
            Assert.IsTrue(TheVM.CurrentConversationSetting != null, "No Conversation Strategy Settings Found");

            #endregion

        }
                
        #endregion

        #endregion
    }
}
