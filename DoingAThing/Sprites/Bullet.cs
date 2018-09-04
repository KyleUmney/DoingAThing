using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoingAThing.Sprites
{
  public class Bullet : Sprite
  {
    private float _timer;

    public float LifeSpan { get; set; }

    public Vector2 Velocity { get; set; }
    
    public Bullet(Texture2D texture) 
      : base(texture)
    {
    }

    public override void Update(GameTime gameTime)
    {
      _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

      if (_timer >= LifeSpan)
        IsRemoved = true;

      Position += Velocity;

      base.Update(gameTime);
    }
  }
}
