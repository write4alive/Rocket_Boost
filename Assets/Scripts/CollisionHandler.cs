using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float invoke_load_delay = 2f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    AudioSource audios;

    void Start() 
    {
        audios = GetComponent<AudioSource>();    
    }
    private void OnCollisionEnter(Collision other) 
    {
       

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendlyyyyyy");
                break;

            case "Finish":
                finish_level_sequence();
                Debug.Log("Finish");
                break;

            case "Fuel":
                Debug.Log("fuel");
                break;

            default:
                Debug.Log("booom ! ");
                start_crash_sequence();
                break;
        }


    }

    void finish_level_sequence()
    {
        audios.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;
        Invoke("load_next_level",invoke_load_delay);
    }
    void start_crash_sequence()
    {
        audios.PlayOneShot(crash);
        GetComponent<Movement>().enabled = false;
        Invoke("hit_reset_level",invoke_load_delay);
    }

    void load_next_level()
    {
        int current_scene_index  = SceneManager.GetActiveScene().buildIndex;
        int next_scene_index = current_scene_index + 1;
        //when we completed all levels game will start again from level 1
        if (next_scene_index == SceneManager.sceneCountInBuildSettings)
        {
            next_scene_index = 0;   
        }
        SceneManager.LoadScene(next_scene_index);
    }

    void hit_reset_level()
    {
        int current_scene_index  = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current_scene_index);
    }
}
