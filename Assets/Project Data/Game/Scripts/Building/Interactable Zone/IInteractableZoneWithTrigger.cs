namespace Watermelon
{
    public interface IInteractableZoneWithTrigger : IInteractableZone
    {
        public void OnZoneTriggerActivated(PlayerBehaviour playerBehavior);
    }
}