namespace Code.GameManager
{
    public interface IGameManager
    {
        RoundResult ProceedRound(Shape playerShape, Shape oppenentShape);
        int GetPlayerScore();
        int GetOppenentScore();
    }
}
