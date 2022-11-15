using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasDash : MonoBehaviour
{
    private Rigidbody2D rb;

    [HideInInspector] public bool IsDashing;
    [HideInInspector] public bool CanDash;

    [Header("Dash Settings")]
    [SerializeField] private float dashStrength = 10f;
    [SerializeField] private float dashDuration = 0.1f;
    [SerializeField] private float dashCooldown = 0.5f;  // Brief Pause before Dashing Again

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        CanDash = true;
    }

    public void StartDash(Vector2 dashDirection)
    {
        StartCoroutine(Dash(dashDirection));
    }

    // TODO: Currently Dash only works in left and right
    private IEnumerator Dash(Vector2 dashDirection)
    {
        Debug.Log("Dash");

        IsDashing = true;
        CanDash = false;
        rb.velocity = dashDirection * dashStrength;
        yield return new WaitForSeconds(dashDuration);
        IsDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        CanDash = true;
    }
}
