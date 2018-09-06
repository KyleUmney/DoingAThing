using Backend.Models;
using DoingAThing.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoingAThing.States
{
  class GameState : State
  {
    public List<Sprite> _sprites;
    public GameState(Game game, ContentManager content)
      : base(game, content)
    {
    }
    public override void LoadContent()
    {
      var playerTexure = _content.Load<Texture2D>("Sprites/Player");
      var bulletTexture = _content.Load<Texture2D>("Sprites/Bullet");
      var weaponTexture = _content.Load<Texture2D>("Sprites/Weapon");
      var enemyTexute = _content.Load<Texture2D>("Sprites/LittleBug");

      _sprites = new List<Sprite>();

      _sprites.Add(new Player(playerTexure)
      {
        Colour = Color.White,
        Position = new Vector2(Game1.screenWidth / 2, Game1.screenHeight - playerTexure.Height),

        Layer = 0.0f,
        Scale = 1f,
      });

      //_sprites.Add(new PlayerWeapon(weaponTexture)
      //{
      //  Colour = Color.White,
      //  Position = new Vector2(_sprites[0].Position.X, _sprites[0].Position.Y),
      //  Bullet = new Bullet(bulletTexture),
      //  Layer = 0.0f,
      //  Scale = 0.5f,
      //});

      _sprites.Add(new LittleBugs(enemyTexute)
      {
        Colour = Color.White,
        Position = new Vector2(Game1.screenWidth / 2, Game1.screenHeight / 2),
        Layer = 0.0f,
        Scale = 0.8f,
      });
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      spriteBatch.Begin(SpriteSortMode.FrontToBack);

      foreach (var sprite in _sprites)
        sprite.Draw(gameTime, spriteBatch);

      spriteBatch.End();
    }

    public override void PostUpdate(GameTime gameTime)
    {
      int spriteCount = _sprites.Count;
      for (int i = 0; i < spriteCount; i++)
      {
        var sprite = _sprites[i];
        foreach (var child in sprite.Children)
        {
          _sprites.Add(child);
        }
        sprite.Children = new List<Sprite>();
      }
      for (int i = 0; i < _sprites.Count; i++)
      {
        if (_sprites[i].IsRemoved)
        {
          _sprites.RemoveAt(i);
          i--;
        }
      }
    }

    public override void Update(GameTime gameTime)
    {
      foreach (var sprite in _sprites)
        sprite.Update(gameTime);

      //_sprites[1].Position.X = _sprites[0].Position.X + 34;
      //_sprites[1].Position.Y = _sprites[0].Position.Y + 18;
    }
  }
}
