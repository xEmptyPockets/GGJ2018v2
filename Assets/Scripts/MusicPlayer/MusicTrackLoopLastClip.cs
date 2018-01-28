using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrackLoopLastClip : MusicTrack {

    public override MusicClip GetNextClip() {
        if (!started) {    
            currentClip = 0;
            started = true;
        } else if (clips.Length > 1) {
            // if the current clip is not the last clip, increment currentClip
            // (aka loop only the last clip)
            if (currentClip < clips.Length - 1) {
                ++currentClip;
            }
        }

        Debug.Log("queued clip at index " + currentClip);
        return clips[currentClip];
    }
}

