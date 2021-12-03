using GameDevProject_2021.GameObjects.Actors;
using GameDevProject_2021.GameObjects.Actors.Heroes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Interfaces
{
    interface IInputReader
    {
        Vector2 ReadInput(Hero obj);
        //Vector2 ReadInput(IMoveable obj);

    }
}
