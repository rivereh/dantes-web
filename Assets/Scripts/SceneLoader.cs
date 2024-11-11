using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] SceneChanger[] spawnPoints;
    [SerializeField] GameObject player;

    Vector2 initialLocalScale;

    void Start()
    {
        initialLocalScale = player.transform.localScale;
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (spawnPoints[i].name == StaticClass.sceneName)
            {
                player.transform.position = spawnPoints[i].transform.position;
                // TODO - flip player sprite if facing left
                if (spawnPoints[i].facing == SceneChanger.Facing.left)
                {
                    // player.transform.localScale = new Vector2(initialLocalScale.x * -1, initialLocalScale.y);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
