using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class portal : MonoBehaviour
{
    // Start is called before the first frame update
    public string NameoftheNextScene;

    void SceneLoad(string NextSceneName)
    {
        SceneManager.LoadScene(NextSceneName);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (SceneUtility.GetBuildIndexByScenePath(NameoftheNextScene) >= 0)
            {
                    SceneLoad(NameoftheNextScene);
            }
            else
            {
                //MAIN MENU
                Debug.Log("No Scene");
            }

        }

    }

}
