using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoingAThing.Sprites
{
  public class PlayerWeapon : Sprite
  {
    private Player p;

    public PlayerWeapon(Texture2D texture) 
      : base(texture)
    {
    }
    public override void Update(GameTime gameTime)
    {
      var mouseState = Mouse.GetState();

      var x = mouseState.X - this.Position.X;
      var y = mouseState.Y - this.Position.Y;

      _rotation = (float)Math.Atan2(y, x);

      if (mouseState.LeftButton == ButtonState.Pressed)
        Shooting(5f);

      base.Update(gameTime);
    }

    private void Shooting(float speed)
    {
      var bullet = Bullet.Clone() as Bullet;
      bullet.Position = this.Position;
      bullet.Colour = this.Colour;
      bullet.Layer = 0.0f;
      bullet.LifeSpan = 5f;
      bullet.Velocity = new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation )) * speed;
      bullet.Parent = this;

      Children.Add(bullet);
    }
  }
}
