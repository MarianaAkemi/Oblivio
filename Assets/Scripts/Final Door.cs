using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalDoor : MonoBehaviour
{
    [SerializeField] private Text EnterDoorTXT;
    [SerializeField] Animator transitionAnim;
    public GameObject video;


    private void Start()
    {
        EnterDoorTXT.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            video.SetActive(true);
            Destroy(video, 43f);
            AudioManager.musicSource.Pause();
        }
        if (video == null)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            EnterDoorTXT.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            EnterDoorTXT.gameObject.SetActive(false);
        }
    }
}