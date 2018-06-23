using Code.GameManager;

namespace Code.Round
{
    public interface IRoundController
    {
        void StartNewRound();
        void SetPlayerChoice(Shape playerShape);
    }
}