using System;
using System.IO;
using UnityEngine;

namespace BetterMediaControls.audio
{
    public static class AudioLoader
    {
        public static AudioClip LoadAudio(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);

            int channels = BitConverter.ToInt16(bytes, 22);
            int sampleRate = BitConverter.ToInt32(bytes, 24);
            int dataIndex = 44;
            int sampleCount = (bytes.Length - dataIndex) / 2;

            float[] samples = new float[sampleCount];

            int offset = 0;
            for (int i = dataIndex; i < bytes.Length; i += 2)
            {
                short sample = BitConverter.ToInt16(bytes, i);
                samples[offset++] = sample / 32768f;
            }

            var clip = AudioClip.Create(
                Path.GetFileNameWithoutExtension(path),
                sampleCount / channels,
                channels,
                sampleRate,
                false
            );

            clip.SetData(samples, 0);
            return clip;
        }
    }
}