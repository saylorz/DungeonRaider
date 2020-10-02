using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public GameObject manager;

    void Update()
    {
        manager = GameObject.Find("Event Handler");
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if(_collider.tag == "Player")
        {
            manager.GetComponent<GameManager>().points+=0.5f;
            Destroy(gameObject);
        }
    }

    
}
