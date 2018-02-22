using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Gymnasiearbete
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D textureBackground;
        private Texture2D textureLevel;
        private Texture2D textureDeform;
        private Vector2 mousePos;
        private MouseState currentMouseState;
        private MouseState previousMouseState;
        private uint[] pixelDeformData;
        Player movingPlayer = new Player();
        Deform deformHandler;


        protected void UpdateMouse()
        {

            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            // This gets the mouse co-ordinates
            // relative to the upper left of the game window
            mousePos = new Vector2(currentMouseState.X - textureDeform.Width / 2, currentMouseState.Y - textureDeform.Height / 2);

            if (previousMouseState.LeftButton == ButtonState.Pressed && 
                currentMouseState.LeftButton == ButtonState.Pressed)
            {
                textureLevel = deformHandler.DeformLevel(mousePos);
            }
        }

        /*protected void DeformLevel()
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
        }*/

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            this.IsMouseVisible = true;

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            textureBackground = Content.Load<Texture2D>("snails.sea");
            textureLevel = Content.Load<Texture2D>("snails.level");
            textureDeform = Content.Load<Texture2D>("snails.deform");

            deformHandler = new Deform(textureLevel, textureDeform);

            /*
            movingPlayer.texture = Content.Load<Texture2D>("snails.movingSnail");
            movingPlayer.position = new Vector2(280, 160);
            movingPlayer.animationSpeed = 10;
            movingPlayer.frameHeight = movingTexture.Height;
            movingPlayer.movingPlayerFrames = 8;
            movingPlayer.frameWidth = movingTexture.Width / movingPlayer.movingPlayerFrames;
            */

            deformHandler = new Deform(textureLevel, textureDeform);
            pixelDeformData = new uint[textureDeform.Width * textureDeform.Height];
            textureDeform.GetData(pixelDeformData, 0, textureDeform.Width * textureDeform.Height);


            // TODO: use this.Content to load your game content here
        }
        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.IsMouseVisible = true;
            UpdateMouse();


            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(textureBackground, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(textureLevel, new Vector2(0, 0), Color.White);

            spriteBatch.Draw(textureDeform, mousePos, Color.Transparent);

            //spriteBatch.Draw(textureDeform, mousePos, Color.White);


            spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
