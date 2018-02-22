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

    class Deform
    {
        private Texture2D textureLevel;
        private Texture2D textureDeform;
        private Vector2 mousePos;
        private uint[] pixelDeformData;
<<<<<<< HEAD
        private Texture2D deformTexture;
        List<Deform> textures = new List<Deform>();


        /*public DecideDeform ()
        {
            foreach(Deform texture in textures)
            {
                

            }
            return deformTexture;
        }*/
=======
>>>>>>> bd93401c08294f20225b188b8dd87fcf1e71f6be

        public Deform(Texture2D textureLevel, Texture2D textureDeform)
        {
            this.textureLevel = textureLevel;
            this.textureDeform = textureDeform;

            pixelDeformData = new uint[textureDeform.Width * textureDeform.Height];
            textureDeform.GetData(pixelDeformData, 0, textureDeform.Width * textureDeform.Height);
        }

<<<<<<< HEAD
        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, mousePos, Color.Transparent);
        }

=======
>>>>>>> bd93401c08294f20225b188b8dd87fcf1e71f6be
        public Texture2D DeformLevel(Vector2 mousePos)
        {
            // Declare an array to hold the pixel data 
            uint[] pixelLevelData = new uint[textureLevel.Width * textureLevel.Height];
            // Populate the array 
            textureLevel.GetData(pixelLevelData, 0, textureLevel.Width * textureLevel.Height);

            for (int x = 0; x < textureDeform.Width; x++)
            {
                for (int y = 0; y < textureDeform.Height; y++)
                {
                    // Do some error checking so we dont draw out of bounds of the array etc.. 
                    if (((mousePos.X + x) < (textureLevel.Width)) &&
                     ((mousePos.Y + y) < (textureLevel.Height)))
                    {
                        if ((mousePos.X + x) >= 0 && (mousePos.Y + y) >= 0)
                        {
                            // Here we check that the current co-ordinate of the deform texture is not an alpha value 
                            // And that the current level texture co-ordinate is not an alpha value 
                            if (pixelDeformData[x + y * textureDeform.Width] == 4294967295)
                            {
                                pixelLevelData[((int)mousePos.X + x) + ((int)mousePos.Y + y)
                                    * textureLevel.Width] = 0;
                            }
                        }
                    }
                }
            }

            textureLevel.SetData(pixelLevelData);
            return textureLevel;
        }

    }
}
