
#region → Usings   .
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Web;
using System.Data.Objects.DataClasses;
using System.ComponentModel;

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
    /// Class represent Conversation Period of ceratin conversation to represent the start and end date
    /// </summary>
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public sealed class ConversationPeriod : EntityObject
    {
        #region → Properties     .

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>The ID.</value>
        [Key]
        [DataMemberAttribute()]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the min conversation date.
        /// </summary>
        /// <value>The min conversation date.</value>
        [DataMemberAttribute()]
        public DateTime MinConversationDate { get; set; }

        /// <summary>
        /// Gets or sets the max conversation date.
        /// </summary>
        /// <value>The max conversation date.</value>
        [DataMemberAttribute()]
        public DateTime MaxConversationDate { get; set; }

        #endregion
    }
}
