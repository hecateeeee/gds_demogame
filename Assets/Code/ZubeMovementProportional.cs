using UnityEngine;

public class ZubeMovementProportional : MonoBehaviour
{
    private const float PROPORTIONAL = 5f, SPEED = 15f;

    private Rigidbody2D _rb;
    private float _goalSpeed;

    private void Awake () {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update () {
        var xdelta = (Input.GetKey(KeyCode.A) ? -1f : 0f) + (Input.GetKey(KeyCode.D) ? 1f : 0f);
        _goalSpeed = xdelta * SPEED;
    }

    private void FixedUpdate () {
        _rb.AddForce(new Vector2((_goalSpeed - _rb.velocity.x) * PROPORTIONAL, 0f));
    }
}
