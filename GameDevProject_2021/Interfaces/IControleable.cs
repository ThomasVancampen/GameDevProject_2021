using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Interfaces
{
    interface IControleable
    {
        public IInputReader InputReader { get; set; }
    }
}
