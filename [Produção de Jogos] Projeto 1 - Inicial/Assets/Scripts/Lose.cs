using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{

    Vector3 playerPos;

    void Update()
    {
        playerPos = GameObject.Find("BolinhaPlayer").transform.position;
        transform.position = new Vector3(playerPos.x, -20, playerPos.z);
    }

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Bolinha");
    }
}
