using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject player;
    public List<Transform> spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(player.name, spawnPoints[Random.Range(0,spawnPoints.Count-1)].position, Quaternion.identity);
    }
    public void LeaveGame()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
         SceneManager.LoadScene(0);
         
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " залетел в игру еже");
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
