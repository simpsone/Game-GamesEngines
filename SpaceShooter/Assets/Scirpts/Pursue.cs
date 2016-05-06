
using UnityEngine;
using System.Collections.Generic;

public class Pursue : MonoBehaviour
{

    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 force;
    public float mass = 1.0f;
    public float maxSpeed = 10.0f;
    public float maxForce = 10.0f;

    [Header("Arrive")]
    public bool arriveEnabled;
    public Vector3 arriveTargetPosition;
    public float slowingDistance = 15;



    [Header("Offset Pursue")]
    public bool offsetPursueEnabled = false;
    public GameObject offsetPursueTarget = null;
    Vector3 offset;
    Vector3 offsetPursueTargetPos;


    void Start()
    {
        if (offsetPursueEnabled)
        {
            offset = transform.position - offsetPursueTarget.transform.position;
            offset = Quaternion.Inverse(offsetPursueTarget.transform.rotation) * offset;
        }
    }

        void Update()
    {
            force = Vector3.zero;

            if (arriveEnabled)
            {
                force += Arrive(arriveTargetPosition);
            }

            if (offsetPursueEnabled)
            {
                force += OffsetPursue(offsetPursueTarget, offset);
            }
        }

    public Vector3 OffsetPursue(GameObject leader, Vector3 offset)
    {
        Vector3 target = leader.transform.TransformPoint(offset);
        Vector3 toTarget = transform.position - target;
        float dist = toTarget.magnitude;
        float lookAhead = dist / maxSpeed;

        offsetPursueTargetPos = target + (lookAhead * leader.GetComponent<Pursue>().velocity);
        return Arrive(offsetPursueTargetPos);
    }

    public Vector3 Arrive(Vector3 targetPos)
    {
        Vector3 toTarget = targetPos - transform.position;

        float slowingDistance = 15.0f;
        float distance = toTarget.magnitude;
        if (distance < 0.5f)
        {
            velocity = Vector3.zero;
            return Vector3.zero;
        }
        float ramped = maxSpeed * (distance / slowingDistance);

        float clamped = Mathf.Min(ramped, maxSpeed);
        Vector3 desired = clamped * (toTarget / distance);

        return desired - velocity;
    }
}
