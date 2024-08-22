using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    public static int lifes;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    
    public GameObject HeartsCanva;

    void Awake()
    {
        DontDestroyOnLoad(HeartsCanva);
    }

    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < lifes; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }
}
