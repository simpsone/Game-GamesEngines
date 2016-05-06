using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Levelchange : MonoBehaviour
{

    public GameObject EnemyObject;
    public float trigger = 5.0f;
    private float distToEnemy;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distToEnemy = Vector3.Distance(transform.position, EnemyObject.transform.position);
        Debug.Log(distToEnemy);

        if (distToEnemy < trigger)
        {
            SceneManager.LoadScene(2);
        }
    }
}

