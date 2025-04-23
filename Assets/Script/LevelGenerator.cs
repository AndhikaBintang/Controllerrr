using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200F;

    [SerializeField] private Transform levelPartStart;
    [SerializeField] private List<Transform> levelpartlist;
    [SerializeField] private Player player;

    private Vector3 lastEndPos;

    public Vector3 GetPosition() 
    {
        return transform.position;
    }

    private void Awake()
    {
        lastEndPos = levelPartStart.Find("EndPoint").position;

        int startingSpawnLevelParts = 5;
        for(int i = 0; i < startingSpawnLevelParts; i++)
        {
            spawnLevelPart();
        }

        
    }

    private void Update()
    {
        if(Vector3.Distance(player.GetPosition(), lastEndPos) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            spawnLevelPart();
        }
    }

    private void spawnLevelPart()
    {
        Transform choosenLevelPart = levelpartlist[Random.Range(0,levelpartlist.Count)];
        Transform lastLevelPartTransform = spawnLevelPart(choosenLevelPart,lastEndPos);
        lastEndPos = lastLevelPartTransform.Find("EndPoint").position;
    }

    private Transform spawnLevelPart(Transform levelPart, Vector3 spawnPos)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPos, Quaternion.identity);
        return levelPartTransform;
    }
}