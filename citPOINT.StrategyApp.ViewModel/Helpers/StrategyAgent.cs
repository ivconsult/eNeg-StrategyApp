
#region → Usings   .
using System;

#endregion

#region → History  .

/* 
 * Date         User            Change
 * *********************************************
 * 1/15/2012 5:28:45 PM      mwahab         • creation
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

namespace citPOINT.StrategyApp.ViewModel
{

    /// <summary>
    /// Class for Strategy Agent 
    /// </summary>
    public class StrategyAgent
    {
        #region → Fields         .

        //Up Down +-5
        private const int ACCEPTDIFFERENCE = 5;

        private double mMinimumScore = 0;

        private double mMaximumScore = 0;

        private double mBetaValue = 0;

        private DateTime mStartDate;

        private DateTime mEndDate;

        double mStrageyScore = 0;

        private string mStatus;

        private string mAdvice;

        private bool mIsFitsStrategy = true;

        #endregion

        #region → Properties     .

        /// <summary>
        /// Gets or sets the minimum score.
        /// </summary>
        /// <value>The minimum score.</value>
        private double MinimumScore
        {
            get { return mMinimumScore; }
            set { mMinimumScore = value; }
        }

        /// <summary>
        /// Gets or sets the maximum score.
        /// </summary>
        /// <value>The maximum score.</value>
        private double MaximumScore
        {
            get { return mMaximumScore; }
            set { mMaximumScore = value; }
        }

        /// <summary>
        /// Gets or sets the beta value.
        /// </summary>
        /// <value>The beta value.</value>
        private double BetaValue
        {
            get { return mBetaValue; }
            set { mBetaValue = value; }
        }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        private DateTime StartDate
        {
            get { return mStartDate; }
            set { mStartDate = value; }
        }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        private DateTime EndDate
        {
            get { return mEndDate; }
            set { mEndDate = value; }
        }

        /// <summary>
        /// Gets or sets the stragey score.
        /// </summary>
        /// <value>The stragey score.</value>
        public double StrageyScore
        {
            get { return mStrageyScore; }
            set { mStrageyScore = value; }
        }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string Status
        {
            get { return mStatus; }
            set { mStatus = value; }
        }

        /// <summary>
        /// Gets or sets the advice.
        /// </summary>
        /// <value>The advice.</value>
        public string Advice
        {
            get { return mAdvice; }
            set { mAdvice = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is fits strategy.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is fits strategy; otherwise, <c>false</c>.
        /// </value>
        public bool IsFitsStrategy
        {
            get
            {
                return mIsFitsStrategy;
            }
            set
            {
                mIsFitsStrategy = value;
            }
        }

        #endregion Properties

        #region → Constractor    .

        /// <summary>
        /// Initializes a new instance of the <see cref="StrategyAgent"/> class.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="minimumScore">The minimum score.</param>
        /// <param name="maximumScore">The maximum score.</param>
        /// <param name="betaValue">The beta value.</param>
        public StrategyAgent(DateTime startDate, DateTime endDate, double minimumScore, double maximumScore, double betaValue)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.MinimumScore = minimumScore;
            this.MaximumScore = maximumScore;
            this.BetaValue = betaValue;
        }

        #endregion

        #region → Methods        .

        #region → Private        .

        /// <summary>
        /// Gets the offer time distance.
        /// for example where we are from the start date to end date 
        /// e.g. suppose we start negotaiotion at 01/01 and end at 30/01 so if 
        /// current date is 15/01  so distance is .50 %.
        /// and follow it with minutes...
        /// </summary>
        /// <param name="currentDate">The current date.</param>
        /// <returns>return time distance</returns>
        private double GetOfferTimeDistance(DateTime currentDate)
        {
            double totalRange = this.EndDate.Subtract(this.StartDate).TotalMinutes;

            double offerRange = currentDate.Subtract(this.StartDate).TotalMinutes;

            return Math.Round(offerRange / totalRange, 2);
        }

        /// <summary>
        /// Fills the status and advice.
        /// </summary>
        /// <param name="strageyScore">The stragey score.</param>
        /// <param name="offerPercentage">The offer percentage.</param>
        private void FillStatusAndAdvice(double strageyScore, double offerPercentage)
        {
            // We accept if the current offer score is 86 and it should be 90 so we accept 
            // that as accept rate are 5 so from 85 : 95 its ok

            if ((offerPercentage) >= (strageyScore - ACCEPTDIFFERENCE) &&
                (offerPercentage) <= (strageyScore + ACCEPTDIFFERENCE))
            {
                // Your offer fits to the strategy.
                this.Status = Resources.StategyStatusFits;

                this.Advice = Resources.StrategyNoAdvice;
                this.IsFitsStrategy = true;
            }
            else
            {
                // Your offer not fits to the strategy.
                this.Status = Resources.StategyStatusNotFits;

                //Please {0} the total rate of the offer to be {1}
                this.Advice = string.Format(Resources.StrategyAdvice,
                                             (offerPercentage < strageyScore) ? "increase" : "decrease",
                                              strageyScore);
                this.IsFitsStrategy = false;
            }
        }

        #endregion

        #region → Public         .

        /// <summary>
        /// Runs the agent.
        /// </summary>
        /// <param name="currentDate">The current date.</param>
        /// <param name="offerPercentage">The offer percentage.</param>
        public void RunAgent(DateTime currentDate, double offerPercentage)
        {
            try
            {

                this.RunAgent(currentDate);

                FillStatusAndAdvice(this.StrageyScore, offerPercentage);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Runs the agent.
        /// </summary>
        /// <param name="currentDate">The current date.</param>
        public void RunAgent(DateTime currentDate)
        {
            try
            {
                /*
                 *  First of all we get t time
                 *  
                 * alpha(t)=t^(1/beta)
                 * 
                 * score=alpha*(max-min)+min
                 * 
                 */

                double offerTime = GetOfferTimeDistance(currentDate);

                double alpha = Math.Pow(offerTime, (1.0 / BetaValue));

                this.StrageyScore = alpha * (MaximumScore - MinimumScore) + MinimumScore;

                this.StrageyScore = Math.Round(this.StrageyScore, 2);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {

            return string.Format(
                 "\r\n" +
                  "Start Date    :{0}\r\n" +
                  "End Date      :{1}\r\n" +
                  "Minimum Score :{2}\r\n" +
                  "Maximum Score :{3}\r\n" +
                  "Beta Value    :{4}",

                    this.StartDate,
                    this.EndDate,
                    this.MinimumScore,
                    this.MaximumScore,
                    this.BetaValue);
        }

        #endregion  Public

        #endregion Methods

    }
}
