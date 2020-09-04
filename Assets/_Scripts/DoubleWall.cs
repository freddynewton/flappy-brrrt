using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleWall : MonoBehaviour
{
    public GameObject wallOne;
    public GameObject wallTwo;
    public GameObject coin;
    private Transform player;

    public float easeTime = 0.5f;
    public float delayTime = 1f;

    private void LateUpdate()
    {
        if ((gameObject.transform.position.x - player.position.x) <= -200) Destroy(gameObject);
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Bad trash code ^^
    public void SpawnWall(float gapSize)
    {
        float wallOneSize = 0;
        float wallTwoSize = 0;
        float coinpos = 0;
        int test = Random.Range(0, 2);

        if (test == 0)
        {
            wallOneSize = Random.Range(0.01f, 19.99f - gapSize);
            wallTwoSize = 20 - (gapSize + wallOneSize);
            coinpos = wallOneSize * -2.5f;
        }
        else
        {
            wallTwoSize = Random.Range(0.01f, 19.99f - gapSize);
            wallOneSize = 20 - (gapSize + wallTwoSize);
            coinpos = wallTwoSize * 2.5f;
        }



        LeanTween.scaleY(wallOne, wallOneSize, easeTime).setEaseOutBounce().setDelay(delayTime);
        LeanTween.scaleY(wallTwo, wallTwoSize, easeTime).setEaseOutBounce().setDelay(delayTime);


        LeanTween.moveY(coin, coinpos, easeTime).setEaseInOutBounce().setDelay(delayTime);

    }
}
