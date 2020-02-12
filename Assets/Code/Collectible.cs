using UnityEngine;

public class Collectible : MonoBehaviour
{
    private const float ROTATION_SPEED = 90f;
    private void Update () {
        var rot = transform.rotation.eulerAngles;
        var currz = transform.rotation.eulerAngles.z;
        currz += ROTATION_SPEED * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rot.x, rot.y, currz);
    }
}
