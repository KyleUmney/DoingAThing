using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoingAThing.Models
{
  class Animation : ICloneable
  {
    public readonly Texture2D Texture;

    public readonly int FrameCount;

    public int FrameHeight { get {return Texture.Height; } }

    public int FrameWidth { get { return Texture.Width / FrameCount; } }

    public float Speed { get; set; }

    public Animation(Texture2D  texture, int frameCount)
    {
      Texture = texture;

      FrameCount = frameCount;

      Speed = 0.2f;
    }

    public object Clone()
    {
      return this.MemberwiseClone();
    }
  }
}
