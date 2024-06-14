using RTSEngine.Entities;
using RTSEngine.Event;
using RTSEngine.Faction;
using RTSEngine.ResourceExtension;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RTSEngine.UI
{

    public struct FactionSlotStatsUIAttributes : ITaskUIAttributes
    {
        public int factionID;
        public string text;
        public FactionSlotState state;
        public Color color;
    }

    public class FactionSlotStatsUIHandler : BaseTaskPanelUIHandler<FactionSlotStatsUIAttributes>
    {
        [SerializeField, Tooltip("Parent transform of the active task UI elements that display unit type counts.")]
        private Transform panel = null;

        [SerializeField, Tooltip("Input the resoruce type whose count will be shown in the faction slot stats text and used to order the faction slot stats.")]
        private ResourceTypeInfo resourceType = null;

        private List<ITaskUI<FactionSlotStatsUIAttributes>> tasks;

        // Game services
        protected IResourceManager resourceMgr { private set; get;}
        protected IGameUITextDisplayManager textDisplayer { private set; get; } 

        #region Initializing/Terminating
        protected override void OnInit()
        {
            if (!logger.RequireValid(panel,
              $"[{GetType().Name}] The 'Panel' field must be assigned!"))
                return;

            this.resourceMgr = gameMgr.GetService<IResourceManager>();
            this.textDisplayer = gameMgr.GetService<IGameUITextDisplayManager>();

            tasks = new List<ITaskUI<FactionSlotStatsUIAttributes>>();

            if (resourceType.IsValid() && !resourceMgr.IsResourceTypeValidInGame(resourceType))
            {
                logger.LogError($"[{GetType().Name}] 'Resource Type' field value is not a resource defined in this map scene!");
                resourceType = null;
            }

            foreach(IFactionSlot slot in gameMgr.FactionSlots)
            {
                ITaskUI<FactionSlotStatsUIAttributes> task = Create(tasks, panel);

                UpdateStats(slot.ID);

                if (resourceType.IsValid())
                {
                    resourceMgr.FactionResources[slot.ID].ResourceHandlers[resourceType].FactionResourceAmountUpdated += HandleResourceAmountUpdated;
                }

                slot.FactionSlotStateUpdated += HandleFactionStateUpdated;
            }
        }

        private void HandleFactionStateUpdated(IFactionSlot slot, EventArgs args)
        {
            UpdateStats(slot.ID);
        }

        private void HandleResourceAmountUpdated(IFactionResourceHandler sender, ResourceUpdateEventArgs args)
        {
            UpdateStats(sender.FactionID);
        }

        public override void Disable()
        {
            foreach(IFactionSlot slot in gameMgr.FactionSlots)
            {
                if (resourceType.IsValid())
                {
                    resourceMgr.FactionResources[slot.ID].ResourceHandlers[resourceType].FactionResourceAmountUpdated -= HandleResourceAmountUpdated;
                }

                slot.FactionSlotStateUpdated -= HandleFactionStateUpdated;
            }
        }
        #endregion

        public void UpdateStats(int factionID)
        {
            var task = tasks[factionID];
            var slot = gameMgr.GetFactionSlot(factionID);

            textDisplayer.FactionSlotToStatsText(slot, out string statsText);

            if (resourceType.IsValid())
            {
                statsText = $"{statsText}: {resourceMgr.FactionResources[factionID].ResourceHandlers[resourceType].Amount}";
            }

            task.Reload(new FactionSlotStatsUIAttributes
            {
                factionID = factionID,
                text = $"{statsText}",
                state = slot.State,
                color = slot.Data.color
            });
        }
    }
}
