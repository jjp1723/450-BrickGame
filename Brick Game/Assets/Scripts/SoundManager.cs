using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> normalSounds = new List<AudioClip>();
    public List<AudioClip> stickySounds = new List<AudioClip>();
    public List<AudioClip> collectSounds = new List<AudioClip>();

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
            //if (transform.GetComponent<AudioSource>().isPlaying == false)
            transform.GetComponent<AudioSource>().clip = normalSounds[Random.Range(0, normalSounds.Count)];
            transform.GetComponent<AudioSource>().Play();
        }
        if (collision.gameObject.tag == "Sticky")
        {
            transform.GetComponent<AudioSource>().clip = stickySounds[Random.Range(0, stickySounds.Count)];
            transform.GetComponent<AudioSource>().Play();
        }
        if (collision.gameObject.tag == "Collectible")
        {
            transform.GetComponent<AudioSource>().clip = collectSounds[Random.Range(0, collectSounds.Count)];
            transform.GetComponent<AudioSource>().Play();
        }
    }
}
