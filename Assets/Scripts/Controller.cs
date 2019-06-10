using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    bool forward;
    bool backward;

    public float speed;

    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; //rotation around the up/y axis
    private float rotX = 0.0f; //rotation around the right/x axis

    // Use this for initialization
    void Start () {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }
	
	// Update is called once per frame
	void Update () {
        forward = Input.GetKey(KeyCode.W);
        backward = Input.GetKey(KeyCode.S);

        Transform trans = GetComponent<Transform>();
        Vector3 direction = trans.forward;

        if (forward) {
            trans.position += direction.normalized * speed;
        }
        if (backward) {
            trans.position -= direction.normalized * speed;
        }

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }
}
