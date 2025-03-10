using UnityEngine;

namespace Watermelon
{
    public interface IPurchaseObject
    {
        public bool IsOpened { get; }

        public CurrencyType PriceCurrencyType { get; }
        public int PriceAmount { get; }

        public int PlacedCurrencyAmount { get; }

        public Transform Transform { get; }

        public void PlaceCurrency(int amount);
        public void OnPurchaseCompleted();

        public void OnPlayerEntered(PlayerBehaviour playerBehavior);
        public void OnPlayerExited(PlayerBehaviour playerBehavior);
    }
}