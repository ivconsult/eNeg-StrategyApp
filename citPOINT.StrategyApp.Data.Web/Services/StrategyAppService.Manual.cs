#region → Usings   .
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.DomainServices.Server;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Configuration;
using citPOINT.StrategyApp.Data.Web.PrefAppService;
using citPOINT.StrategyApp.ViewModel;

#endregion

#region → History  .

/* Date         User              Change
 * 
 * 12.01.12     Yousra Reda       Creation
 */

# endregion

#region → ToDos    .

/*
 * Date         set by User     Description
 * 
 * 
*/

# endregion

namespace citPOINT.StrategyApp.Data.Web
{
    /// <summary>
    /// Provide additional Strategy App Services rather than CRUD operations
    /// </summary>
    public partial class StrategyAppService
    {
        #region → Fields         .

        PrefAppServiceSoapClient mLoader;

        #endregion

        #region → Properties     .

        /// <summary>
        /// Gets the loader.
        /// </summary>
        /// <value>The loader.</value>
        public PrefAppServiceSoapClient Loader
        {
            get
            {
                if (mLoader == null)
                {
                    mLoader = new PrefAppServiceSoapClient();
                    InjectCredentials();
                }
                return mLoader;
            }
        }

        #endregion Properties

        #region → Methods        .

        #region → Public         .

        #region → Special for Offer App .

        /// <summary>
        /// Gets the next expected target for negotiation.
        /// </summary>
        /// <param name="negotiationID">The negotiation ID.</param>
        /// <param name="maxPercentage">The max percentage of preference Set.</param>
        /// <param name="currentDate">The current date.</param>
        /// <returns></returns>
        public ExpectedTarget GetNextExpectedTargetForNegotiation(Guid negotiationID, decimal maxPercentage, DateTime currentDate)
        {

            if (ServiceAuthentication.IsValid())
            {
                try
                {
                    ISetting settings = this.GetNegotiationStrategySettingsByNegID(negotiationID);

                    return GetNextTarget(settings, currentDate, maxPercentage);
                }
                catch (Exception)
                {
                    return new ExpectedTarget()
                    {
                        ID = 1,
                        Status = Status.Failed,
                        Target = 0
                    };

                }
            }
            else
            {
                // throw fault exception to indicate the caller that the service need valid credentials                       
                throw new FaultException<InvalidOperationException>(new InvalidOperationException("Invalid credentials"), "Invalid credentials");
            }
        }

        /// <summary>
        /// Gets the next expected target for conversation.
        /// </summary>
        /// <param name="negotiationID">The negotiation ID. in case if the conversation has not settings</param>
        /// <param name="conversationID">The conversation ID.</param>
        /// <param name="maxPercentage">The max percentage of preference Set.</param>
        /// <param name="currentDate">The current date.</param>
        /// <returns></returns>
        public ExpectedTarget GetNextExpectedTargetForConversation(Guid negotiationID, Guid conversationID, decimal maxPercentage, DateTime currentDate)
        {
            if (ServiceAuthentication.IsValid())
            {
                try
                {
                    ISetting settings = this.GetConversationStrategySettingsByConvID(conversationID);

                    if (settings == null)
                    {
                        settings = this.GetNegotiationStrategySettingsByNegID(negotiationID);
                    }

                    return GetNextTarget(settings, currentDate, maxPercentage);
                }
                catch (Exception)
                {
                    return new ExpectedTarget()
                    {
                        ID = 1,
                        Status = Status.Failed,
                        Target = 0
                    };
                }
            }
            else
            {
                // throw fault exception to indicate the caller that the service need valid credentials                       
                throw new FaultException<InvalidOperationException>(new InvalidOperationException("Invalid credentials"), "Invalid credentials");
            }
        }

        #endregion
        
