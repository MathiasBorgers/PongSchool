using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ChangeScene : MonoBehaviour
{

    public void MoveToScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void Quit()
    {
        Application.Quit();
    }


}
