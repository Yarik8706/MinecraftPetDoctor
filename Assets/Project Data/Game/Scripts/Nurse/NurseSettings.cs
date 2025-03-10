using UnityEngine;

namespace Watermelon
{
    [System.Serializable]
    public class NurseSettings
    {
        [SerializeField] int price;
        public int Price => price;

        [SerializeField] CurrencyType currencyType;
        public CurrencyType CurrencyType => currencyType;

        [SerializeField] MultiText multiTitle = new MultiText("Помощник", "Mr. Nurse");
        
        public string Title => multiTitle.GetText();

        [SerializeField] Sprite preview;
        public Sprite Preview => preview;

        public bool EnoughMoney()
        {
            return CurrenciesController.HasAmount(currencyType, price);
        }
    }
}