using System;
using System.Collections;
using Code.AI;
using Code.GameManager;
using Code.UI.View;
using UnityEngine;

namespace Code.Round
{
    public class RoundController : MonoBehaviour, IRoundController
    {
        public OpponentAI AI;

        public Sprite RockSprite;
        public Sprite PaperSprite;
        public Sprite ScissorsSprite;
        public Sprite DefaultSprite;

        public float ShowOppenentChoiceTime = 2f;

        private IGameManager gameManager;
        private IUIViewGame gameView;
        private WaitForSeconds waitForShowOpponentChoice;

        void Awake()
        {
            gameManager = FindObjectOfType<GameManager.GameManager>();
            gameView = FindObjectOfType<UIViewGame>();
            waitForShowOpponentChoice = new WaitForSeconds(ShowOppenentChoiceTime);
        }

        void Start()
        {
            StartNewRound();
        }
        
        public void StartNewRound()
        {
            gameView.SetOpponentChoice(DefaultSprite);
            gameView.SetPlayerChoice(DefaultSprite);
            gameView.StartNewRound();
        }

        public void SetPlayerChoice(Shape playerShape)
        {
            Shape opponentShape = AI.GetRandomMove();
            RoundResult result = gameManager.ProceedRound(playerShape, opponentShape);

            StartCoroutine(RoundRoutine(playerShape, opponentShape, result));
        }

        private IEnumerator RoundRoutine(Shape playerShape, Shape opponentShape, RoundResult result)
        {
            gameView.SetOpponentChoice(GetSpriteForShape(opponentShape));
            gameView.SetPlayerChoice(GetSpriteForShape(playerShape));

            yield return waitForShowOpponentChoice;
            
            gameView.ShowRoundResult(result.ToString());
            gameView.SetScore(gameManager.GetPlayerScore(), gameManager.GetOppenentScore());
        }

        private Sprite GetSpriteForShape(Shape shape)
        {
            switch (shape)
            {
                case Shape.Rock:
                    return RockSprite;
                case Shape.Papaer:
                    return PaperSprite;
                case Shape.Scissors:
                    return ScissorsSprite;
                default:
                    return DefaultSprite;
            }
        }
    }
}