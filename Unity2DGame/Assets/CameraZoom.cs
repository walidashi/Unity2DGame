using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    private Camera cam;
    public float Targetzoom = 3;
    private float ScrollData;
    private float ZoomSpeed = 3;

    void Start()
    {
        cam = GetComponent<Camera>();
        Targetzoom = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        ScrollData = Input.GetAxis("Mouse ScrollWheel");
        Targetzoom = Targetzoom - ScrollData;
        Targetzoom = Mathf.Clamp(Targetzoom, 3, 6);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, Targetzoom, Time.deltaTime * ZoomSpeed);
    }
}
