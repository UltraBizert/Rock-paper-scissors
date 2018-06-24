using Code.GameManager;
using Code.Round;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.View
{
    public class UIViewGame : MonoBehaviour, IUIViewGame
    {
        private const string ScoreSeparator = " : ";
        
        public Text ScoreText;
        public Image PlayerChoiceImage;
        public Image OpponentChoiceImage;
        public GameObject RoundResultPanel;
        public Text RoundResultText;

        private IRoundController roundController;
        private IGameManager gameManager;

        void Awake()
        {
            roundController = FindObjectOfType<RoundController>();
            gameManager = FindObjectOfType<GameManager.GameManager>();
        }
        
        public void SelectRock()
        {
            roundController.SetPlayerChoice(Shape.Rock);
        }

        public void SelectPaper()
        {
            roundController.SetPlayerChoice(Shape.Papaer);
        }

        public void SelectScissors()
        {
            roundController.SetPlayerChoice(Shape.Scissors);
        }

        public void SelectNewRound()
        {
            roundController.StartNewRound();
        }

        public void SetScore(int player, int opponent)
        {
            if (!ScoreText) 
                return;
            
            ScoreText.text = player + ScoreSeparator + opponent;
        }

        public void SetPlayerChoice(Sprite sprite)
        {
            PlayerChoiceImage.sprite = sprite;
        }

        public void SetOpponentChoice(Sprite sprite)
        {
            OpponentChoiceImage.sprite = sprite;
        }

        public void ShowRoundResult(string result)
        {
            RoundResultPanel.SetActive(true);
            RoundResultText.text = result;
        }

        public void StartNewRound()
        {
            RoundResultPanel.SetActive(false);
        }

        public void OpenSettings()
        {
            gameManager.OpenSettings();
        }
    }
}