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
                        Debug.Log("Congrats, you finished!");
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
        }
    }
