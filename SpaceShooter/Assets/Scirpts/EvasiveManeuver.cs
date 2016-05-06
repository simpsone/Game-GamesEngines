using UnityEngine;
using System.Collections;

public class EvasiveManeuver : MonoBehaviour {

    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public Vector2 startWait;
    public float dodge;
    public float smoothing;
    public float tilt;
    public Boundary boundary;
    private Transform playerTransform;

    private float currentSpeed;
    private float targetManeuver;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        playerTransform = GameObject.FindWithTag ("Player").transform;
        currentSpeed = rb.velocity.z;
        StartCoroutine(Evade());
	}
	
    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while(true)
        {
            if (playerTransform != null)
            {
                targetManeuver = Random.Range(1, dodge) * -Mathf.Sign (transform.position.x); // Negative is positive and positive is negative. Opposite sign value to position x. Keeps spaceship inside screen
                targetManeuver = playerTransform.position.x;
                yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
                targetManeuver = 0;
                yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
            }
        }
    }
	// Update is called once per frame
	void FixedUpdate () {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
        rb.position = new Vector3
            (
               Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
               0.0f,
               Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            ); // Ensures the enemy ship cannot leave the bounds of the game

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

    }
}
