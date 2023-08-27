using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCharacterController : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float _walkSpeed;
    private bool _isFacingRight = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");

        _rb.velocity = new Vector3(horizontalMove * _walkSpeed, _rb.velocity.y);
        
        if (_isFacingRight && horizontalMove < 0 ||
            !_isFacingRight && horizontalMove > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }
}
