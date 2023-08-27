using UnityEngine;

public class SimpleEnemy : Enemy
{
    [SerializeField] private Transform _obstacleCheck;
    [SerializeField] private Transform _edgeCheck;
    [SerializeField] private LayerMask _obstacleMask;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _checkDistance;
    private bool _isFacingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(moveSpeed * Vector3.right * Time.fixedDeltaTime);

        if (IsObstacle() || 
            IsEdge())
        {
            Flip();
        }
    }

    private void Flip()
    {
        if (_isFacingRight)
        {
            transform.eulerAngles = new Vector3(0, -180f, 0f);
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        _isFacingRight = !_isFacingRight;
    }

    private bool IsObstacle()
    {
        return Physics2D.Raycast(_obstacleCheck.position, Vector3.right, _checkDistance, _obstacleMask);
    }

    private bool IsEdge()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(_edgeCheck.position, Vector3.down, _checkDistance, _groundMask);
        return groundInfo.collider == false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(_obstacleCheck.position, Vector3.right);
        Gizmos.DrawRay(_edgeCheck.position, Vector3.down);
    }
}
