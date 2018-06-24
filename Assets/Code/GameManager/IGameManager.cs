namespace Code.GameManager
{
    public interface IGameManager
    {
        RoundResult ProceedRound(Shape playerShape, Shape oppenentShape);
        Shape GetOpponentShape(Shape playerShape);
        int GetPlayerScore();
        int GetOppenentScore();
        void ActivateHonestAI(bool playWithHonest);
        void SetOpponentAIDishonesty(float levelOfDishonesty);
        void OpenSettings();
    }
}
