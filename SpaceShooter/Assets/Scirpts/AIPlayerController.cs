﻿using UnityEngine;
using System.Collections.Generic;

public class AIPlayerController : MonoBehaviour
{

    public Transform target;
    public float moveSpeed;
    public float rotationSpeed;

    void Start()
    {
        target = GameObject.Find("Enemy").transform;
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            // Only needed if objects don't share 'z' value.
            dir.z = 0.0f;
            if (dir != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.FromToRotation(Vector3.right, dir),
                    rotationSpeed * Time.deltaTime);

            //Move Towards Target
            transform.position += (target.position - transform.position).normalized
                * moveSpeed * Time.deltaTime;
        }
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}

