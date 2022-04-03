using System;
using Microsoft.Xna.Framework;
using NDS_Remake_DinosaurKing.Data;
using NDS_Remake_DinosaurKing.SpriteSheets;

namespace NDS_Remake_DinosaurKing.Humans
{
    public class Player : Sprite, IUpdate
    {

        private Point _target;

        public void Update(GameTime gameTime, SimulationArea simulationArea)
        {
            if (Position.ToPoint() == _target)
            {
                var old = _target;
                if (InputHandler.IsUp)
                {
                    Index = (int)PlayerSpriteSheet.Index.Top_Idle;
                    _target.Y -= 24;
                }

                if (InputHandler.IsDown)
                {
                    Index = (int)PlayerSpriteSheet.Index.Down_Idle;
                    _target.Y += 24;
                }

                if (InputHandler.IsLeft)
                {
                    Index = (int)PlayerSpriteSheet.Index.Left_Idle;
                    _target.X -= 24;
                }

                if (InputHandler.IsRight)
                {
                    Index = (int)PlayerSpriteSheet.Index.Right_Idle;
                    _target.X += 24;
                }
            }
            else
            {
                var positionPoint = Position.ToPoint();
                if (_target.X > positionPoint.X)
                {
                    Position.X++;
                }
                else if (_target.X < positionPoint.X)
                {
                    Position.X--;
                }
                else if (_target.Y > positionPoint.Y)
                {
                    Position.Y++;
                }
                else if (_target.Y < positionPoint.Y)
                {
                    Position.Y--;
                }
            }
            
        }
    }

    public interface IUpdate
    {
        public void Update(GameTime gameTime, SimulationArea simulationArea);
    }
}