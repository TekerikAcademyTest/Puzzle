using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PuzzleGame
{
    class Puzzle : Microsoft.Xna.Framework.Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D ninjaImage;
        SpriteFont georgia;
        List<Shape> parts;
        TopBar topBar;
        MainArea mainArea;
        GameLogic puzzleLogic = new GameLogic();
        Texture2D pixel;
        bool hasTopSelected = false;
        bool hasMainSelected = false;
        MouseState mouse;
        Shape currentTopShape = null;
        Shape currentMainShape = null;

        public Puzzle()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            this.ninjaImage = Content.Load<Texture2D>("Ninja");
            this.georgia = Content.Load<SpriteFont>("Georgia");
            Cut cutImage = new Cut();
            parts = cutImage.Split(ninjaImage, 100, 100);
            mainArea = new MainArea(parts);
            parts.Shuffle();
            topBar = new TopBar(parts);
            this.puzzleLogic = new GameLogic();
            this.pixel = Content.Load<Texture2D>("Pixel");

        }

        protected override void UnloadContent()
        {
        
        }

        #region Update

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            // Update logic
            this.UpdateInternal();
            base.Update(gameTime);
        }

        private void UpdateInternal()
        {
            mouse = Mouse.GetState();
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                foreach (Shape shape in topBar.parts)
                {
                    if (shape.Visible)
                    {
                        if (mouse.X >= shape.TopLeft.XCoordinate && mouse.X <= (shape.TopLeft.XCoordinate + 60)
                            && mouse.Y >= shape.TopLeft.YCoordinate && mouse.Y <= (shape.TopLeft.YCoordinate + 60))
                        {
                            hasTopSelected = true;
                            currentTopShape = shape;
                            break;
                        }
                    }

                }
                if (!hasMainSelected)
                {
                    foreach (Shape shape in mainArea.parts)
                    {
                        if (!shape.Visible)
                        {
                            if (mouse.X >= shape.TopLeft.XCoordinate && mouse.X <= (shape.TopLeft.XCoordinate + 60)
                                && mouse.Y >= shape.TopLeft.YCoordinate && mouse.Y <= (shape.TopLeft.YCoordinate + 60))
                            {
                                hasMainSelected = true;
                                currentMainShape = shape;
                                break;
                            }
                        }
                    }
                }
            }

            if (hasMainSelected && hasTopSelected)
            {
                puzzleLogic.CheckPosition(currentTopShape, currentMainShape);
                // currentMainShape = null;
                currentTopShape = null;
                hasTopSelected = false;
                hasMainSelected = false;
                bool hasWon = true;
                foreach (Shape shape in mainArea.parts)
                {
                    if (!shape.Visible)
                    {
                        hasWon = false;
                    }
                }
                if (hasWon)
                {
                    puzzleLogic.State = GameState.Win;
                }
            }

            return;
        }

        private void DrawBorder(Shape shape)
        {
            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Opaque);
            spriteBatch.Draw(this.pixel, new Rectangle(shape.TopLeft.XCoordinate, shape.TopLeft.YCoordinate, 5, 60), null, Color.Green, 0, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.Draw(this.pixel, new Rectangle(shape.TopLeft.XCoordinate + 60, shape.TopLeft.YCoordinate, 5, 60), null, Color.Green, 0, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.Draw(this.pixel, new Rectangle(shape.TopLeft.XCoordinate, shape.TopLeft.YCoordinate, 60, 5), null, Color.Green, 0, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.Draw(this.pixel, new Rectangle(shape.TopLeft.XCoordinate, shape.TopLeft.YCoordinate + 60, 65, 5), null, Color.Green, 0, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.End();
        }

        #endregion

        #region Drawing

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGreen);
            if (puzzleLogic.State == GameState.InProgress)
            {
                DrawTitle();

                topBar.DrawField(spriteBatch);
                mainArea.DrawField(spriteBatch, this.pixel);
                if (hasTopSelected)
                {
                    DrawBorder(currentTopShape);

                }
                DrawImage();
            }
            else if (puzzleLogic.State == GameState.Lose)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(georgia, "You LOSE!", new Vector2(300, 0), Color.Blue);
                spriteBatch.End();
            }
            else if (puzzleLogic.State == GameState.Win) //state = win
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(georgia, "You WIN!", new Vector2(300, 0), Color.Blue);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }
        private void DrawTitle()
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(georgia, "You are playing mega hyper giga cool ninja puzzle", new Vector2(10, 0), Color.Blue);
            Point livesCoordinates = new Point(600, 0);
            spriteBatch.DrawString(georgia, "Your lives are: " + puzzleLogic.LivesCount, livesCoordinates.ConvertPointToVector(), Color.Blue);
            spriteBatch.End();
        }
        private void DrawImage()
        {

            spriteBatch.Begin();
            Vector2 imageCenter = new Vector2(470, 150);
            spriteBatch.Draw(ninjaImage, imageCenter, Color.White);
            spriteBatch.End();
        }

        #endregion
    }
}
