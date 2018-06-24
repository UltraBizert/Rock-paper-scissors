using UnityEngine;

namespace Code.UI.View
{
    public interface IUIViewGame
    {
        void SetScore(int player, int opponent);
        void SetPlayerChoice(Sprite sprite);
        void SetOpponentChoice(Sprite sprite);
        void ShowRoundResult(string result);
        void StartNewRound();
        void OpenSettings();
    }
}
