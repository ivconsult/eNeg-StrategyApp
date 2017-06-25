
#region → Usings   .
using System;

#endregion

#region → History  .

/* 
 * Date           User            Change
 * *********************************************
 * 1/17/2012 PM  mwahab          • creation
 * **********************************************
 */

# endregion

#region → ToDos    .

/*
 * Date         set by User     Description
 * 
 * 
*/

# endregion

namespace citPOINT.StrategyApp.MVVM.UnitTest.Helpers
{
    /// <summary>
    /// Shared Test Context
    /// </summary>
    public static class SharedTestContext
    {

        #region → Properties     .

        /// <summary>
        /// Gets the car negotiation.
        /// </summary>
        /// <value>The car negotiation.</value>
        public static Guid CarNegotiation
        {
            get
            {
                return Guid.Parse("747D37FC-6969-4649-9B7B-DE1A0ADB08BD");
            }
        }

        /// <summary>
        /// Gets the laptop negotiation.
        /// </summary>
        /// <value>The laptop negotiation.</value>
        public static Guid LaptopNegotiation
        {
            get
            {
                return Guid.Parse("747D37FC-6969-4649-6969-DE1A0ADB08BD");
            }
        }
        /// <summary>
        /// Gets the car conversation1.
        /// </summary>
        /// <value>The car conversation1.</value>
        public static Guid CarConversation1
        {
            get
            {
                return Guid.Parse("8CD50216-2C7F-4519-A5BB-6DBBA24E7988");
            }
        }
        
        /// <summary>
        /// Gets the car conversation2.
        /// </summary>
        /// <value>The car conversation2.</value>
        public static Guid CarConversation2
        {
            get
            {
                return Guid.Parse("8CD50216-2C7F-4519-2C7F-6DBBA24E7988");
            }
        }

        #endregion

    }
}
