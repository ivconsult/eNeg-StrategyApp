
namespace citPOINT.StrategyApp.Data.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // Implements application logic using the StrategyAppEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public partial class StrategyAppService : LinqToEntitiesDomainService<StrategyAppEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'ConversationStrategySettings' query.
        public IQueryable<ConversationStrategySetting> GetConversationStrategySettings()
        {
            return this.ObjectContext.ConversationStrategySettings;
        }

        public void InsertConversationStrategySetting(ConversationStrategySetting conversationStrategySetting)
        {
            if ((conversationStrategySetting.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(conversationStrategySetting, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ConversationStrategySettings.AddObject(conversationStrategySetting);
            }
        }

        public void UpdateConversationStrategySetting(ConversationStrategySetting currentConversationStrategySetting)
        {
            this.ObjectContext.ConversationStrategySettings.AttachAsModified(currentConversationStrategySetting, this.ChangeSet.GetOriginal(currentConversationStrategySetting));
        }

        public void DeleteConversationStrategySetting(ConversationStrategySetting conversationStrategySetting)
        {
            if ((conversationStrategySetting.EntityState == EntityState.Detached))
            {
                this.ObjectContext.ConversationStrategySettings.Attach(conversationStrategySetting);
            }
            this.ObjectContext.ConversationStrategySettings.DeleteObject(conversationStrategySetting);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'NegotiationStrategySettings' query.
        public IQueryable<NegotiationStrategySetting> GetNegotiationStrategySettings()
        {
            return this.ObjectContext.NegotiationStrategySettings;
        }

        public void InsertNegotiationStrategySetting(NegotiationStrategySetting negotiationStrategySetting)
        {
            if ((negotiationStrategySetting.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(negotiationStrategySetting, EntityState.Added);
            }
            else
            {
                this.ObjectContext.NegotiationStrategySettings.AddObject(negotiationStrategySetting);
            }
        }

        public void UpdateNegotiationStrategySetting(NegotiationStrategySetting currentNegotiationStrategySetting)
        {
            this.ObjectContext.NegotiationStrategySettings.AttachAsModified(currentNegotiationStrategySetting, this.ChangeSet.GetOriginal(currentNegotiationStrategySetting));
        }

        public void DeleteNegotiationStrategySetting(NegotiationStrategySetting negotiationStrategySetting)
        {
            if ((negotiationStrategySetting.EntityState == EntityState.Detached))
            {
                this.ObjectContext.NegotiationStrategySettings.Attach(negotiationStrategySetting);
            }
            this.ObjectContext.NegotiationStrategySettings.DeleteObject(negotiationStrategySetting);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'StrategyTypes' query.
        public IQueryable<StrategyType> GetStrategyTypes()
        {
            return this.ObjectContext.StrategyTypes;
        }

        public void InsertStrategyType(StrategyType strategyType)
        {
            if ((strategyType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(strategyType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.StrategyTypes.AddObject(strategyType);
            }
        }

        public void UpdateStrategyType(StrategyType currentStrategyType)
        {
            this.ObjectContext.StrategyTypes.AttachAsModified(currentStrategyType, this.ChangeSet.GetOriginal(currentStrategyType));
        }

        public void DeleteStrategyType(StrategyType strategyType)
        {
            if ((strategyType.EntityState == EntityState.Detached))
            {
                this.ObjectContext.StrategyTypes.Attach(strategyType);
            }
            this.ObjectContext.StrategyTypes.DeleteObject(strategyType);
        }
    }
}


