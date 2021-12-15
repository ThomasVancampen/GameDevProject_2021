using GameDevProject_2021.GameObjects;
using GameDevProject_2021.GameObjects.Actors.Enemies;
using GameDevProject_2021.GameObjects.Actors.Heroes;
using GameDevProject_2021.GameObjects.StaticObjects.StaticEnemy;
using GameDevProject_2021.GameObjects.StaticObjects.StaticExit;
using GameDevProject_2021.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Managers
{
    class CollisionManager
    {
        public void Collide(Squirrel obj, List<GameObject> gameObjects, GameTime gameTime)
        {
            foreach (var go in gameObjects)
            {
                if (go is StaticObject && !(go is FireTrapp) && !(go is Exit))//moet nog anders gechecked worden, niet met staticobject
                {
                    if ((obj.Movement.X > 0 && obj.CollisionDetectionManager.CollisionLeft(obj, go)) ||
                    (obj.Movement.X < 0 && obj.CollisionDetectionManager.CollisionRight(obj, go)))
                    {
                        obj.Movement = new Vector2(0, obj.Movement.Y);
                    }
                    if ((obj.Movement.Y > 0 && obj.CollisionDetectionManager.CollisionTop(obj, go)) ||
                        (obj.Movement.Y < 0 && obj.CollisionDetectionManager.CollisionBottom(obj, go)))
                    {
                        obj.Movement = new Vector2(obj.Movement.X, 0);
                        obj.IsFalling = false;
                        obj.FallHeight = 0;
                    }
                }
                else if (go is Exit)
                {
                    if ((obj.Movement.X > 0 && obj.CollisionDetectionManager.CollisionLeft(obj, go)) ||
                    (obj.Movement.X < 0 && obj.CollisionDetectionManager.CollisionRight(obj, go)))
                    {
                        obj.Victorious = true;
                    }
                    if ((obj.Movement.Y > 0 && obj.CollisionDetectionManager.CollisionTop(obj, go)) ||
                        (obj.Movement.Y < 0 && obj.CollisionDetectionManager.CollisionBottom(obj, go)))
                    {
                        obj.Victorious = true;
                    }
                }
                else if (go is FireWall)
                {
                    if ((obj.CollisionDetectionManager.CollisionTop(obj, go)) ||
                        (obj.CollisionDetectionManager.CollisionBottom(obj, go)))
                    {
                        obj.Lives = 0;
                        obj.Exists = false;
                    }
                }
                else if (go is FireTrapp)
                {
                    if ((obj.Movement.X > 0 && obj.CollisionDetectionManager.CollisionLeft(obj, go)) ||
                    (obj.Movement.X < 0 && obj.CollisionDetectionManager.CollisionRight(obj, go)))
                    {
                        obj.Movement = new Vector2(0, obj.Movement.Y);
                        if (!obj.Hit)
                        {
                            obj.InvincibleStartTimer = gameTime.TotalGameTime.Seconds;
                            obj.Lives--;
                            obj.Hit = true;
                        }
                    }
                    if ((obj.Movement.Y > 0 && obj.CollisionDetectionManager.CollisionTop(obj, go)) ||
                        (obj.Movement.Y < 0 && obj.CollisionDetectionManager.CollisionBottom(obj, go)))
                    {
                        obj.Movement = new Vector2(obj.Movement.X, 0);
                        obj.IsFalling = false;
                        obj.FallHeight = 0;
                        if (!obj.Hit)
                        {
                            obj.InvincibleStartTimer = gameTime.TotalGameTime.Seconds;
                            obj.Lives--;
                            obj.Hit = true;
                        }
                    }

                    if (obj.Hit)//encapsuleren naar ergens anders
                    {
                        if (obj.AnimationManager.Color == Color.White)
                        {
                            obj.AnimationManager.Color = Color.Red;
                        }
                        else if(obj.AnimationManager.Color == Color.Red)
                        {
                            obj.AnimationManager.Color = Color.White;
                        }

                        if (gameTime.TotalGameTime.Seconds>obj.InvincibleStartTimer+obj.InvincibleTime)//check moet nog beter dan met elapsed gametime, dit zal er voor zorgen dat het random is
                        {
                                obj.Hit = false;
                        }
                    }
                    else
                    {
                        obj.AnimationManager.Color = Color.White;
                    }

                }

                //if (go is EnemyBullet)
                //{
                //    GotHit(obj, go, gameTime);
                //}

                if (!obj.CollisionDetectionManager.CollisionBottom(obj, go) && !obj.Jump)
                {
                    obj.IsFalling = true;
                }
                if (obj.CollisionDetectionManager.CollisionTop(obj, go))
                {
                    obj.IsFalling = true;
                }
            }
        }
        public void GotHit(Squirrel obj, GameObject go, GameTime gameTime)
        { 
            if ((obj.Movement.X > 0 && obj.CollisionDetectionManager.CollisionLeft(obj, go)) ||
                   (obj.Movement.X < 0 && obj.CollisionDetectionManager.CollisionRight(obj, go)))
            {
                if (!obj.Hit)
                {
                    obj.InvincibleStartTimer = gameTime.TotalGameTime.Seconds;
                    obj.Lives--;
                    obj.Hit = true;
                }
            }
            if ((obj.Movement.Y > 0 && obj.CollisionDetectionManager.CollisionTop(obj, go)) ||
                (obj.Movement.Y < 0 && obj.CollisionDetectionManager.CollisionBottom(obj, go)))
            {
                obj.IsFalling = false;
                obj.FallHeight = 0;
                if (!obj.Hit)
                {
                    obj.InvincibleStartTimer = gameTime.TotalGameTime.Seconds;
                    obj.Lives--;
                    obj.Hit = true;
                }
            }

            if (obj.Hit)//encapsuleren naar ergens anders
            {
                if (obj.AnimationManager.Color == Color.White)
                {
                    obj.AnimationManager.Color = Color.Red;
                }
                else if (obj.AnimationManager.Color == Color.Red)
                {
                    obj.AnimationManager.Color = Color.White;
                }

                if (gameTime.TotalGameTime.Seconds > obj.InvincibleStartTimer + obj.InvincibleTime)//check moet nog beter dan met elapsed gametime, dit zal er voor zorgen dat het random is
                {
                    obj.Hit = false;
                }
            }
            else
            {
                obj.AnimationManager.Color = Color.White;
            }
        }
    }
}
