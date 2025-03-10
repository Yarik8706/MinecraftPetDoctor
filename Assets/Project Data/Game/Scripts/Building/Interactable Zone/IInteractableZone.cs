namespace Watermelon
{
    public interface IInteractableZone
    {
        public void OnZoneEnter(PlayerBehaviour playerBehavior);
        public void OnZoneExit(PlayerBehaviour playerBehavior);
    }
}