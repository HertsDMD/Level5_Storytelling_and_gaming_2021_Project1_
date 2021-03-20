using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void RestartThisScene()
    {
        StartCoroutine(SceneRestartCoroutine());
    }

    IEnumerator SceneRestartCoroutine()
    {
        yield return new WaitForSeconds(1);
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadSceneAsync(currentScene);
    }

}
