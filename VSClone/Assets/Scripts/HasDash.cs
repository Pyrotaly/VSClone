using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasDash : MonoBehaviour
{
    private Rigidbody2D rb;

    [HideInInspector] public bool IsDashing;
    [HideInInspector] public bool CanDash;

    [SerializeField] private TrailRenderer trailRenderer;

    [Header("Dash Settings")]
    [SerializeField] private float dashStrength = 10f;
    [SerializeField] private float dashDuration = 0.25f;
    [SerializeField] private float dashCooldown = 0.5f;  // Brief Pause before Dashing Again


    [Header("IFrame Settings")]
    [SerializeField] private int[] layerInts = new int[2];


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Start()
    {
        CanDash = true;
    }

    public void StartDash(Vector2 dashDirection)
    {
        StartCoroutine(Dash(dashDirection));
    }

    private IEnumerator Dash(Vector2 dashDirection)
    {
        Debug.Log("Dash");
        Physics2D.IgnoreLayerCollision(layerInts[0], layerInts[1], true);          //For Player Dash Component     3, 9, 11
        Physics2D.IgnoreLayerCollision(layerInts[0], layerInts[2], true);          //Boss3 Dash Component          9, 3, 8

        IsDashing = true;
        CanDash = false;
        trailRenderer.enabled = true;
        rb.velocity = dashDirection * dashStrength;
        yield return new WaitForSeconds(dashDuration);
        trailRenderer.enabled = false;
        IsDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        CanDash = true;

        Physics2D.IgnoreLayerCollision(layerInts[0], layerInts[1], false);          //For Player Dash Component
        Physics2D.IgnoreLayerCollision(layerInts[0], layerInts[2], false);
    }
}
