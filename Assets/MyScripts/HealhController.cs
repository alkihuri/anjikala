using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon;
using UnityEngine.SceneManagement;

public class HealhController : MonoBehaviourPunCallbacks
{
    [Range(0, 100)] public float health;
    GameManager gameManager;
    public Text healthUI;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        health = 100;
        SetCurrentHealth();
    }
    [PunRPC]
    public void SetCurrentHealth()
    {
        healthUI.text = health.ToString();
        if (health > 0)
            healthUI.color = Color.red;
        if (health > 49)
            healthUI.color = Color.yellow;
        if (health > 75)
            healthUI.color = Color.green;

        if (health == 0)
        {
             
            GetComponent<PhotonView>().RPC("AddDeath", RpcTarget.All,1);
            transform.position = gameManager.spawnPoints[Random.Range(0, gameManager.spawnPoints.Count - 1)].transform.position;
            health = 100;
        }
         
    }
    [PunRPC]
    public void TakeDamage(float damage = 1)
    {
        if (health > 0)
        {

            health -= damage;
            SetCurrentHealth();
        }

       
    }
    [PunRPC]
    public void TakeHealing(float healing = 1)
    {
        if (health < 100)
        {

            health += healing;
            SetCurrentHealth();
        }

        
    }
    private void Update()
    {

        SetCurrentHealth();
    }

}
