namespace Core.Game_FSM
{
    public interface IGameState
    {
        public void Execute();
    }

    public interface IGameState<TParam> : IGameState
    {
        public void SetParam(TParam param);
    }
}