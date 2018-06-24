using System.Collections;
using System.Collections.Generic;
using Code.GameManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Assert = UnityEngine.Assertions.Assert;

public class TestGameManager
{
    private const int RoundsCountForTestAIWinRait = 200;
    
    private Shape[,] gameSituation = 
    {
        {Shape.Papaer, Shape.Rock},
        {Shape.Papaer, Shape.Scissors},
        {Shape.Papaer, Shape.Papaer},
        {Shape.Rock, Shape.Scissors},
        {Shape.Rock, Shape.Papaer},
        {Shape.Rock, Shape.Rock},
        {Shape.Scissors, Shape.Papaer},
        {Shape.Scissors, Shape.Rock},
        {Shape.Scissors, Shape.Scissors},
    };
    
    private GameManager gameManager;

    [UnityTest]
    public IEnumerator TestGameLogic()
    {
        yield return SetupEnvironment();
        
        for (int i = 0; i < gameSituation.GetLength(0); i+=3)
        {
            bool win = gameManager.ProceedRound(gameSituation[i, 0], gameSituation[i, 1]) == RoundResult.PlayerWin;
            Assert.IsTrue(win);
                
            bool lose = gameManager.ProceedRound(gameSituation[i+1, 0], gameSituation[i+1, 1]) == RoundResult.PlayerLose;
            Assert.IsTrue(lose);
                
            bool standoff = gameManager.ProceedRound(gameSituation[i+2, 0], gameSituation[i+2, 1]) == RoundResult.Standoff;
            Assert.IsTrue(standoff);
        }
    }
    
    [UnityTest]
    public IEnumerator TestOpponentAIWinRait()
    {
        yield return SetupEnvironment();

        bool winRateForDishonestyLevel_0_badEnought = !CheckAIWinRateForDishonestyLevel(50, 0);
        Assert.IsTrue(winRateForDishonestyLevel_0_badEnought);
        
        bool winRateForDishonestyLevel_05_goodEnought = CheckAIWinRateForDishonestyLevel(50, 0.5f);
        Assert.IsTrue(winRateForDishonestyLevel_05_goodEnought);
        
        bool winRateForDishonestyLevel_1_goodEnought = CheckAIWinRateForDishonestyLevel(100, 1f);
        Assert.IsTrue(winRateForDishonestyLevel_1_goodEnought);
    }

    private bool CheckAIWinRateForDishonestyLevel(int targetWinRate, float dishonestyLevel)
    {
        gameManager.AI.LevelOfDishonesty = dishonestyLevel;

        float AIwinsCount = 0;
        Shape playerShape;
        Shape AIShape;
        RoundResult result;

        for (int i = 0; i < RoundsCountForTestAIWinRait; i++)
        {
            playerShape = gameManager.AI.GetRandomMove();
            AIShape = gameManager.AI.GetShapeWithPrediction(playerShape);
            result = gameManager.ProceedRound(playerShape, AIShape);

            if (result == RoundResult.PlayerLose)
            {
                AIwinsCount++;
            }
        }

        float AIWinRate = AIwinsCount / RoundsCountForTestAIWinRait * 100;
        
        Debug.LogFormat("win rate of dishonesty level {0} = {1}", dishonestyLevel, AIWinRate);

        return AIWinRate >= targetWinRate;
    }

    private IEnumerator SetupEnvironment()
    {
        yield return SceneManager.LoadSceneAsync("Start");
        
        gameManager = GameObject.FindObjectOfType<GameManager>();

        yield return null;
    }
}