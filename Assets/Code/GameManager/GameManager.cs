using Code.AI;
using Code.Round;
using Code.UI.View;
using UnityEngine;

namespace Code.GameManager
{
    public enum Shape
    {
        Rock,
        Papaer,
        Scissors,
    }

    public enum RoundResult
    {
        Standoff,
        PlayerWin,
        PlayerLose,
    }
    
    public class GameManager : MonoBehaviour, IGameManager
    {
        public OpponentAI AI;
        
        private int playerScore;
        private int opponentScore;

        private IUIViewGame gameView;
        private IUIViewSettings settingsView;
        private IRoundController roundController;
        private bool playWithHonestAI = true;
        
        void Awake()
        {
            gameView = FindObjectOfType<UIViewGame>();
            settingsView = FindObjectOfType<UIViewSettings>();
            roundController = FindObjectOfType<RoundController>();
        }

        void Start()
        {
            settingsView.CloseSettingsPanel();
            roundController.StartNewRound();
        }

        public void ActivateHonestAI(bool playWithHonest)
        {
            playWithHonestAI = playWithHonest;
        }

        public void SetOpponentAIDishonesty(float levelOfDishonesty)
        {
            AI.LevelOfDishonesty = levelOfDishonesty;
        }

        public void OpenSettings()
        {
            settingsView.OpenSettingsPanel();
        }

        public Shape GetOpponentShape(Shape playerShape)
        {
            if (playWithHonestAI)
            {
                return AI.GetRandomMove();
            }
            
            return AI.GetShapeWithPrediction(playerShape);
        }
        
        public RoundResult ProceedRound(Shape playerChoice, Shape oppenentChoice)
        {
            int p = (int) playerChoice;
            int o = (int) oppenentChoice;
            bool playerWin = (p - o + 3) % 3 == 1;
            
            if (p == o)
            {
                return RoundResult.Standoff;
            }
            
            if (playerWin)
            {
                playerScore++;
                return RoundResult.PlayerWin;
            }

            opponentScore++;
            return RoundResult.PlayerLose;
        }

        public int GetPlayerScore()
        {
            return playerScore;
        }

        public int GetOppenentScore()
        {
            return opponentScore;
        }
    }
}