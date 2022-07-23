using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
       

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendlyyyyyy");
                break;

            case "Finish":
                Debug.Log("Finish");
                break;

            case "Fuel":
                Debug.Log("fuel");
                break;

            default:
                Debug.Log("booom ! ");
                NewMethod();
                break;
        }


    }

    private static void NewMethod()
    {
        int current_scene_index  = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current_scene_index);
    }
}
