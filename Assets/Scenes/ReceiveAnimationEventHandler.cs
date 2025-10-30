using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveAnimationEventHandler : MonoBehaviour
{
    public bool beAttack;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attacker")
        {
            beAttack = true;
        }
    }

    public void FootR(AnimationEvent evt)
    {
        Debug.Log("Animation Event" + evt.functionName);
    }

    public void FootL(AnimationEvent evt)
    {
        Debug.Log("Animation Event" + evt.functionName);
    }

    public void Hit(AnimationEvent evt)
    {
        Debug.Log("Animation Event" + evt.functionName);
    }
}