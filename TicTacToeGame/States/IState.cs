﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.States
{
    public interface IState
    {
        public void Enter(params object[] parameters);

        public void Exit();

        public void Update();

        public void Render();
    }
}
