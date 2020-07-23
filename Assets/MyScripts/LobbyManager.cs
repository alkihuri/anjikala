using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField roomnameUI;
    public InputField nicknameUI;
    public Button create, join;
    // Start is called before the first frame update
    void Start()
    {
        create.interactable = false;
        join.interactable = false;
        nicknameUI.text = "Player" + Random.Range(1, 1000);
        PhotonNetwork.AutomaticallySyncScene = false ;
        PhotonNetwork.GameVersion = "1"; 
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnLeftLobby()
    {
       
    }
    public override void OnConnectedToMaster()
    {
        create.interactable = true;
        join.interactable = true;
        Debug.Log("Все четко баля ");
    }
    public void CreateRoom( )
    { 
        string roomname = roomnameUI.text;
        if (roomname == "")
        {
            roomname = "Default";
        }
        PhotonNetwork.CreateRoom(roomname);
    }
    public void JoinRoom()
    {
        string roomname = roomnameUI.text;
        if (roomname == "")
        {
            roomname = "Default";
        }
        PhotonNetwork.JoinRoom(roomname);  
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Комамнат создана баля");

        JoinRoom();
    }
    
    public override void OnJoinedRoom()
    {
        Debug.Log("В команту залете вацаля"); 
        PhotonNetwork.LoadLevel("Game");
    }
    // Update is called once per frame

    public void NickNameChange()
    {

        PhotonNetwork.NickName = nicknameUI.text;
    }
    void Update()
    {
    }
}
