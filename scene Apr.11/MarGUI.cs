using UnityEngine;
using System.Collections;

public class MarGUI : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Input.multiTouchEnabled = false;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    void OnGUI()
    {
        GUI.skin.button.fontSize = 32;
        if (Application.loadedLevel != 0)
        {
            if (GUI.Button(new Rect(0, 0, Screen.height*3 / 16f, Screen.height / 8f), "Last"))
            {
                int nextscene = Application.loadedLevel - 1;
                if (nextscene == 0) nextscene--;
                if (nextscene < 0) nextscene = Application.levelCount - 3;
                Application.LoadLevel(nextscene);
            }
            else if (GUI.Button(new Rect(Screen.width - Screen.height*3 / 16f, 0, Screen.height * 3 / 16f, Screen.height / 8f), "Return"))
            {
				Time.timeScale = 1;
                if (Application.loadedLevel != Application.levelCount - 1 && Application.loadedLevel != Application.levelCount - 2)
                {
                    int nextscene = 0;
                    Application.LoadLevel(Application.levelCount - 1);
                }
                else
                {
                    Application.LoadLevel(0);
                }
            }
            else if (GUI.Button(new Rect(Screen.width/2 - Screen.height / 16f, 0, Screen.height*3 / 16f, Screen.height / 8f), "Retry"))
            {
                int nextscene = Application.loadedLevel;
                Application.LoadLevel(nextscene);
            }
        }
        else
        {
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.height / 8, Screen.height*2 / 5, Screen.height / 4f, Screen.height / 8f), "Start"))
            {
                int nextscene = 1;
                Application.LoadLevel(Application.levelCount-1);
            }
            else if (GUI.Button(new Rect(Screen.width / 2 - Screen.height / 8, Screen.height * 3 / 5, Screen.height / 4f, Screen.height / 8f), "tutorial"))
            {
                Application.LoadLevel(Application.levelCount - 2);
            }   
            else if (GUI.Button(new Rect(Screen.width / 2 - Screen.height / 8, Screen.height*4 / 5, Screen.height / 4f, Screen.height / 8f), "Quit"))
            {
                Application.Quit();
            }     
        }
    }
}
