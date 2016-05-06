using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour
{
    public Camera[] cameras;
    
    void Start()
    {

    }
    void Update()
    {
        if (Time.time > 2)
        {
            switchCameras(1);

            if (Time.time > 4)
            {
                switchCameras(2);

                if (Time.time > 8)
                {
                    switchCameras(3);

                    if (Time.time > 12)
                    {
                        switchCameras(4);

                        if (Time.time > 15)
                        {
                            switchCameras(5);
                            if (Time.time > 24)
                            {
                                switchCameras(3);
                                if (Time.time > 31)
                                {
                                    switchCameras(0);
                                }
                                if (Time.time > 40)
                                {
                                    switchCameras(5);
                                }
                            }

                        }
                    }
                }
            }

        }
        else
        {
            switchCameras(0);
        }
    }

    private void switchCameras(int keyNum)
    {
        for (int i = 0; i < cameras.Length - 1; i++)
        {
            if (cameras[i] != null && keyNum != i)
            {
                // turn camera off
                cameras[i].GetComponent<Camera>().enabled = false;
            }
            else {
                // turn camera on
                cameras[i].GetComponent<Camera>().enabled = true;
            }
        }
    }

}
