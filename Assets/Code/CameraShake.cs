using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private const float DURATION = 0.25f, SCALE = 2f;
    private float _timeLeft = DURATION;
    private void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) { StartCoroutine(Shake()); }
    }

    private IEnumerator Shake () {
        _timeLeft = DURATION;
        while ((_timeLeft -= Time.deltaTime) > 0f) {
            transform.position += RandomOffset();
            yield return null;
        }
    }

    private static Vector3 RandomOffset (float scale = SCALE) {
        var x = Random.Range(0.2f, 1.0f);
        var y = Random.Range(0.2f, 1.0f);
        var sign = Random.Range(0, 2) * -2 + 1;
        return new Vector3(x, y) * sign * scale;
    }
}
