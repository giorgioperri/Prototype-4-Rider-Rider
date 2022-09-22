using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;
using UnityEngine.UI;

public class deliveryZone : MonoBehaviour
{
    public Image amp_hl;
    public Image bass_hl;
    public Image booze_hl;
    public Image mnm_hl;
    public Image amp_scrib;
    public Image bass_scrib;
    public Image booze_scrib;
    public Image mnm_scrib;

    public AudioClip scribbleSound;
    public ArcadeKart playerKart;
    ArcadeKart[] karts;
    private GameFlowManager manager;
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
        if (other.CompareTag("Player") && playerKart.hasItem)
        {
            switch (playerKart.currentItem)
            {
                case ItemType.amp:
                    amp_hl.gameObject.SetActive(false);
                    amp_scrib.gameObject.SetActive(true);
                    break;
                case ItemType.bass:
                    bass_hl.gameObject.SetActive(false);
                    bass_scrib.gameObject.SetActive(true);
                    break;
                case ItemType.booze:
                    booze_hl.gameObject.SetActive(false);
                    booze_scrib.gameObject.SetActive(true);
                    break;
                default:
                    mnm_hl.gameObject.SetActive(false);
                    mnm_scrib.gameObject.SetActive(true);
                    break;
            }
            playerKart.audioSource.PlayOneShot(scribbleSound);
            playerKart.hasItem = false;
            manager.m_TimeManager.AdjustTime(60);
            manager.deliveredObjects++;
            Debug.Log("item delivered");
        }
    }
}
