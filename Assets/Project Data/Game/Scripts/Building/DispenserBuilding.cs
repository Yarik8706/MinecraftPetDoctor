using UnityEngine;

namespace Watermelon
{
    public class DispenserBuilding : MonoBehaviour, IInteractableZone
    {
        [SerializeField] Item.Type itemType;
        public Item.Type ItemType => itemType;

        [SerializeField] WaitingIndicatorBehaviour waitingIndicatorBehaviour;
        [SerializeField] InteractableZoneBehaviour interactableZoneBehaviour;

        [Space]
        [SerializeField] GameObject graphicsGameObject;
        [SerializeField] GameObject lockGameObject;
        [SerializeField] Transform rotateTransform;
        [SerializeField] Vector3 baseRotation;
        [SerializeField] Vector3 openRotation;
        [SerializeField] SpriteRenderer iconSpriteRenderer;

        [Space]
        [SerializeField] float openTime;
        [SerializeField] Ease.Type openEasing;

        [SerializeField] float closeTime;
        [SerializeField] Ease.Type closeEasing;

        private bool isPlayerEnteredZone;
        private PlayerBehaviour playerBehavior;

        private TweenCase openTweenCase;

        private bool isUnlocked = true;
        public bool IsUnlocked => isUnlocked;

        public void Initialise()
        {
            interactableZoneBehaviour.Initialise(this);

            waitingIndicatorBehaviour.gameObject.SetActive(false);

            Item item = ItemController.GetItem(itemType);
            iconSpriteRenderer.sprite = item.IconOnBuildings;

            graphicsGameObject.SetActive(isUnlocked);
            lockGameObject.SetActive(!isUnlocked);
        }

        public void PickItem(IItemCarrying itemCarrying)
        {
            if (!isUnlocked)
                return;

            PlayOpenAnimation();

            itemCarrying.AddItem(itemType);
        }

        private void EnableDispenser()
        {
            waitingIndicatorBehaviour.gameObject.SetActive(true);
            waitingIndicatorBehaviour.Initialise(LevelController.ItemPickUpDuration, delegate
            {
                PlayOpenAnimation();

                playerBehavior.AddItem(itemType);

                AudioController.PlaySound(AudioController.Sounds.itemPickUpSound);

                if (playerBehavior.HasFreeSpace())
                {
                    Tween.DelayedCall(0.1f, delegate
                    {
                        if (isPlayerEnteredZone)
                            EnableDispenser();
                    });
                }
                else
                {
                    PlayerBehaviour.SpawnMaxText();
                }
            });
        }

        public void OnZoneEnter(PlayerBehaviour playerBehavior)
        {
            if (!isUnlocked)
                return;

            this.playerBehavior = playerBehavior;

            isPlayerEnteredZone = true;

            if (playerBehavior.HasFreeSpace())
            {
                EnableDispenser();
            }
            else
            {
                PlayerBehaviour.SpawnMaxText();
            }
        }

        public void OnZoneExit(PlayerBehaviour playerBehavior)
        {
            if (!isUnlocked)
                return;

            isPlayerEnteredZone = false;

            waitingIndicatorBehaviour.Disable();
        }

        private void PlayOpenAnimation()
        {
            if (openTweenCase != null && !openTweenCase.isCompleted)
                openTweenCase.Kill();

            rotateTransform.localRotation = Quaternion.Euler(baseRotation);

            openTweenCase = rotateTransform.DOLocalRotate(Quaternion.Euler(openRotation), openTime).SetEasing(openEasing).OnComplete(delegate
            {
                openTweenCase = Tween.DelayedCall(0.1f, delegate
                {
                    openTweenCase = rotateTransform.DOLocalRotate(baseRotation, closeTime).SetEasing(closeEasing);
                });
            });
        }

        public void SetUnlockState(bool state)
        {
            isUnlocked = state;

            //graphicsGameObject.SetActive(isUnlocked);
            lockGameObject.SetActive(!isUnlocked);
        }
    }
}