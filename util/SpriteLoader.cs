using System.IO;
using UnityEngine;

namespace BetterMediaControls.util
{
    public static class SpriteLoader
    {
        public static Sprite LoadSprite(string path)
        {
            if (!File.Exists(path))
            {
                Plugin.Log.LogWarning($"Sprite not found: {path}");
                return null;
            }

            byte[] data = File.ReadAllBytes(path);

            var texture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
            if (!texture.LoadImage(data))
            {
                Plugin.Log.LogError($"Failed to load image: {path}");
                return null;
            }

            texture.filterMode = FilterMode.Bilinear;
            texture.wrapMode = TextureWrapMode.Clamp;

            return Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f),
                100f
            );
        }
    }
}