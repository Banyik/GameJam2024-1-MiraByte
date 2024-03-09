using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSoundHandler : MonoBehaviour
{
    public List<AudioClip> tileClip = new List<AudioClip>();
    public List<AudioClip> woodClip = new List<AudioClip>();
    public List<AudioClip> RugClip = new List<AudioClip>();
    public List<AudioClip> GrassClip = new List<AudioClip>();
    public List<AudioClip> VentClip = new List<AudioClip>();
    public List<AudioClip> GetClips(WalkSoundTypes type)
    {
        switch (type)
        {
            case WalkSoundTypes.Tile:
                return tileClip;
            case WalkSoundTypes.WoodenFloor:
                return woodClip;
            case WalkSoundTypes.Rug:
                return RugClip;
            case WalkSoundTypes.Grass:
                return GrassClip;
            case WalkSoundTypes.Vent:
                return VentClip;
            default:
                return null;
        }
    }
}
