using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScene : MonoBehaviour
{
    public Button PlayButton;
    public GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Event Handler");
        PlayButton = GameObject.Find("Play Button").GetComponent<Button>();
        PlayButton.onClick.AddListener(Press);
    }

    private void Press()
    {
        manager.GetComponent<GameManager>().PlayGame();
    }

}