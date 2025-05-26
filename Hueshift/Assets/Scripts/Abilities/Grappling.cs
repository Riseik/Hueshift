using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Grappling : Ability
{
    public float grapplingForce;

    public override void useAbility(Rigidbody rb, Transform orientation)
    {
        base.useAbility(rb, orientation);

        rb.AddForce(transform.up * grapplingForce, ForceMode.Impulse);
    }
}
