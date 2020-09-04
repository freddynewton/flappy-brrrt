using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public GameObject doubleWallPf;
    public float waitTimeForWall = 4;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Awake()
    {
        StartCoroutine(SpawnWalls());
    }

    private IEnumerator SpawnWalls()
    {
        yield return new WaitForSecondsRealtime(waitTimeForWall);
        GameObject walls = Instantiate(doubleWallPf, new Vector3(105 + player.position.x, 0, 0), Quaternion.identity, null) as GameObject;
        walls.GetComponent<DoubleWall>().SpawnWall(6);

        StartCoroutine(SpawnWalls());
    }
}
