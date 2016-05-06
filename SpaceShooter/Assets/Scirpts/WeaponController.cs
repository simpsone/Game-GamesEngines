using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Fire", delay, fireRate); // Invokes a method over time and repeats
	}

    void Fire()
    { 
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }
	
}
