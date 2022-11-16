using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class C6_CrossProductOrientation : MonoBehaviour
{
    [SerializeField] GameObject cylinder;
    [SerializeField] Transform bottom;
    [SerializeField] new Camera camera;

    bool isGrabbing = true;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        /**
         * Checkpoint 6:
         * - compute the forward vector of the cylinder.
         *   The forward vector should be parallel to both the surface and the plane spanned by the normal vector and look direction
         */
        if(!Input.GetMouseButton(1)) MovementControls();
        Vector3 cylinderDirection = cylinder.transform.rotation * Vector3.forward;
        Vector3 camDir = camera.transform.rotation * Vector3.forward;
        Vector3 camToCylinder = cylinder.transform.position - camera.transform.position;
        Debug.DrawLine(camera.transform.position, camera.transform.position + camDir);
        bool isBehindCylinder = false;


        if (isGrabbing)
        {
            RaycastHit hit;
            const float range = 1.25f;
            if (Physics.Raycast(camera.transform.position, camDir, out hit, range))
            {
                float halfLength = (cylinder.transform.position - bottom.position).magnitude;
                cylinder.transform.position = hit.point + hit.normal * halfLength;

                Vector3 normal = hit.normal;
                Vector3 cameraDirection = camDir;
                Vector3 forward = camera.transform.rotation * Vector3.forward;  // edit this variable
                // Your solution to C6 here

                Vector3 sideVec = Vector3.Cross(cameraDirection, normal);
                forward = Vector3.Cross(normal, sideVec);

                // End C6 solution

                cylinder.transform.rotation = Quaternion.LookRotation(forward, normal);

                if (Input.GetMouseButtonDown(0))
                {
                    isGrabbing = false;
                }

            }
            else
            {
                cylinder.transform.rotation = camera.transform.rotation;
                cylinder.transform.position = camera.transform.position + camDir.normalized * range;
            }
        } 
        else
        {
            if (Input.GetMouseButtonDown(0))
                isGrabbing = true;
        }

        


        isBehindCylinder = Vector3.Dot(cylinderDirection, camToCylinder.normalized) > 0.707 && camToCylinder.sqrMagnitude < 0.4f * 0.4f;

        // End Q4 solution

        cylinder.GetComponent<MeshRenderer>().material.color = !isGrabbing ? Color.green : Color.red;
    }

    void MovementControls()
    {

        if (Input.GetKey(KeyCode.A))
        {
            camera.transform.Translate(Vector3.left * 1.0f * Time.deltaTime, Space.Self);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            camera.transform.Translate(Vector3.right * 1.0f * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 rot = camera.transform.rotation.eulerAngles;
            camera.transform.Translate(Quaternion.Euler(0.0f, rot.y, 0.0f) * Vector3.forward * 1.0f * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 rot = camera.transform.rotation.eulerAngles;
            camera.transform.Translate(Quaternion.Euler(0.0f, rot.y, 0.0f) * Vector3.back * 1.0f * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.E))
        {
            camera.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            camera.transform.Translate(Vector3.down * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            camera.transform.Rotate(Vector3.right, -90.0f * Time.deltaTime, Space.Self);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            camera.transform.Rotate(Vector3.right, 90.0f * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            camera.transform.Rotate(Vector3.up, 90.0f * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            camera.transform.Rotate(Vector3.up, -90.0f * Time.deltaTime, Space.World);
        }

        camera.transform.Rotate(Vector3.up, 5.0f * Input.GetAxis("Mouse X"), Space.World);
        camera.transform.Rotate(Vector3.right, -5.0f * Input.GetAxis("Mouse Y"), Space.Self);

        Vector3 eAng = camera.transform.rotation.eulerAngles;
        eAng.z = 0.0f;
        if (eAng.x > 180.0f)
            eAng.x -= 360.0f;
        eAng.x = Mathf.Clamp(eAng.x, -80.0f, 80.0f);

        camera.transform.rotation = Quaternion.Euler(eAng);
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.green;
        Handles.DrawAAPolyLine(cylinder.transform.position, cylinder.transform.position + cylinder.transform.rotation * Vector3.forward * 5.0f);
    }
}
