using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    float mouseSens;
    [SerializeField]
    Transform playerBody;

    float xRotation = 0f;
    void Start()
    {
        if (GameManager.instance.game.currentLvl != "Tutorial")
            UiManager.instance.Lock();

    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        //move camera left and right
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);

        //move camera up and down
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
