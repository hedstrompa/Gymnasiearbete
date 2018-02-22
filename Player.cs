using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gymnasiearbete
{
    class Player : AnimatedSprite
    {
        public Color color;
        public float speed = 2.1f;
        public bool walking = false;
        
        public void Update()
        {
            check_keys();
            if (walking)
                base.Update();
        }
        public void check_keys()
        {            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                walking = true;
                hflip = true;

                position.X -= speed;
                if (position.X < -80)
                    position.X = 640;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                walking = true;
                hflip = false;

                position.X += speed;
                if (position.X > 640)
                    position.X = -80;
            }
            else
            {
                walking = false;
                currentFrame = 8;
                ticks = animationSpeed;
            }        }    }
}
