using GameDevProject_2021.GameObjects.Actors;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Interfaces
{
    interface IInputReader
    {
        Vector2 ReadInput(IJumpable obj);
        Vector2 ReadInput(IMoveable obj);
    }
}