        /// <summary>
        /// Gets the negotiation strategy settings by neg ID.
        /// </summary>
        /// <param name="negotiationID">The negotiation ID.</param>
        /// <returns></returns>
        public NegotiationStrategySetting GetNegotiationStrategySettingsByNegID(Guid negotiationID)
        {
            if (ServiceAuthentication.IsValid())
            {
                return this.ObjectContext.NegotiationStrategySettings
                                        .Where(s => s.NegotiationID == negotiationID && s.Deleted == false)
                                        .FirstOrDefault();
            }
            else
            {
                // throw fault exception to indicate the caller that the service need valid credentials                       
                throw new FaultException<InvalidOperationException>(new InvalidOperationException("Invalid credentials"), "Invalid credentials");
            }
        }

        /// <summary>
        /// Gets the negotiation period.
        /// </summary>
        /// <param name="negotiationID">The negotiation ID.</param>
        /// <returns></returns>
        public ConversationPeriod GetNegotiationPeriod(Guid negotiationID)
        {
            if (ServiceAuthentication.IsValid())
            {
                var negortiationPeriodObject = Loader.GetNegotiationPeriod(negotiationID).RootResults.FirstOrDefault();
                if (negortiationPeriodObject != null &&
                    negortiationPeriodObject.MinConversationDate.HasValue &&
                    negortiationPeriodObject.MaxConversationDate.HasValue)
                {
                    ConversationPeriod ConvPeriod = new ConversationPeriod()
                    {
                        ID = negortiationPeriodObject.ID,
                        MaxConversationDate = negortiationPeriodObject.MaxConversationDate.Value,
                        MinConversationDate = negortiationPeriodObject.MinConversationDate.Value
                    };
                    return ConvPeriod;
                }
                else
                    return null;
            }
            else
            {
                // throw fault exception to indicate the caller that the service need valid credentials                      
                throw new FaultException<InvalidOperationException>(new InvalidOperationException("Invalid credentials"), "Invalid credentials");
            }
        }

        /// <summary>
        /// Gets the conversation strategy settings by conv ID.
        /// </summary>
        /// <param name="conversationID">The conversation ID.</param>
        /// <returns></returns>
        public ConversationStrategySetting GetConversationStrategySettingsByConvID(Guid conversationID)
        {
            if (ServiceAuthentication.IsValid())
            {
                return this.ObjectContext.ConversationStrategySettings
                                        .Where(s => s.ConversationID == conversationID && s.Deleted == false)
                                        .FirstOrDefault();
            }
            else
            {
                // throw fault exception to indicate the caller that the service need valid credentials                       
                throw new FaultException<InvalidOperationException>(new InvalidOperationException("Invalid credentials"), "Invalid credentials");
            }
        }

        /// <summary>
        /// Gets the conversation period.
        /// </summary>
        /// <param name="conversationID">The conversation ID.</param>
        /// <returns></returns>
        public ConversationPeriod GetConversationPeriod(Guid conversationID)
        {
            if (ServiceAuthentication.IsValid())
            {
                var ConversationPeriodObject = Loader.GetConversationPeriod(conversationID).RootResults.FirstOrDefault();
                if (ConversationPeriodObject != null &&
                    ConversationPeriodObject.MinConversationDate.HasValue &&
                    ConversationPeriodObject.MaxConversationDate.HasValue)
                {
                    ConversationPeriod ConvPeriod = new ConversationPeriod()
                    {
                        ID = ConversationPeriodObject.ID,
                        MaxConversationDate = ConversationPeriodObject.MaxConversationDate.Value,
                        MinConversationDate = ConversationPeriodObject.MinConversationDate.Value
                    };
                    return ConvPeriod;
                }
                else
                    return null;
            }
            else
            {
                // throw fault exception to indicate the caller that the service need valid credentials                      
                throw new FaultException<InvalidOperationException>(new InvalidOperationException("Invalid credentials"), "Invalid credentials");
            }
        }

