// -----------------------------------------------------------------------
// <copyright file="Class1.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace citPOINT.StrategyApp.Data.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Interface for Common Settings
    /// </summary>
    public interface ISetting
    {
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        DateTime StartDate { get; set; }
        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the beta value.
        /// </summary>
        /// <value>The beta value.</value>
        Nullable<decimal> BetaValue { get; set; }
    }

    /// <summary>
    /// Conversation Strategy Setting
    /// </summary>
    public partial class ConversationStrategySetting : ISetting
    {

    }


    /// <summary>
    /// Negotiation Strategy Setting
    /// </summary>
    public partial class NegotiationStrategySetting : ISetting
    {

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        public DateTime StartDate
        {
            get
            {
                return this.DefaultStartDate;
            }
            set
            {
                this.DefaultStartDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        public DateTime EndDate
        {
            get
            {
                return this.DefaultEndDate;
            }
            set
            {
                this.DefaultEndDate = value;
            }
        }
    }
}
