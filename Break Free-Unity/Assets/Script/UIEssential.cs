using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIEssential : MonoBehaviour
{
    public bool mute = false;
    public float currentvol = 1;
    public Slider slide;
    public GameObject ON;
    public GameObject OFF;
    public float prevValue =1;
    public bool muteBefore = false;
    public void Start()
    {
       currentvol = GameManager.Vol;
          if(GameManager.mute){
         mute = true;
          Mute();
         ON.SetActive(false);
          OFF.SetActive(true);
          }else{
          mute =false;
          Unmute();
          ON.SetActive(true);
          OFF.SetActive(false);
          }
        slide.value = currentvol;
    }


    public void timeChange() {
        Time.timeScale = 1;
    }

    public void timePause() {
        Time.timeScale = 0;
    }

    public void changeScene(int index) {
        SceneManager.LoadScene(index);
    }

    public void Quit() {
        Application.Quit();
    }

    public void ChangeVol(float newValue)
    {
        float newVol = AudioListener.volume;
        newVol = newValue;
        if (!mute)
        {
            AudioListener.volume = newVol;
        }
        currentvol = newVol;
        GameManager.Vol= currentvol;
    }

    public void Mute() {
        AudioListener.volume = 0;
        mute = true;
        GameManager.mute = true;
    }

    public void Unmute() {
        AudioListener.volume = currentvol;
        mute = false;
        GameManager.mute = false;

    }

    public void resetApply() {
        ChangeVol(prevValue);
        slide.value = prevValue;
        if (muteBefore)
        {
            Mute();
            ON.SetActive(false);
            OFF.SetActive(true);
        }
        else {
            Unmute();
            ON.SetActive(true);
            OFF.SetActive(false);
        }
    }

    public void Apply() {
        prevValue = currentvol;
        muteBefore = mute;
    }

    public void Alpha1(Image img) {
        Color tmp = img.color;
        tmp.a = 1f;
        img.color = tmp;
    }

    public void Alpha0(Image img)
    {
        Color tmp = img.color;
        tmp.a = 0f;
        img.color = tmp;
    }
}
