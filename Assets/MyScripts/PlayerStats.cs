using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviourPunCallbacks
{
    public int score;
    public int numOfDies;
    public Text scoreUI, numOfDiesUI;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        numOfDies = 0;
    }
    [PunRPC]
    public void AddScore(int _score)
    {
        score += _score;
    }
    [PunRPC]
    public void AddDeath(int value)
    {
        numOfDies+=value;
    }
    private void Update()
    {
        if(GetComponent<PhotonView>().IsMine)
        {
            scoreUI.text = "Score - " + score.ToString(); ;
            numOfDiesUI.text = "Death - " + numOfDies.ToString();
        }
        else
        {
            scoreUI.enabled = false;
            numOfDiesUI.enabled = false;
        }
    }
}
