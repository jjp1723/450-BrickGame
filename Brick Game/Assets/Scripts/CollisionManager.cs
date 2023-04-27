using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionManager : MonoBehaviour
{
    public List<AudioClip> normalSounds = new List<AudioClip>();
    public List<AudioClip> stickySounds = new List<AudioClip>();
    public List<AudioClip> collectSounds = new List<AudioClip>();
    public List<AudioClip> bouncySounds = new List<AudioClip>();
    public List<AudioClip> magnetSounds = new List<AudioClip>();


    private float score;
    private int AmountOfWallsHit;
    private int TimesThrown;
    public float parScore = 0f;
    private float collectibleScore = 0f;
    public Text scoreText;
    public Text thrownText;
    public Text collectibleText;
    public LaunchingBehavior script;
    private Transform thisPosition;

    public Rigidbody2D blockBody;

    // Start is called before the first frame update
    void Start()
    {
        thisPosition = this.GetComponent<Transform>();
        score = parScore;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        TimesThrown = script.TimesThrown;

        score = parScore - TimesThrown;
        scoreText.text = score.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            transform.GetComponent<AudioSource>().PlayOneShot(normalSounds[Random.Range(0, normalSounds.Count)]);
        }
        if (collision.gameObject.tag == "Sticky")
        {
            blockBody.velocity = Vector3.zero;
            blockBody.constraints = RigidbodyConstraints2D.FreezeAll;
            transform.GetComponent<AudioSource>().PlayOneShot(stickySounds[Random.Range(0, stickySounds.Count)]);
        }
        if (collision.gameObject.tag == "Collectible")
        {
            transform.GetComponent<AudioSource>().PlayOneShot(collectSounds[Random.Range(0, collectSounds.Count)]);

            collectibleScore += 1f;
            Destroy(collision.gameObject);
            collectibleText.text = collectibleScore.ToString();
        }
        if (collision.gameObject.tag == "Bouncy")
        {
            transform.GetComponent<AudioSource>().PlayOneShot(bouncySounds[Random.Range(0, bouncySounds.Count)]);
        }
        //if (collision.gameObject.tag == "Magnet")
        //{
        //    blockBody.AddForce((collision.gameObject.GetComponent<Transform>().position - thisPosition.position));
        //}
    }
}
