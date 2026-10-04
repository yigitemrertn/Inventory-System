using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    PlayerStat stats;
    Vector2 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStat>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = stats.GetStat("moveSpeed") * direction;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        //Debug.Log($"{direction.x}, {direction.y}");
    }
}
