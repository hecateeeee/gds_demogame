using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject CameraTrack;
    public GameObject PBackground, P1, P2, PForegound;

    private void FixedUpdate () {
        var offset = CameraTrack.transform.position.x;
        MoveGO(PForegound, offset, 0.80f);
        MoveGO(P2, offset, 0.90f);
        MoveGO(P1, offset, 0.95f);
        MoveGO(PBackground, offset, 0.99f);
    }

    private void MoveGO (GameObject go, float xoffset, float scale) {
        var pos = go.transform.position;
        pos.x = xoffset * scale;
        go.transform.position = pos;
    }
}
