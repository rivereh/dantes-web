using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] SceneChanger[] spawnPoints;
    [SerializeField] GameObject player;


    void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (spawnPoints[i].name == StaticClass.sceneName)
            {
                player.transform.position = spawnPoints[i].transform.position;
                if (spawnPoints[i].facing == SceneChanger.Facing.left)
                {
                    player.transform.localScale = new Vector3(-1, 1, 1);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
