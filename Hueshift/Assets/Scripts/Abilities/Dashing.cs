using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : Ability
{
    [Header("References")]
    public Transform orientation;
    public Transform playerCam;
    public Rigidbody rb;
    public PlayerMovement pm;

    [Header("Dashing")]
    public float dashForce;
    public float dashUpwardForce;
    public float dashDuration;

    [Header("Settings")]
    public bool disableGravity = true;

    [Header("Cooldown")]
    public float dashCooldown;
    private float dashCooldownTimer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dashCooldownTimer > 0 )
            dashCooldownTimer -= Time.deltaTime;
    }

    public override void useAbility()
    {
        base.useAbility();

        Dash();
    }

    private void Dash()
    {
        if (dashCooldownTimer > 0) return;
        else dashCooldownTimer = dashCooldown;

        pm.dashing = true;

        Vector3 forcetoapply = orientation.forward * dashForce + orientation.up * dashUpwardForce;

        if (disableGravity)
            rb.useGravity = false;


        delayedForceToApply = forcetoapply;
        Invoke(nameof(DelayedDashForce), 0.025f);
        rb.AddForce(forcetoapply, ForceMode.Impulse);

        Invoke(nameof(ResetDash), dashDuration);
    }

    private Vector3 delayedForceToApply;
    private void DelayedDashForce()
    {
        rb.AddForce(delayedForceToApply, ForceMode.Impulse);
    }

    private void ResetDash()
    {
        pm.dashing = false;

        if (disableGravity)
            rb.useGravity = true;
    }
}
