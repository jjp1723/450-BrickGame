using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> sounds = new List<AudioClip>();

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            if(transform.GetComponent<AudioSource>().isPlaying == false)
            {
                transform.GetComponent<AudioSource>().clip = sounds[Random.Range(0, sounds.Count)];
                transform.GetComponent<AudioSource>().Play();
            }
        }
    }
}
