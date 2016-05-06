using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {
    public float scrollSpeed;//speed at which background moves
    public float tileSizeZ; //Length of tile

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ); // work out new position based on time * scroll speed and tile size
        transform.position = startPosition + Vector3.forward * newPosition; //set position
    }
}
