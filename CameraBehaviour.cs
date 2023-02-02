using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    enum CAM_STATE {FOLLOW, DYNAMIC}

    private CAM_STATE currentCamState;

    public Transform player;

    private Quaternion originalRotation;
    private Quaternion currentRotation;
    private float speed = 5;
   

    // Start is called before the first frame update
    void Start()
    {
        currentCamState = CAM_STATE.FOLLOW;
        originalRotation = transform.rotation;
        currentRotation = originalRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (currentCamState == CAM_STATE.FOLLOW)
                currentCamState = CAM_STATE.DYNAMIC;
            else
                currentCamState = CAM_STATE.FOLLOW;
        }
       
        switch (currentCamState) {
            case CAM_STATE.DYNAMIC:
                currentRotation = player.rotation;
                break;
            case CAM_STATE.FOLLOW:
                currentRotation = originalRotation;
                break;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, currentRotation, Time.deltaTime * speed);
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}