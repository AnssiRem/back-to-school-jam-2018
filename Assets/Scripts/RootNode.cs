﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootNode : MonoBehaviour
{
    public float GrowthSpeed;
    public float ShrinkRate;

    private bool isGrowing;
    private Player player;

    private void Start()
    {
        isGrowing = true;

        player = GameObject.Find("/Script Holder").GetComponent<Player>();

        transform.localScale = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        Grow();
    }

    private void Grow()
    {
        if (isGrowing)
        {
            transform.localScale += new Vector3(GrowthSpeed * Time.deltaTime, GrowthSpeed * Time.deltaTime, GrowthSpeed * Time.deltaTime);

            if (transform.localScale.y >= 0.75f * Mathf.Pow(ShrinkRate, player.RootParts))
            {
                StopGrowing();
            }
        }
    }

    private void StopGrowing()
    {
        isGrowing = false;
        player.Ready();
        transform.localScale = new Vector3(0.75f * Mathf.Pow(ShrinkRate, player.RootParts), 0.75f * Mathf.Pow(ShrinkRate, player.RootParts), 0.75f * Mathf.Pow(ShrinkRate, player.RootParts));
        enabled = false;
    }
}
