using UnityEngine;
using UnityEngine.SceneManagement;

//Start Screen

//End Screen
//Maybe Death screen? maybe not, might move to playerLife

public class StartScreen : MonoBehaviour
{

    //still deciding if I do a separate scene where we tell the story or
    //tell story in the room 1
    public void OnStartClick()
    {
         SceneManager.LoadScene("Room 1");
    }


    //ONLY FOR START SCREEN
    public void OnQuitOneClick()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }

    /*
    ->Stages button, when player saves content
    public void OnStagesClick(){
    }
    */


}
