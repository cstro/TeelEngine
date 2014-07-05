using Microsoft.Xna.Framework.Graphics;

namespace TeelEngine
{
    public interface IRender
    {
        int Priority { get; }
        void Render(SpriteBatch spriteBatch);
        void Render(SpriteBatch spriteBatch, Camera camera);
    }
}