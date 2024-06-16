using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ammo : MonoBehaviour
{

    [System.Obsolete]
    public GameManager gamemanger;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(-1, 0, 0);
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player")) {
           

            Debug.Log("tm");
           gamemanger.GetComponent<GameManager>(). missles++;
            transform.gameObject.SetActive(false);
        }


    }
    }

