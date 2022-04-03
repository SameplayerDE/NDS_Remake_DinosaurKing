using HxTiled.Tiled;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NDS_Remake_DinosaurKing.Graphics
{
    public static class TileMapRenderer
    {
        private static double _animationTimer;

        public static void UpdateAnimationTimer()
        {
            _animationTimer += HxTime.DeltaF * 1000f;
        }

        public static void Draw(this TileMap tileMap, SpriteBatch spriteBatch, GameTime gameTime, Vector2 offset)
        {
            foreach (var tileMapTileLayer in tileMap.TileLayers)
            {
                if (!tileMapTileLayer.Visible) continue;

                var tileSize = new Vector2(tileMap.TileWidth, tileMap.TileHeight);

                for (var y = 0; y < tileMapTileLayer.Height; y++)
                {
                    for (var x = 0; x < tileMapTileLayer.Width; x++)
                    {
                        var index = tileMapTileLayer.Data[x + tileMapTileLayer.Width * y];
                        
                        var tileSet = tileMap.GetTileSetByTileIndex(index);
                        if (tileSet == null) continue;
                        var tileArea = tileSet.GetTileSection(index);

                        var animations = tileSet.GetTileAnimationFile(index);

                        var gridPosition = new Vector2(x, y);
                        var worldPosition = gridPosition * tileSize;

                        if (animations != null)
                        {
                            var animationIndex = 0;
                            animationIndex = (int)_animationTimer / animations[animationIndex].Duration % animations.Count;
                            tileArea = tileSet.GetTileSection(animations[animationIndex].TileId);
                            spriteBatch.Draw(
                                tileSet.Texture2D,
                                worldPosition,
                                tileArea,
                                Color.White * tileMapTileLayer.Opacity
                            );
                        }
                        else
                        {
                            spriteBatch.Draw(
                                tileSet.Texture2D,
                                worldPosition,
                                tileArea,
                                Color.White * tileMapTileLayer.Opacity
                            );
                        }
                    }
                }
            }
        }
    }
}