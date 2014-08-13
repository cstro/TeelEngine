using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NUnit.Framework;
using TeelEngine.Level;

namespace TeelEngine
{
    public class GameRenderer
    {
        public Dictionary<string, Texture2D> SpriteSheets = new Dictionary<string, Texture2D>();
        public int TileSize { get; set; }

        public GameRenderer(List<Texture2D> spriteSheets, int tileSize)
        {
            SpriteSheets = spriteSheets;
            TileSize = tileSize;
        }


        public void Render(Level.Level level, SpriteBatch spriteBatch)
        {
            foreach (var gameTile in level.GameTiles)
            {
                if (gameTile == null)
                {
                    continue;
                }

                foreach (var subTile in gameTile.SubTiles)
                {
                    if (Camera.IsWithinLens(TileSize, gameTile.Location))
                    {
                        if (subTile is IRenderable)
                        {
                            var tile = subTile as IRenderable;
                            int id = tile.TextureId;
                            Texture2D spriteSheet = SpriteSheets[tile.AssetName];

                            int spriteSheetTileWidth = spriteSheet.Width / TileSize;
                            int spriteSheetTileHeight = spriteSheet.Height / TileSize;

                            int yPixelPos = (id/spriteSheetTileWidth)*TileSize;
                            int xPixelPos = (id - (yPixelPos*spriteSheetTileHeight))*TileSize;

                            
                            var sourceRectangle = new Rectangle(xPixelPos, yPixelPos, TileSize, TileSize);
                            var destRectangle = new Rectangle(gameTile.Location.X*TileSize, gameTile.Location.Y*TileSize,
                                TileSize, TileSize);

                            spriteBatch.Draw(spriteSheet, destRectangle, sourceRectangle, Color.White);

                        }
                    }
                }
            }
        }
    }
}