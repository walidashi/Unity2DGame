using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform Target;
    public float CameraSpeed;

    public float minX, minY;
    public float maxX,maxY;

    void FixedUpdate(){
        if(Target != null){
            Vector2 newcamPosition = Vector2.Lerp(transform.position, Target.position, Time.deltaTime * CameraSpeed);
            float ClampX = Mathf.Clamp(newcamPosition.x, minX, maxX);
            float ClampY = Mathf.Clamp(newcamPosition.y, minY, maxY);
            transform.position = new Vector3(ClampX, ClampY, -10f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
