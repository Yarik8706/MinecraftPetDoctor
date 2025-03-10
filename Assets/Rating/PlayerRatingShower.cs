using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Watermelon;
using YG;
using YG.Utils.LB;

public class PlayerRatingShower : MonoBehaviour
{
    [SerializeField] private TMP_Text playerRatingText;
    [SerializeField] private Image ratingImage;

    private int playerRank;
    private int playerScore;
    private bool isFirstTime = true;
    
    public static PlayerRatingShower Instance { get; private set; }

    private void Awake() 
    {
        Instance = this;
        YandexGame.onGetLeaderboard += OnUpdateLB;
    }
    
    public void Initialise()
    {
        CurrenciesController.SubscribeGlobalCallback((cur, dif) => CurrencyChange(cur.CurrencyType, dif));
        YandexGame.GetLeaderboard("Score",
            Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, "nonePhoto");

    } 

    public void CurrencyChange(CurrencyType currency, int difference)
    {
        if (currency != CurrencyType.Money) return;
        if (difference <= 0) return;
        playerScore += difference;
        Debug.Log("[Rating] Currency change: " + difference);
        YandexGame.NewLeaderboardScores("Score", playerScore);
        YandexGame.GetLeaderboard("Score",
            Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, "nonePhoto");
    }

    private void OnUpdateLB(LBData lb)
    {
        var playerRank = 0;
        foreach (var player in lb.players)
        {
            if (player.uniqueID == YandexGame.playerId)
            {
                playerRank = player.rank;
                if (isFirstTime)
                {
                    playerScore = player.score;
                    isFirstTime = false;
                }
                UpdateRating(playerRank);  
                return;
            }
        }

        playerRank = lb.players.Length + 1;
        UpdateRating(playerRank);
        if (isFirstTime)
        {
            playerScore = 0;
            isFirstTime = false;
        }
    }

    public void UpdateRating(int newPlayerRating)
    {
        if (playerRank == newPlayerRating)
        {
            return;
        }

        playerRank = newPlayerRating;
        playerRatingText.transform.DOScale(playerRatingText.transform.localScale * 1.2f, 0.5f).OnComplete(() =>
        {
            playerRatingText.text = "" + newPlayerRating;
            playerRatingText.transform.DOScale(playerRatingText.transform.localScale * 0.8f, 0.5f);
        }).SetDelay(0.4f);
    }
}