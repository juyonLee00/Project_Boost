using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) {
        {
            switch (other.gameObject.tag) 
                {
                    case "Friendly":
                        Debug.Log("This thing is friendly");
                        break;
                    case "Finish":
                        LoadNextLevel();
                        break;
                    case "Fuel":
                        Debug.Log("This thing is fuel");
                        break;
                    default:
                        ReloadLevel();
                        break;
                }
            }

            void ReloadLevel()
            {
                //씬 인덱스 반환
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex);
            }

            void LoadNextLevel()
            {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                int nextSceneIndex = currentSceneIndex + 1;
                if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
                {
                    nextSceneIndex = 0;
                }
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }
