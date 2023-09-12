namespace TicTacToeGame.States
{
    public class BaseState : IState
    {
        public virtual void Enter(params object[] parameters) { }

        public virtual void Exit() { }

        public virtual void Render() { }

        public virtual void Update() { }
    }
}
