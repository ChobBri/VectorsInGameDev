using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class E_DotProduct : MonoBehaviour
{
    [SerializeField] GameObject cylinder;
    [SerializeField] new Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        /**
         * Question 3:
         * - set `isBehindCylinder` to true if the camera is behind the cylinder,
         *   otherwise, set `isBehindCylinder` to false (is infront of cylinder).
         *   
         *   'behind behind the cylinder' is defined as such:
         *   Imagine a (mathematical) plane that cuts through the cylinder into its front half and back half.
         *   Then, you are behind the cylinder when you are on the back-half side of the plane.
         *   
         * [Bonus]
         * - Same thing as the first question, but `isBehindCylinder` is true when
         *   the camera is inside a cone where the sides and the base-normal vector is 45 degs apart
         *   Note: cos(45) = sqrt(2)/2 = 0.707
         * 
         */
        MovementControls();
        Vector3 cylinderDirection = cylinder.transform.rotation * Vector3.forward;
        Vector3 cameraDirection = camera.transform.rotation * Vector3.forward;
        Vector3 camToCylinder = cylinder.transform.position - camera.transform.position;

        bool isBehindCylinder = false;

        // Your solution to Q4 here

        isBehindCylinder = Vector3.Dot(cylinderDirection, camToCylinder.normalized) > 0.707 && camToCylinder.sqrMagnitude < 0.5f * 0.5f;

        // End Q4 solution

        cylinder.GetComponent<MeshRenderer>().material.color = isBehindCylinder ? Color.green : Color.red;
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
        Gizmos.DrawWireSphere(cylinder.transform.position, 0.5f);
    }
}
