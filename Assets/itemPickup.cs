using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;
using UnityEngine.UI;

public class itemPickup : MonoBehaviour
{
    public ArcadeKart playerKart;
    ArcadeKart[] karts;
    private GameFlowManager manager;

    public AudioClip pickupSound;

    public ItemType itemType;
    
    private void Start()
    {
        karts = FindObjectsOfType<ArcadeKart>();
        if (karts.Length > 0)
        {
            if (!playerKart) playerKart = karts[0];
        }
        DebugUtility.HandleErrorIfNullFindObject<ArcadeKart, GameFlowManager>(playerKart, this);

        manager = FindObjectOfType<GameFlowManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playerKart.hasItem)
        {
            playerKart.audioSource.PlayOneShot(pickupSound);
            playerKart.currentItem = itemType;
            playerKart.hasItem = true;
            manager.StartTimer();
            Destroy(this.gameObject);
        }
    }
}
