using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using Assert = UnityEngine.Assertions.Assert;

public class TestGameManager
{
//        private Shape[,] gameSituation = 
//        {
//            {Shape.Papaer, Shape.Rock},
//            {Shape.Papaer, Shape.Scissors},
//            {Shape.Papaer, Shape.Papaer},
//            {Shape.Rock, Shape.Scissors},
//            {Shape.Rock, Shape.Papaer},
//            {Shape.Rock, Shape.Rock},
//            {Shape.Scissors, Shape.Papaer},
//            {Shape.Scissors, Shape.Rock},
//            {Shape.Scissors, Shape.Scissors},
//        };
    
    [Test]
    public void GameLogicTest()
    {
//            for (int i = 0; i < gameSituation.Length; i+=3)
//            {
//                bool win = GameManager.ProceedRound(gameSituation[i, 0], gameSituation[i, 1]) == RoundResult.PlayerWin;
//                Assert.IsTrue(win);
//                
//                bool lose = GameManager.ProceedRound(gameSituation[i+1, 0], gameSituation[i+1, 1]) == RoundResult.PlayerLose;
//                Assert.IsTrue(lose);
//                
//                bool standoff = GameManager.ProceedRound(gameSituation[i+2, 0], gameSituation[i+2, 1]) == RoundResult.Standoff;
//                Assert.IsTrue(standoff);
//            }
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        yield return null;
    }
}
