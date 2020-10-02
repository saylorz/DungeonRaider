using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]  
    public float Speed = 3;
    public float rotSpeed = 3f;

    [Header("Shooting")]
    public GameObject bullet;
    public float bulletSpeed = 10f;
    public float reset = .3f;
    public float timer = .3f;
    public bool canFire = true;

    [Header("Score Tracking")]
    public float points = 0;
    public int kills = 0;

    [Header("Other")]
    public float hp = 3f;
    public GameObject manager;

    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        points = 0;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        manager = GameObject.Find("Event Handler");
        //Movement
        float v = Input.GetAxisRaw("Vertical");

        rb.velocity = transform.forward * Speed * v;

        //Rotation
        float h = Input.GetAxisRaw("Horizontal");

        Quaternion wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * (rotSpeed * h * Time.deltaTime));
        rb.MoveRotation(wantedRotation);

        //Shooting
        if(Input.GetAxis("Jump") > 0 && canFire)
        {
            GameObject temp = GameObject.Instantiate(bullet);
            Rigidbody tempRig = temp.GetComponent<Rigidbody>();

            tempRig.position = this.gameObject.transform.right * 0.5f + this.gameObject.transform.position;      
            temp.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
            canFire = false;
        }

        if(!canFire)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                timer = reset;
                canFire = true;
            }
        }

        //Win
        float points = manager.GetComponent<GameManager>().points;
        if(points == 10)
        {

            Destroy(this.gameObject);
            manager.GetComponent<GameManager>().YouWin();
        }

        //Loss
        if(hp == 0)
        {
            hp = 3;
            manager.GetComponent<GameManager>().GameOver();
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter(Collider _collider)
    {
        if(_collider.tag == "Enemy")
        {
            hp-=1f;
        }

        if(_collider.name == "Portal 1")
        {
            manager.GetComponent<GameManager>().loadL1();
            this.transform.position = new Vector3(-12.61f,1.1f,-13f);
        }

        if(_collider.name == "Portal 2")
        {
            manager.GetComponent<GameManager>().loadL2();
            this.transform.position = new Vector3(0,1,0);
        }

        if(_collider.name == "Portal 3")
        {
            manager.GetComponent<GameManager>().loadL3();
            this.transform.position = new Vector3(-13,1,-12);
        }

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }


}
