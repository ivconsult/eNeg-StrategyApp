
#region → Usings   .
using System.Windows.Controls;
#endregion

#region → History  .

/* Date         User              Change
 * 
 * 16.01.12     Yousra Reda       Creation
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
    /// View used as notification message for the user when the prefApp 
    /// is not active or the negotiation is not added to a PrefSet
    /// </summary>
    public partial class AlarmView : UserControl
    {
        #region → Constructor    .
        /// <summary>
        /// Initializes a new instance of the <see cref="AlarmView"/> class.
        /// </summary>
        public AlarmView()
        {
            InitializeComponent();
        }
        #endregion
    }
}
