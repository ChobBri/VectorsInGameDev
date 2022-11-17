using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class C4_DotProductF : MonoBehaviour
{
    [SerializeField] GameObject f;
    [SerializeField] new Camera camera;
    [SerializeField] GameObject uiText;
    float globalRadius = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        /**
         * Checkpoint 4:
         * - set `canPayRespect` to true if:
         *     the player is 'looking near' the text 'F' and
         *     the player and the text is `radius` units apart.
         *   
         * A player is 'looking near' something if the looking direction and the direction of where
         * the text is is less than 15 degrees apart.
         * 
         * You may assume: cos(15) = 0.966
         */
        MovementControls();
        f.transform.rotation = Quaternion.LookRotation(camera.transform.position - f.transform.position);

        Vector3 cameraDirection = camera.transform.rotation * Vector3.forward;
        Vector3 camToF = f.transform.position - camera.transform.position;

        const float radius = 0.7f;
        bool canPayRespect = false; // edit this variable
        // Your solution to Q4 here


        // End Q4 solution

        uiText.SetActive(canPayRespect);
        if (canPayRespect && Input.GetKeyDown(KeyCode.F)) Debug.Log("Paid respects");
        globalRadius = radius;
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
        Gizmos.DrawWireSphere(f.transform.position, globalRadius);
    }
}
