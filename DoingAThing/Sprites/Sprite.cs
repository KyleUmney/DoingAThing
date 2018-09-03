using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoingAThing.Sprites
{
  public abstract class Sprite : Component, ICloneable
  {
    protected Texture2D _texture;
    protected float _rotation;
    public Vector2 Position;
    public float Scale { get; set; }
    public Color Colour { get; set; }
    public float Layer { get; set; }
    public List<Sprite> Children { get; set; }
    public Sprite Parent;
    public List<Sprite> Sprites { get; set; }
    public Vector2 Origin
    {
      get
      {
        return new Vector2(_texture.Width / 2, _texture.Height / 2);
      }
    }
    public Sprite(Texture2D texture)
    {
      _texture = texture;

      Children = new List<Sprite>();

      Colour = Color.White;

      Scale = 1f;
    }
    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      spriteBatch.Draw(_texture, Position, null, Colour, _rotation, Origin, Scale, SpriteEffects.None, Layer);
    }
    public object Clone()
    {
      throw new NotImplementedException();
    }
  }
}
