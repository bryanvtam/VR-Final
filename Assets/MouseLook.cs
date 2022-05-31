using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    //so you can set a target object, this case its the player body so it can turn when you turn mouse
    public Transform playerBody;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //hide and lock cursor to middle of screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {   
        //Input.GetAxis("Mouse X") a pre-programemed axis inside unity that is goiong to change based on mouse movement
        //(unity -> edit ->project settings -> Input)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")* mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        //restrict rotation to only go -90 degrees and 90 degrees so palyer enver looks behind
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //quaternion is responsible for roation in unity
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up *mouseX);
    }
}
