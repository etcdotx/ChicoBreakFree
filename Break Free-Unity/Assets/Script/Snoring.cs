using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snoring : MonoBehaviour
{
   public List<AudioClip> snore = new List<AudioClip>();
    public AudioSource source;
    public bool s = false;

    void Update()
    {
        if (!source.isPlaying) {
            if (!s) {
                StartCoroutine(startplay());
                s = true;
            }
        }
    }

    IEnumerator startplay() {
        source.clip = snore[Random.Range(0, 4)];
        source.Play();
        Debug.Log("!");
        yield return new WaitForSeconds(1f);
        s = false;
    }
}
