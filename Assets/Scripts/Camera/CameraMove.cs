using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Camera camera;
    float transX;
    float transZ;
    private void Start()
    {
        camera = GetComponent<Camera>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
             transX = Input.GetAxis("Mouse X") * -speed * Time.deltaTime;
             transZ = Input.GetAxis("Mouse Y") * -speed * Time.deltaTime;

            var f = Vector3.Cross(transform.right, Vector3.up).normalized;
            transform.position += f * transZ;
            transform.position += transform.right * transX;
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            transform.position += transform.forward * Input.GetAxis("Mouse ScrollWheel") * speed;
        }
    }
}
