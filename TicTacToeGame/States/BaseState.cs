using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