        /// <summary>
        /// Gets the preference set for negotiation.
        /// </summary>
        /// <param name="negotiationID">The negotiation ID.</param>
        /// <returns>Preference Set that contain this negotiation</returns>
        public PreferenceSet GetPreferenceSetForNegotiation(Guid negotiationID)
        {
            if (ServiceAuthentication.IsValid())
            {

                var rootResults = Loader.GetPreferenceSetForNegotiation(negotiationID).RootResults;

                if (rootResults == null)
                {
                    return null;
                }

                var OriginalPreferenceSet = rootResults.FirstOrDefault();

                if (OriginalPreferenceSet != null)
                {
                    PreferenceSet PrefSet = new PreferenceSet()
                    {
                        PreferenceID = OriginalPreferenceSet.PreferenceSetID,
                        MaxPercentage = OriginalPreferenceSet.MaxPercentage
                    };
                    return PrefSet;
                }
                else
                    return null;
            }
            else
            {
                // throw fault exception to indicate the caller that the service need valid credentials                       
                throw new FaultException<InvalidOperationException>(new InvalidOperationException("Invalid credentials"), "Invalid credentials");
            }
        }

        /// <summary>
        /// Gets the last offer for conversation.
        /// </summary>
        /// <param name="conversationID">The conversation ID.</param>
        /// <param name="isSent">if set to <c>true</c> [is sent].</param>
        /// <returns></returns>
        public LastOfferDetails GetLastOfferForConversation(Guid conversationID, bool isSent)
        {
            if (ServiceAuthentication.IsValid())
            {
                var rootResults = Loader.GetLastOfferForConversation(conversationID, isSent).RootResults;

                if (rootResults == null)
                {
                    return null;
                }

                var LastRatedMSG = rootResults.FirstOrDefault();

                if (LastRatedMSG != null)
                {
                    LastOfferDetails LastOffer = new LastOfferDetails()
                    {
                        ID = LastRatedMSG.ID,
                        OfferDate = LastRatedMSG.OfferDate,
                        Percentage = LastRatedMSG.Percentage
                    };
                    return LastOffer;
                }
                else
                    return null;
            }
            else
            {
                // throw fault exception to indicate the caller that the service need valid credentials                      
                throw new FaultException<InvalidOperationException>(new InvalidOperationException("Invalid credentials"), "Invalid credentials");
            }
        }

        #endregion

        #region → Private        .

        /// <summary>
        /// Injects the credentials into message header.
        /// </summary>
        private void InjectCredentials()
        {
            OperationContextScope scope = new OperationContextScope((IContextChannel)Loader.InnerChannel);

            MessageHeaders messageHeadersElement = OperationContext.Current.OutgoingMessageHeaders;
            messageHeadersElement.Add(MessageHeader.CreateHeader("username", "http://tempori.org", ConfigurationManager.AppSettings["username"]));
            messageHeadersElement.Add(MessageHeader.CreateHeader("password", "http://tempori.org", ConfigurationManager.AppSettings["password"]));
        }

        /// <summary>
        /// Gets the next target.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="currentDate">The current date.</param>
        /// <param name="MaxPercentage">The max percentage.</param>
        /// <returns></returns>
        private ExpectedTarget GetNextTarget(ISetting setting, DateTime currentDate, decimal MaxPercentage)
        {
            ExpectedTarget expectedTarget = new ExpectedTarget()
            {
                ID = 1,
                Status = Status.Failed,
                Target = 0
            };

            try
            {

                if (setting != null)
                {
                    #region → Out Of Date            .

                    if (currentDate < setting.StartDate ||
                        currentDate > setting.EndDate)
                    {
                        expectedTarget.Status = Status.DateOutOfPeriod;
                    }

                    #endregion

                    #region → Normal Case Calculate  .

                    else
                    {
                        StrategyAgent agent = new StrategyAgent(setting.StartDate,
                                                                setting.EndDate,
                                                                0,
                                                                (double)MaxPercentage,
                                                                (double)setting.BetaValue);

                        agent.RunAgent(currentDate);

                        expectedTarget.Status = Status.Success;

                        expectedTarget.Target = (decimal)agent.StrageyScore;

                    }

                    #endregion
                }
                else
                {
                    expectedTarget.Status = Status.NoSettings;
                }

            }
            catch (Exception)
            {
                expectedTarget.Status = Status.Failed;
            }

            return expectedTarget;
        }
        #endregion

        #endregion
    }
}
