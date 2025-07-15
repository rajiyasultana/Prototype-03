using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandaler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Everything is fine!");
                break;

            case "Finish":
                LoadNextScene();
                break;

            default:
                StartCrushSequence();
                break;
        }
    }

    void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        if(nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }

        SceneManager.LoadScene(nextScene);
    }

    void StartCrushSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", 2f);
    }

    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
