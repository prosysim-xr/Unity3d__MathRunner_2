using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] Transform target;
    [Range(0.1f, 100f)]
    [SerializeField] float smoothFactor; //set some value of smoothspeed preferablly between 0 to 1 and if time delta used then set to 10
    [SerializeField] Vector3 offset;

    //private void LateUpdate() //instead of late use fixed it just works
    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothFactor * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target);

    }
}

