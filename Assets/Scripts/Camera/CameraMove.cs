using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Camera camera;
    float transX;
    float transZ;
    float distance;
    public CinemachineVirtualCameraBase cinemachine;
    public CinemachineVirtualCameraBase checkCam;
    public CinemachineConfiner confiner;
    Vector3 prevPos;

    private void Start()
    {
        camera = GetComponent<Camera>();
        prevPos = transform.position;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if (confiner.CameraWasDisplaced(cinemachine))
            {
                transform.position = prevPos;
            }
        }
        if (Input.GetMouseButton(1)) 
        {
            transX = Input.GetAxis("Mouse X") * -20 * Time.deltaTime;
            transZ = Input.GetAxis("Mouse Y") * -20 * Time.deltaTime;

            var f = Vector3.Cross(transform.right, Vector3.up).normalized;
            transform.position += f * transZ;
            transform.position += transform.right * transX;
              if(!confiner.CameraWasDisplaced(cinemachine))
            {
                prevPos = transform.position;
            }
           






            //     transform.position += transform.right * transX;


        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            var nextPos = transform.position + transform.forward * Input.GetAxis("Mouse ScrollWheel") * 20;
            
            
            if (nextPos.y > 10 && nextPos.y < 25)
            {
                 transform.position += transform.forward * Input.GetAxis("Mouse ScrollWheel") * 20;
            }
        }

        if (Input.touchCount == 1)
        {
            transX = Input.touches[0].deltaPosition.x * -speed * Time.deltaTime;
            transZ = Input.touches[0].deltaPosition.y * -speed * Time.deltaTime;

            var f = Vector3.Cross(transform.right, Vector3.up).normalized;
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                transform.position += f * transZ;
                transform.position += transform.right * transX;
            }
        }
        if (Input.touchCount > 1)
        {
            zoom();
        }
    }

    private void zoom()
    {
        Vector2 finger1 = Input.GetTouch(0).position;
        Vector2 finger2 = Input.GetTouch(1).position;

        if (distance == 0) distance = Vector2.Distance(finger1, finger2);

        float delta = Vector2.Distance(finger1, finger2) - distance;
        var nextPos = transform.position + transform.forward * delta * Time.deltaTime;
        if (Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved)
        {
            if (nextPos.y > 10 && nextPos.y < 25)
            {
                transform.position += transform.forward * delta * Time.deltaTime;
            }
        }
        distance = Vector2.Distance(finger1, finger2);
    }
}
