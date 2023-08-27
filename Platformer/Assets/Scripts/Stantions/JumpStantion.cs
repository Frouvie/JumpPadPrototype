using System.Collections;
using UnityEngine;

public class JumpStantion : MonoBehaviour
{
    [SerializeField] private float _impulseForce;
    [SerializeField] private float _impulseCooldown;
    private bool _isActivated = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (_isActivated) return;

        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

        if (rb == null) return;

        _isActivated = true;
        StartCoroutine(GetImpulse(rb));
    }

    private IEnumerator GetImpulse(Rigidbody2D rb)
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        rb.AddForce(Vector3.up * _impulseForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(_impulseCooldown);
        _isActivated = false;
    }
}