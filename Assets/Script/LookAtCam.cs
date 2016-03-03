using UnityEngine;
using System.Collections;

public class LookAtCam : MonoBehaviour {
    public Camera cam;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        lookAtCam();
	}

    void lookAtCam()
    {
        transform.LookAt(transform.position + cam.transform.rotation * Vector3.back, cam.transform.rotation * Vector3.down);
    }
}
