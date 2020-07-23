using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;

public class PlayerController : MonoBehaviour
{

    PhotonView photonView;
    public Text nickNameAbovePlayer;
    // Start is called before the first frame update
    void Start()
    {

        photonView = GetComponent<PhotonView>();
        if(photonView.IsMine)
            photonView.RPC("SetName", RpcTarget.All, PhotonNetwork.NickName);
    }
    [PunRPC]
    public void SetName(string name)
    {
        nickNameAbovePlayer.text = name;
        if (photonView.IsMine)
        {
            nickNameAbovePlayer.text = "You";
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            photonView.RPC("SetName", RpcTarget.All, PhotonNetwork.NickName);
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            transform.position = transform.position + transform.up * vertical /10;
            transform.Rotate(0,0, -horizontal * 3);
        }

    }
}
