using GameDevProject_2021.Model.Animation1;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.GameObjects.StaticObjects.StaticPlatform
{
    class StaticPlatform : StaticObject
    {
        public StaticPlatform(Dictionary<string, Animation> animations) : base(animations)
        {
        }
    }
}
