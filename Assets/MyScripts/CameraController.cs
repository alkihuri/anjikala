using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;

public class CameraController : MonoBehaviourPunCallbacks
{

    private void Start()
    {
        List<Camera> cameras = GameObject.FindObjectsOfType<Camera>().ToList();
        foreach(Camera cameraOnScene in cameras)
        {
            if(!cameraOnScene.GetComponentInParent<PhotonView>().IsMine)
            {
                cameraOnScene.enabled = false;
            }
        }
    }
    private void Update()
    {
        Debug.Log("mag=" + GetComponentInParent<Rigidbody2D>().velocity.magnitude);
        transform.position =  new Vector3(transform.position.x, transform.position.y, -5 - Mathf.Abs((4*Input.GetAxis("Vertical"))));
    }
}
