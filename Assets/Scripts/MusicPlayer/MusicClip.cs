using UnityEngine;
using System.Collections;

public class MusicClip : MonoBehaviour {
    public AudioClip Clip;
    public double LengthInSeconds 
    {
        get { return Clip.length;} 
    }
}
