using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memoria : MonoBehaviour
{
    //AudioManager audioManager;
    public GameObject video;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            //audioManager.PlaySFX(audioManager.CollectMemory);
            Destroy(gameObject);
            video.SetActive(true);
            Destroy(video, 10f);
        }
    }
}
