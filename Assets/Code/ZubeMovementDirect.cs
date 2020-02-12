using UnityEngine;

public class ZubeMovementDirect : MonoBehaviour
{
    private const float SPEED = 15f;

    private Rigidbody2D _rb;
    private void Awake () {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update () {
        var xdelta = (Input.GetKey(KeyCode.A) ? -1f : 0f) + (Input.GetKey(KeyCode.D) ? 1f : 0f);
        var movement = new Vector2(xdelta, 0f) * Time.deltaTime * SPEED;
        _rb.position += movement;
    }
}
