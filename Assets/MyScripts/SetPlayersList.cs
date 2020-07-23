using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;
using UnityEngine.UI;

public class SetPlayersList : MonoBehaviour
{
    List<GameObject> playersList;
    public GameObject playerListPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playersList = GameObject.FindGameObjectsWithTag("Player").ToList();
        playersList = playersList.OrderBy(player => player.GetComponent<PlayerStats>().score).ToList();
        if (Input.GetKey(KeyCode.Tab))
        {
            playerListPanel.transform.localScale = new Vector3(1, 1, 1);
            GetComponent<Text>().text = "";
            for (int i = 0; i < playersList.Count; i++)
            {
                GetComponent<Text>().text += (i + 1) + ". " + playersList[i].GetComponent<PlayerController>().nickNameAbovePlayer.text + "   " + playersList[i].GetComponent<PlayerStats>().score + "     " + playersList[i].GetComponent<PlayerStats>().numOfDies + "\n";
            }
        }
        else
        {
            playerListPanel.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    public void GetPlayerList()
    {
        
    }
}
