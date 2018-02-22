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
    class AnimatedSprite
    {
        public Color color;
        public Vector2 position;
        public int frameWidth, frameHeight, currentFrame, movingPlayerFrames;
        public int ticks = 0, animationSpeed;
        public Texture2D texture;
        public bool hflip = false;

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!hflip)
                spriteBatch.Draw(texture, position, new Rectangle(currentFrame * frameWidth, 0,
                frameWidth, frameHeight), color, 0, Vector2.Zero, 1,
                SpriteEffects.None, 0);
            else
                spriteBatch.Draw(texture, position, new Rectangle(currentFrame * frameWidth, 0,
                frameWidth, frameHeight), color, 0, Vector2.Zero, 1,
                SpriteEffects.FlipHorizontally, 0);
        }

        public void Update()
        {
            ticks--;
            if (ticks <= 0)
            {
                ticks = animationSpeed;
                currentFrame++;
                if (currentFrame >= movingPlayerFrames)
                    currentFrame = 0;
            }
        }
    }
}
