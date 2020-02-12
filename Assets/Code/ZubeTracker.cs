using UnityEngine;

public class ZubeTracker : MonoBehaviour
{
    public Rigidbody2D ZubeToTrack;
    private void FixedUpdate () {
        var zubepos = ZubeToTrack.position;
        var delta = zubepos - (Vector2)transform.position;
        var scaled = (Vector3)delta * 0.2f;
        transform.position += scaled;
    }
}
