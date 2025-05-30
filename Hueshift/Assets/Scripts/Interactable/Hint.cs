using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Hint : MonoBehaviour
{
#if UNITY_EDITOR
    public SceneAsset sceneToLoad;
#endif

    [HideInInspector] public string sceneToLoadName; // Utilisé en runtime

    private void OnValidate()
    {
#if UNITY_EDITOR
        if (sceneToLoad != null)   
        {
            sceneToLoadName = sceneToLoad.name;
        }
#endif
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            SceneManager.LoadScene(sceneToLoadName, LoadSceneMode.Additive);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
