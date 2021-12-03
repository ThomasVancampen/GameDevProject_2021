using GameDevProject_2021.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Interfaces
{
    interface IControllable
    {
        public IInputReader InputReader { get; set; }
        public InputKeys InputKeys { get; set; }
    }
}
