using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] string sceneName;
    bool canChangeScene = false;
    public Facing facing;
    public enum Facing { left, right };

    void Update()
    {
        if (canChangeScene && Input.GetKeyDown(KeyCode.E))
        {
            StaticClass.sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canChangeScene = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canChangeScene = false;
        }
    }
}
