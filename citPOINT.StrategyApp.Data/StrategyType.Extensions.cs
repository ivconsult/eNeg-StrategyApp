
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
    /// StrategyType class client-side extensions
    /// </summary>
    public partial class StrategyType
    {
        #region → Fields         .

        #endregion
        
        #region → Properties     .

        #endregion

        #region → Methods        .

        /// <summary>
        /// Try validate for the StrategyType class
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
            if (propertyName == "StrategyTypeID"
             || propertyName == "StrategyTypeName"
             || propertyName == "Beta"
            )
            {

                ValidationContext context = new ValidationContext(this, null, null) { MemberName = propertyName };
                var validationResults = new Collection<ValidationResult>();
                if (propertyName == "StrategyTypeID")
                    return Validator.TryValidateProperty(this.StrategyTypeID, context, validationResults);
                if (propertyName == "StrategyTypeName")
                    return Validator.TryValidateProperty(this.StrategyTypeName, context, validationResults);
                if (propertyName == "Beta")
                    return Validator.TryValidateProperty(this.Beta, context, validationResults);
            }
            return false;
        }


        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>return new Instance of StrategyType</returns>
        public StrategyType Clone()
        {
            StrategyType mStrategyType = new StrategyType
                                        {
                                            StrategyTypeID = this.StrategyTypeID,
                                            StrategyTypeName = this.StrategyTypeName,
                                            Beta = this.Beta,


                                        };

            return mStrategyType;
        }




        #endregion Methods

    }

}
