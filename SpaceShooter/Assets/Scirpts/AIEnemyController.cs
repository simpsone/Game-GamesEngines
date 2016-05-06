
using UnityEngine;
using System.Collections;

public class AIEnemyController : MonoBehaviour
{

    public Path path;
    public float reachDistance = 1f;
    public float speed = 5f;
    public float rotSpeed = 50f;
    private int currentNodeID = 0;

    void Start()
    {

    }

    void Update()
    {
        Vector3 dest = path.GetNodePos(currentNodeID);
        Vector3 offset = dest - transform.position;
        if (offset.sqrMagnitude > reachDistance)
        {
            offset = offset.normalized;
            transform.Translate(offset * speed * Time.deltaTime, Space.World);

            Quaternion lookRot = Quaternion.LookRotation(offset);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, rotSpeed * Time.deltaTime);
        }
        else {
            ChangeDestNode();
        }
    }

    void ChangeDestNode()
    {
        currentNodeID++;
        if (currentNodeID >= path.nodes.Length)
        {
            currentNodeID = 0;
        }
    }
}
