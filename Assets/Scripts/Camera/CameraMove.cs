using Cinemachine;
using UnityEngine;
public class CameraMove : MonoBehaviour
{
    [SerializeField] private float speed;
    float transX;
    float transZ;
    float distance;
    [SerializeField] private float minX,maxX;
    [SerializeField] private float minZ,maxZ;
    [SerializeField] private float ZoomMin,ZoomMax;
    CinemachineVirtualCamera cinemachine;
    public static bool CanMoveCamera = true;
    public bool isMobileInput;
    Vector3 startClickPosition;
    Vector3 startPos;
    [SerializeField] private GameObject AudioListener;
    public bool IsStoped = false;
    private void Start()
    {
        startPos = new Vector3(-22.4f, 28.9f, -22.4f);
       
        transform.position = startPos;
        cinemachine = GetComponentInChildren<CinemachineVirtualCamera>();
       
    }
    private void Update()
    {
        if (!IsStoped)
        {
            if (!isMobileInput)
            {
                if (Input.GetMouseButton(1))
                {
                    transX = Input.GetAxis("Mouse X") * -20 * Time.deltaTime;
                    transZ = Input.GetAxis("Mouse Y") * -20 * Time.deltaTime;

                    var f = Vector3.Cross(transform.right, Vector3.up).normalized;
                    transform.position += f * transZ;
                    transform.position += transform.right * transX;
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, Mathf.Clamp(transform.position.z, minZ, maxZ));
                }

                if (Input.GetAxis("Mouse ScrollWheel") != 0)
                {
                    var nextZoom = cinemachine.m_Lens.FieldOfView - Input.GetAxis("Mouse ScrollWheel") * 20;

                    if (nextZoom > ZoomMin && nextZoom < ZoomMax)
                    {
                        Vector3 posListener = AudioListener.transform.position;
                        AudioListener.transform.position = new Vector3(posListener.x, posListener.y - Input.GetAxis("Mouse ScrollWheel") * 20, posListener.z);
                        AudioListener.transform.position = new Vector3(
                            AudioListener.transform.position.x,
                            Mathf.Clamp(AudioListener.transform.position.y, 15f, 30f),
                            posListener.z);

                        cinemachine.m_Lens.FieldOfView -= Input.GetAxis("Mouse ScrollWheel") * 20;
                    }
                }

            }

            else if (isMobileInput)
            {

                if (CanMoveCamera)
                {
                    if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        startClickPosition = Input.GetTouch(0).position;
                    }
                    if (Input.touchCount == 1 && Vector3.Distance(startClickPosition, Input.GetTouch(0).position) > 0.5f)
                    {
                        transX = Input.touches[0].deltaPosition.x * -speed * Time.deltaTime;
                        transZ = Input.touches[0].deltaPosition.y * -speed * Time.deltaTime;
                        var f = Vector3.Cross(transform.right, Vector3.up).normalized;
                        if (Input.GetTouch(0).phase == TouchPhase.Moved)
                        {

                            transform.position += f * transZ;
                            transform.position += transform.right * transX;
                            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, Mathf.Clamp(transform.position.z, minZ, maxZ));

                        }
                    }
                    if (Input.touchCount > 1)
                    {
                        zoom();
                    }
                }
            }
        }
    }

    private void zoom()
    {
        Vector2 finger1 = Input.GetTouch(0).position;
        Vector2 finger2 = Input.GetTouch(1).position;

        if (distance == 0) distance = Vector2.Distance(finger1, finger2);

        float delta = Vector2.Distance(finger1, finger2) - distance;
        var nextZoom = cinemachine.m_Lens.FieldOfView * delta * Time.deltaTime;
        if (Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved)
        {
            Debug.Log("Touch 2");

            cinemachine.m_Lens.FieldOfView -= delta * 0.025f;
            cinemachine.m_Lens.FieldOfView = Mathf.Clamp(cinemachine.m_Lens.FieldOfView, ZoomMin, ZoomMax);
            Vector3 posListener = AudioListener.transform.position;
            AudioListener.transform.position = new Vector3(posListener.x, posListener.y - delta * 0.025f, posListener.z);
            AudioListener.transform.position = new Vector3(
                AudioListener.transform.position.x,
                Mathf.Clamp(AudioListener.transform.position.y, 15f, 22f),
                posListener.z);



        /*    if (nextZoom > ZoomMin && nextZoom < ZoomMax)
            {
                cinemachine.m_Lens.FieldOfView = Mathf.Clamp(cinemachine.m_Lens.FieldOfView, ZoomMin, ZoomMax);
            }*/
        }
        distance = Vector2.Distance(finger1, finger2);
    }


}
