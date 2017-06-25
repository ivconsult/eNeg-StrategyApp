
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
    /// Class represent the Preference Set used for certain negoitation.
    /// </summary>
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public sealed class PreferenceSet : EntityObject
    {
        #region → Properties     .

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>The ID.</value>
        [Key]
        [DataMemberAttribute()]
        public Guid PreferenceID { get; set; }

        /// <summary>
        /// Gets or sets the max conversation date.
        /// </summary>
        /// <value>The max conversation date.</value>
        [DataMemberAttribute()]
        public decimal MaxPercentage { get; set; }

        #endregion
    }
}
