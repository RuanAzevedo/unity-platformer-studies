using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");

        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(horizontal * 10, rb.velocity.y);

    }
}
