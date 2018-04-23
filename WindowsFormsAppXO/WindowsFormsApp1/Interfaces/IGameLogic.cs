namespace WindowsFormsApp1.Interfaces
{
    public interface IGameLogic
    {
        void Start();

        FieldState[] GetField();

        GameState Step(int index, FieldState field);

        GameState GetState();

        GameState CompStep();

        int StepCounter { get; }
    }
}
