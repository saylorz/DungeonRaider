using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider _collider)
    {
        if(_collider.tag == "Enemy")
        {
            Destroy(_collider.gameObject);
            Destroy(this.gameObject);
        }

        if(_collider.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
