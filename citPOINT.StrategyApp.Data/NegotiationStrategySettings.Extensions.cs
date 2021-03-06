
#region → Usings   .
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
#endregion

#region → History  .

/* Date         User            Change
 * 
 *15.01.12     M.Wahab     creation
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
    /// NegotiationStrategySettings class client-side extensions
    /// </summary>
    public partial class NegotiationStrategySetting
    {
        #region → Fields         .

        private const int OtherStrategyTypeID = 6;

        #endregion

        #region → Properties     .

        /// <summary>
        /// Gets a value indicating whether this instance is strategy defined by user.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is strategy defined by user; otherwise, <c>false</c>.
        /// </value>
        public bool IsStrategyDefinedByUser
        {
            get
            {
                return this.StrategyTypeID == OtherStrategyTypeID;
            }
        }

        #endregion

        #region → Event Handlers .

        /// <summary>
        /// Called when an <see cref="T:System.ServiceModel.DomainServices.Client.Entity"/> property has changed.
        /// </summary>
        /// <param name="e">The event arguments</param>
        protected override void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.PropertyName == "StrategyType")
            {
                if (this.StrategyType != null)
                {
                    this.BetaValue = this.StrategyType.Beta;
                    this.RaiseDataMemberChanged("IsStrategyDefinedByUser");
                }
            }
        }

        #endregion

        #region → Methods        .

        /// <summary>
        /// Try validate for the NegotiationStrategySettings class
        /// </summary>
        /// <returns>True Or False </returns>
        public bool TryValidateObject()
        {


            ValidationContext context = new ValidationContext(this, null, null);
            var validationResults = new Collection<ValidationResult>();

            if (Validator.TryValidateObject(this, context, validationResults, false) == false)
            {
                foreach (ValidationResult error in validationResults)
                {
                    this.ValidationErrors.Add(error);
                }
                return false;
            }


            return true;
        }


        /// <summary>    
        /// Try Try Validate by Property name  
        /// </summary> 
        /// <returns>True Or False </returns> 
        public bool TryValidateProperty(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }
            if (propertyName == "NegotiationStrategySettingsID"
             || propertyName == "NegotiationID"
             || propertyName == "DefaultStartDate"
             || propertyName == "DefaultEndDate"
             || propertyName == "BetaValue"
             || propertyName == "StrategyTypeID"
             || propertyName == "Deleted"
             || propertyName == "DeletedBy"
             || propertyName == "DeletedOn"
            )
            {

                ValidationContext context = new ValidationContext(this, null, null) { MemberName = propertyName };
                var validationResults = new Collection<ValidationResult>();
                if (propertyName == "NegotiationStrategySettingsID")
                    return Validator.TryValidateProperty(this.NegotiationStrategySettingsID, context, validationResults);
                if (propertyName == "NegotiationID")
                    return Validator.TryValidateProperty(this.NegotiationID, context, validationResults);
                if (propertyName == "DefaultStartDate")
                    return Validator.TryValidateProperty(this.DefaultStartDate, context, validationResults);
                if (propertyName == "DefaultEndDate")
                    return Validator.TryValidateProperty(this.DefaultEndDate, context, validationResults);
                if (propertyName == "BetaValue")
                    return Validator.TryValidateProperty(this.BetaValue, context, validationResults);
                if (propertyName == "StrategyTypeID")
                    return Validator.TryValidateProperty(this.StrategyTypeID, context, validationResults);
                if (propertyName == "Deleted")
                    return Validator.TryValidateProperty(this.Deleted, context, validationResults);
                if (propertyName == "DeletedBy")
                    return Validator.TryValidateProperty(this.DeletedBy, context, validationResults);
                if (propertyName == "DeletedOn")
                    return Validator.TryValidateProperty(this.DeletedOn, context, validationResults);
            }
            return false;
        }


        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>return new Instance of NegotiationStrategySettings</returns>
        public NegotiationStrategySetting Clone()
        {
            NegotiationStrategySetting mNegotiationStrategySettings = new NegotiationStrategySetting
                                        {
                                            NegotiationStrategySettingsID = this.NegotiationStrategySettingsID,
                                            NegotiationID = this.NegotiationID,
                                            DefaultStartDate = this.DefaultStartDate,
                                            DefaultEndDate = this.DefaultEndDate,
                                            BetaValue = this.BetaValue,
                                            StrategyTypeID = this.StrategyTypeID,
                                            Deleted = this.Deleted,
                                            DeletedBy = this.DeletedBy,
                                            DeletedOn = this.DeletedOn,


                                        };

            return mNegotiationStrategySettings;
        }




        #endregion Methods

    }

}
