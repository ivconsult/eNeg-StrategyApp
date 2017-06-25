
#region → Usings   .
using System;

#endregion

#region → History  .

/* Date         User            Change
 * 
 * 16.01.12     M.Wahab         • Creation
 */

# endregion

#region → ToDos    .

/*
 * Date         set by User     Description
 * 
*/

# endregion

namespace citPOINT.StrategyApp.Common
{
    /// <summary>
    /// Constant for All Tables (Lockup Tables)
    /// </summary>
    public static class StrategyAppConstant
    {
        #region → Strategy Type  .

        /// <summary>
        /// Strategy Type.
        /// </summary>
        public class StrategyType
        {
            #region → Fields         .

            private static int mNeutral = 1;
            private static int mOther = 6;

            #endregion

            #region → Properties     .

            /// <summary>
            /// Gets the neutral.
            /// </summary>
            /// <value>The neutral.</value>
            public static int Neutral
            {
                get
                {
                    return StrategyType.mNeutral;
                }
            }

            /// <summary>
            /// Gets the other.
            /// </summary>
            /// <value>The other.</value>
            public static int Other
            {
                get
                {
                    return StrategyType.mOther;
                }
            }

            #endregion

        }

        #endregion

    }




}
