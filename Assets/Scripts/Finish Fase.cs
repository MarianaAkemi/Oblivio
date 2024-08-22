using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishFase : MonoBehaviour
{
    [SerializeField] private Text EnterDooraTXT;
    [SerializeField] Animator transitionAnim;
    public int sceneBuildIndex;


    private void Start()
    {
        EnterDooraTXT.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("Next Level");
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            EnterDooraTXT.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            EnterDooraTXT.gameObject.SetActive(false);
        }
    }
}
