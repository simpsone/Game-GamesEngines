using UnityEngine;
using System.Collections;

public class AIDestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    void Start()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            return;
        }
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        Destroy(gameObject);
    }


}
