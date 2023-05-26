using UnityEngine;

public class Player : MonoBehaviour
{
    private float _jumpEndTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var rb = GetComponent<Rigidbody2D>();
        var vertical = rb.velocity.y;

        if (Input.GetButtonDown("Fire1"))
            _jumpEndTime = Time.time + 0.5f;

        if (Input.GetButton("Fire1") && _jumpEndTime > Time.time)
            vertical = 5;

        rb.velocity = new Vector2(horizontal * 10, vertical);

    }
}
