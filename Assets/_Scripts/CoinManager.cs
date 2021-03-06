﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    bool entered = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!entered)
        {
            SoundManager.Instance.Play("Coin" + Random.Range(0, 3).ToString());
            CanvasManager.Instance.increasePoints();

            LeanTween.scale(gameObject, Vector3.zero, 0.5f).setEaseInElastic();
            entered = true;
        }
    }
}
