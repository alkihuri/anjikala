 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GunLogic : MonoBehaviourPunCallbacks
{
    [Range(1,50)]public float  gunDamage;
    public GameObject Fx; 
    // Start is called before the first frame update
    void Start()
    { 
        gunDamage = 1;
    }
    RaycastHit2D objectOnHitLine;
    // Update is called once per frame
    void Update()
    {
       
        objectOnHitLine = Physics2D.Raycast(transform.position, transform.up,10);
       
            if(Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space))
            {
             if (GetComponentInParent<PhotonView>().gameObject.GetComponent<PhotonView>().IsMine)
                Fx.transform.localScale = new Vector3(0.171f, 0.171f, 0.171f);
                    if (objectOnHitLine.transform.gameObject.tag == "Player")
                        {
                        if (!objectOnHitLine.transform.gameObject.GetComponent<PhotonView>().IsMine)
                            {
                                objectOnHitLine.transform.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, gunDamage);
                                GetComponentInParent<PhotonView>().RPC("AddScore", RpcTarget.All, 1);
                            }
                        }
            }
            else
            {
                Fx.transform.localScale = new Vector3(0, 0, 0);
            }
        
        Debug.DrawLine(transform.position, objectOnHitLine.transform.position, Color.yellow);
       // Debug.Log(objectOnHitLine.transform.gameObject.name);
    }
}
