using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float score;
    public Slider slider;
    public Animator anim;
    private int waterCount;
    [SerializeField] GameObject playMenu;

    void Start()
    {
        Time.timeScale = 0;
        playMenu.SetActive(true);
        anim.SetBool("UI", true);

        waterCount = GameObject.FindGameObjectsWithTag("Water").Length;

        slider.GetComponent<Slider>().maxValue= waterCount;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = score;
    }



    public void play()
    {
        playMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
