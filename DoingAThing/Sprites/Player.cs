using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace DoingAThing.Sprites
{
  class Player : Sprite
  {
    private Vector2 velocity;

    public Player(Texture2D texture) : base(texture)
    {
    }

    public override void Update(GameTime gameTime)
    {
      float Speed = 8f;

      float time = (float)gameTime.ElapsedGameTime.TotalSeconds;

      velocity.Y += 0.2f;

      var onGround = Position.Y >= 720 - _texture.Height; // TODO: Make it right

      if (onGround)
        velocity.Y = 0f;

      if (Keyboard.GetState().IsKeyDown(Keys.Up) && onGround)
      {
        velocity.Y = -10f;
      }

      if (Keyboard.GetState().IsKeyDown(Keys.Right))
        velocity.X = Speed;
      else if (Keyboard.GetState().IsKeyDown(Keys.Left))
        velocity.X = -Speed;
      else
        velocity.X = 0;


      velocity = Vector2.Clamp(velocity, new Vector2(-10, -10), new Vector2(10, 10));

      Position += velocity;// * time;
      //Position = Vector2.Clamp(Position, new Vector2(0 + _texture.Width, 0 + _texture.Height), new Vector2(1280 - _texture.Width, 720 - _texture.Height));

    
      base.Update(gameTime);

    }



  }
}
