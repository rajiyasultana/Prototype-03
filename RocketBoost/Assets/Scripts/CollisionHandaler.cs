using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandaler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;

    AudioSource audioSource;

    bool isControllable = true;
    bool isColidable = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            LoadNextScene();
        }
        else if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            isColidable = !isColidable;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (!isControllable || !isColidable)
        {
            return;
        }
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Everything is fine!");
                break;

            case "Finish":
                StartSuccessSequence();
                break;

            default:
                StartCrushSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        isControllable = false ;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextScene", levelLoadDelay);
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
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        crashParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
