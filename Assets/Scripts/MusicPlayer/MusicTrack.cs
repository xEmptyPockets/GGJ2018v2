using UnityEngine;
using System.Collections;

/*
    HOW TO DEFINE NEW LOOP ALGORITHMS:
    1. Create a new class that inherits from MusicTrack.
    2. Override GetNextClip() with appropriate algorithm.
    3. See MusicPlayerPlus comments for how to use the new class.

    See MusicTrackLoopAllButFirst.cs and MusicTrackLoopLastClip.cs for examples
 */

public class MusicTrack : MonoBehaviour {

    protected MusicClip[] clips; 

    protected int currentClip = 0;
    protected bool started = false;

    // Use this for initialization
    void Start () {
        started = false;
        clips = GetComponentsInChildren<MusicClip>();
    }

    public virtual MusicClip GetNextClip() {
        if (!started) {    
            currentClip = 0;
            started = true;
        } else if (clips.Length > 1) {
            currentClip = (currentClip  + 1) % (clips.Length - 1); // loop through all clips
        }

        Debug.Log("queued clip at index " + currentClip);
        return clips[currentClip];
    }

    public void ResetLoopState() {
        started = false;
    }
}


