using UnityEngine;

namespace Watermelon
{
    public class InteractableZoneBehaviour : MonoBehaviour, IInteractableZoneBehaviour
    {
        private IInteractableZone interactableZone;

        public void Initialise(IInteractableZone interactableZone)
        {
            this.interactableZone = interactableZone;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(PhysicsHelper.TAG_PLAYER))
            {
                interactableZone.OnZoneEnter(other.GetComponent<PlayerBehaviour>());
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(PhysicsHelper.TAG_PLAYER))
            {
                interactableZone.OnZoneExit(other.GetComponent<PlayerBehaviour>());
            }
        }
    }
}