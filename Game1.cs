using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Devcade_Library.DevcadeControls;
using System.Collections.Generic;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Button topMenuButton;
    private Button bottomMenuButton;
    private Dictionary<PlayerIndex, Controller> controllers;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        #region ControllerSetup

        topMenuButton = new Button(Buttons.Start);
        bottomMenuButton = new Button(Buttons.Start);
        controllers = new Dictionary<PlayerIndex, Controller>()
        {
            {
                PlayerIndex.One,
                new Controller(PlayerIndex.One)
            },
            {
                PlayerIndex.Two,
                new Controller(PlayerIndex.Two)
            }
        };

        #endregion

        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        #region ControllerUpdate

        topMenuButton.Update(GamePad.GetState(PlayerIndex.One));
        bottomMenuButton.Update(GamePad.GetState(PlayerIndex.Two));
        foreach (Controller controller in controllers.Values)
        {
            controller.Update();
        }

        #endregion

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}