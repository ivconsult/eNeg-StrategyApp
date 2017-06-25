
namespace citPOINT.StrategyApp.Data.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies ConversationStrategySettingMetadata as the class
    // that carries additional metadata for the ConversationStrategySetting class.
    [MetadataTypeAttribute(typeof(ConversationStrategySetting.ConversationStrategySettingMetadata))]
    public partial class ConversationStrategySetting
    {

        // This class allows you to attach custom attributes to properties
        // of the ConversationStrategySetting class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ConversationStrategySettingMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ConversationStrategySettingMetadata()
            {
            }

            public Nullable<decimal> BetaValue { get; set; }

            public Guid ConversationID { get; set; }

            public Guid ConversationStrategySettingsID { get; set; }

            public Nullable<bool> Deleted { get; set; }

            public Nullable<Guid> DeletedBy { get; set; }

            public Nullable<DateTime> DeletedOn { get; set; }

            public DateTime EndDate { get; set; }

            public NegotiationStrategySetting NegotiationStrategySetting { get; set; }

            public Nullable<Guid> NegotiationStrategySettingsID { get; set; }

            public DateTime StartDate { get; set; }

            public StrategyType StrategyType { get; set; }

            public int StrategyTypeID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies NegotiationStrategySettingMetadata as the class
    // that carries additional metadata for the NegotiationStrategySetting class.
    [MetadataTypeAttribute(typeof(NegotiationStrategySetting.NegotiationStrategySettingMetadata))]
    public partial class NegotiationStrategySetting
    {

        // This class allows you to attach custom attributes to properties
        // of the NegotiationStrategySetting class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class NegotiationStrategySettingMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private NegotiationStrategySettingMetadata()
            {
            }

            public Nullable<decimal> BetaValue { get; set; }

            public EntityCollection<ConversationStrategySetting> ConversationStrategySettings { get; set; }

            public DateTime DefaultEndDate { get; set; }

            public DateTime DefaultStartDate { get; set; }

            public Nullable<bool> Deleted { get; set; }

            public Nullable<Guid> DeletedBy { get; set; }

            public Nullable<DateTime> DeletedOn { get; set; }

            public Guid NegotiationID { get; set; }

            public Guid NegotiationStrategySettingsID { get; set; }

            public StrategyType StrategyType { get; set; }

            public int StrategyTypeID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies StrategyTypeMetadata as the class
    // that carries additional metadata for the StrategyType class.
    [MetadataTypeAttribute(typeof(StrategyType.StrategyTypeMetadata))]
    public partial class StrategyType
    {

        // This class allows you to attach custom attributes to properties
        // of the StrategyType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class StrategyTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private StrategyTypeMetadata()
            {
            }

            public Nullable<decimal> Beta { get; set; }

            public EntityCollection<ConversationStrategySetting> ConversationStrategySettings { get; set; }

            public EntityCollection<NegotiationStrategySetting> NegotiationStrategySettings { get; set; }

            public int StrategyTypeID { get; set; }

            public string StrategyTypeName { get; set; }
        }
    }
}
