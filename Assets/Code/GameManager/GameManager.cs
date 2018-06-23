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
        private int playerScore;
        private int opponentScore;

        private IUIViewGame gameView;
        private IUIViewSettings settingsView;
        private IRoundController roundController;
    
        void Awake()
        {
            gameView = GetComponent<IUIViewGame>();
            settingsView = GetComponent<IUIViewSettings>();
            roundController = GetComponent<IRoundController>();
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