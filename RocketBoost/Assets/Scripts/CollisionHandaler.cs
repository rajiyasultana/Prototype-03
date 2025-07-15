using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandaler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly" :
                Debug.Log("Everything is fine!");
                break;
            case "Finish":
                Debug.Log("Welcome to new country!");
                break;
            case "Fuel":
                Debug.Log("I am not in the game!!!!");
                break;
            default:
                ReloadLevel();
                break;
        }

        void ReloadLevel()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
    }
}
