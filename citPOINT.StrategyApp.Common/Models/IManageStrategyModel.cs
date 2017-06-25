
#region → Usings   .
using System;
using citPOINT.StrategyApp.Data.Web;
using System.ComponentModel;
using citPOINT.eNeg.Common;
using GalaSoft.MvvmLight;
#endregion

#region → History  .

/* Date         User            Change
 * 
 * 12.01.12     Yousra       •creation
 */

# endregion

#region → ToDos    .

/*
 * Date         set by User     Description
 * 
 * 
*/

# endregion

namespace citPOINT.StrategyApp.Common
{
    /// <summary>
    /// interface for the Manage Strategy Model
    /// </summary>
    public interface IManageStrategyModel:ICleanup
    {
        #region → Properties     .

        /// <summary>
        /// Gets a value indicating whether this instance has changes.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has changes; otherwise, <c>false</c>.
        /// </value>
        bool HasChanges { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is busy.
        /// </summary>
        /// <value><c>true</c> if this instance is busy; otherwise, <c>false</c>.</value>
        bool IsBusy { get; }
        #endregion

        #region → Events         .

        /// <summary>
        /// Occurs when [get conversation period complete].
        /// </summary>
        event EventHandler<eNegEntityResultArgs<ConversationPeriod>> GetConversationPeriodComplete;

        /// <summary>
        /// Occurs when [get conversation strategy settings complete].
        /// </summary>
        event EventHandler<eNegEntityResultArgs<ConversationStrategySetting>> GetConversationStrategySettingsComplete;

        /// <summary>
        /// Occurs when [get negotiation period complete].
        /// </summary>
        event EventHandler<eNegEntityResultArgs<ConversationPeriod>> GetNegotiationPeriodComplete;

        /// <summary>
        /// Occurs when [get last offer for conversation complete].
        /// </summary>
        event EventHandler<eNegEntityResultArgs<LastOfferDetails>> GetLastOfferForConversationComplete;

        /// <summary>
        /// Occurs when [get negotiation strategy settings complete].
        /// </summary>
        event EventHandler<eNegEntityResultArgs<NegotiationStrategySetting>> GetNegotiationStrategySettingsComplete;

        /// <summary>
        /// Occurs when [get preference set for negotiation complete].
        /// </summary>
        event EventHandler<eNegEntityResultArgs<PreferenceSet>> GetPreferenceSetForNegotiationComplete;

        /// <summary>
        /// Occurs when [get strategy type complete].
        /// </summary>
        event EventHandler<eNegEntityResultArgs<StrategyType>> GetStrategyTypeComplete;

        /// <summary>
        /// Occurs when [save changes complete].
        /// </summary>
        event EventHandler<SubmitOperationEventArgs> SaveChangesComplete;

        /// <summary>
        /// Occurs when [property changed].
        /// </summary>
        event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region → Methods        .

        /// <summary>
        /// Adds the conversation strategy settings.
        /// </summary>
        /// <param name="parentNegStrategySettingID">The parent neg strategy setting ID.</param>
        /// <param name="setInContext">if set to <c>true</c> [set in context].</param>
        /// <returns></returns>
        ConversationStrategySetting AddConversationStrategySettings(Guid parentNegStrategySettingID, bool setInContext);

        /// <summary>
        /// Adds the negotiation strategy settings.
        /// </summary>
        /// <param name="defaultStrategyTypeID">The default strategy type ID.</param>
        /// <param name="setInContext">if set to <c>true</c> [set in context].</param>
        /// <returns></returns>
        NegotiationStrategySetting AddNegotiationStrategySettings(int defaultStrategyTypeID, bool setInContext);

        /// <summary>
        /// Gets the conversation period async.
        /// </summary>
        void GetConversationPeriodAsync();

        /// <summary>
        /// Gets the negotiation period async.
        /// </summary>
        void GetNegotiationPeriodAsync();

        /// <summary>
        /// Gets the conversation strategy settings async.
        /// </summary>
        void GetConversationStrategySettingsAsync();

        /// <summary>
        /// Gets the last offer for conversation async.
        /// </summary>
        void GetLastOfferForConversationAsync();

        /// <summary>
        /// Gets the negotiation strategy settings async.
        /// </summary>
        void GetNegotiationStrategySettingsAsync();

        /// <summary>
        /// Gets the preference set for negotiation async.
        /// </summary>
        void GetPreferenceSetForNegotiationAsync();

        /// <summary>
        /// Gets the strategy type async.
        /// </summary>
        void GetStrategyTypeAsync();

        /// <summary>
        /// Rejects the changes.
        /// </summary>
        void RejectChanges();

        /// <summary>
        /// Saves the changes async.
        /// </summary>
        void SaveChangesAsync();
        #endregion
                
    }
}
