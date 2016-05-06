using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    
    private GameController gameController; // reference to game controller

    void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController"); // finds game object that hold game controller script
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;

        }
        if (other.tag == "Enemy")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
           // gameController.GameOver();

        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();

        }
       gameController.AddScore(scoreValue); // adds score value
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
