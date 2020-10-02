using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    //public GameObject spawnPoint;
    public Button PlayButton;
    public float points = 0.0f;

    void Start()
    {
        PlayButton = GameObject.Find("Play Button").GetComponent<Button>();
        PlayButton.onClick.AddListener(PlayGame);

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        Debug.Log("The Start button has been hit");
        Instantiate(player);
        SceneManager.LoadScene("Scenes/Level1", LoadSceneMode.Single);
        player.transform.position = new Vector3(-12.61f,1.1f,-13f);
    }

    


    public void loadL1()
    {
        Debug.Log("Loading Level !");
        SceneManager.LoadScene("Scenes/Level1", LoadSceneMode.Single);
        //spawnPoint = GameObject.Find("Spawn Player");
        player.transform.position = new Vector3(-12.61f,1.1f,-13f);
    }

    public void loadL2()
    {
        Debug.Log("Loading Level 2");
        player.transform.position = new Vector3(0,1,0);
        SceneManager.LoadScene("Scenes/Level2", LoadSceneMode.Single);     
    }

    public void loadL3()
    {
        Debug.Log("Loading Level 3");
        SceneManager.LoadScene("Scenes/Level3", LoadSceneMode.Single);
    }

    public void GameOver()
    {
        Debug.Log("Loading Game Over Screen");
        SceneManager.LoadScene("Scenes/GameOver", LoadSceneMode.Single);
        //Destroy(player);
    }

    public void YouWin()
    {
        points = 0;
        Debug.Log("Loading Win Screen");
        SceneManager.LoadScene("Scenes/WinScreen", LoadSceneMode.Single);
    }

}
