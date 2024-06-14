using RTSEngine.Model;
using RTSEngine.UnitExtension;
using UnityEngine;

namespace RTSEngine.EntityComponent
{
    public interface ICarriableUnit : IEntityTargetComponent
    {
        IUnitCarrier CurrCarrier { get; }
        Transform CurrSlot { get; }
        int CurrSlotID { get; }
        //bool AllowMovementToExitCarrier { get; }

        AddableUnitData GetAddableData(bool playerCommand);
        AddableUnitData GetAddableData(SetTargetInputData input);
        ErrorMessage SetTarget(IUnitCarrier carrier, AddableUnitData addableData);
    }
}