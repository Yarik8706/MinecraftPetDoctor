using UnityEngine;

namespace Watermelon
{
    public class PlayerAnimationHandler : MonoBehaviour
    {
        private PlayerBehaviour playerBehavior;

        public void Inititalise(PlayerBehaviour playerBehavior)
        {
            this.playerBehavior = playerBehavior;
        }

        public void LeftStepCallback()
        {
            playerBehavior.LeftFootParticle();
        }

        public void RightStepCallback()
        {
            playerBehavior.RightFootParticle();
        }
    }
}