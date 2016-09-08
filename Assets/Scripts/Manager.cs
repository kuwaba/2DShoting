using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

    public GameObject player;

    private GameObject title;
    //private GameObject Emitter;


    // Use this for initialization
    void Start () {

        title = GameObject.Find("Title");
        //Emitter = GameObject.Find("Emitter");


    }
	
	// Update is called once per frame
    void OnGUI()
    {
        if(IsPlaying() == false && Event.current.type == EventType.MouseDown)
        {
            GameStart();
        }
    }



	//void Update () {

 //       for(int i = 0; i < Input.touchCount; i++)
 //       {
 //           Touch touch = Input.GetTouch(i);
 //           if (IsPlaying() == false && touch.phase == TouchPhase.Began)
 //           {
 //               GameStart();
 //           }
 //       }
 //       if (IsPlaying() == false && Input.GetMouseButtonDown(0))
 //       {
 //           GameStart();
 //       }

 //   }

    void GameStart()
    {
        title.SetActive(false);
        Instantiate(player, player.transform.position, player.transform.rotation);
    }

    public void GameOver()
    {
        FindObjectOfType<Score>().Save();
        title.SetActive(true);
    }

    public bool IsPlaying()
    {
        return title.activeSelf == false;
    }
}
