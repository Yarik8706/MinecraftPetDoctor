using UnityEngine;

namespace Watermelon
{
    public abstract class BuildingBehaviour : MonoBehaviour, IInteractableZone
    {
        [SerializeField] GameObject interactableZoneBehaviour;

        protected bool isActive;
        public bool IsActive => isActive;

        public virtual void Initialise(PlayerBehaviour playerBehavior)
        {
            IInteractableZoneBehaviour interactableZone = interactableZoneBehaviour.GetComponent<IInteractableZoneBehaviour>();
            if (interactableZone != null)
            {
                interactableZone.Initialise(this);
            }
            else
            {
                Debug.LogError(string.Format("[Building]: Interactable zone link is missing ({0})", gameObject.name));
            }
        }

        public abstract void OnZoneEnter(PlayerBehaviour playerBehavior);
        public abstract void OnZoneExit(PlayerBehaviour playerBehavior);
    }
}