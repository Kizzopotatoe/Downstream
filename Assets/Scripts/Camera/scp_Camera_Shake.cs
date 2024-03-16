using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class scp_Camera_Shake : MonoBehaviour
{
    //Reference to the main camera
    Camera mainCamera;
    //Strength of the shake
    public float cameraShakeStrength;
    //Duration of shake
    public float cameraShakeDuration;
    //Variable to store the original camera position
    Vector3 originalCameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Finds the camera and stores it in this variable
        mainCamera = Camera.main;

        // Stores the original camera position
        originalCameraPosition = mainCamera.transform.position;
    }

    void Update()
    {
        // Stores the original camera position
        originalCameraPosition = mainCamera.transform.position;
    }

    public void Shake()
    {
        // Shakes the camera for a set strength and duration
        mainCamera.transform.DOShakePosition(cameraShakeDuration, cameraShakeStrength);

        //Invokes the camera reset after 0.2 seconds
        Invoke("ResetCamera", 0.2f);
    }

    void ResetCamera()
    {
        // Resets the camera position after the shake
        mainCamera.transform.DOMove(originalCameraPosition, 0.2f);
    }
}
