using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public List<AudioClip> normalSounds = new List<AudioClip>();
    public List<AudioClip> stickySounds = new List<AudioClip>();
    public List<AudioClip> collectSounds = new List<AudioClip>();

    private float gameTimer = 0f;
    private float score;
    private int AmountOfWallsHit;
    private int TimesThrown;
    private float collectiblesCollected = 0f;
    public Text scoreText;
    public Text thrownText;
    public Text collectibleText;
    public LaunchingBehavior script;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;

        score = Mathf.Round(gameTimer * 10f) * .1f;
        if (score <= 0)
        {
            score = 0;
        }
        scoreText.text = score.ToString();

        TimesThrown = script.TimesThrown;
        thrownText.text = TimesThrown.ToString();
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
            blockBody.velocity = Vector3.zero;
            transform.GetComponent<AudioSource>().clip = stickySounds[Random.Range(0, stickySounds.Count)];
            transform.GetComponent<AudioSource>().Play();
        }
        if (collision.gameObject.tag == "Collectible")
        {
            transform.GetComponent<AudioSource>().clip = collectSounds[Random.Range(0, collectSounds.Count)];
            transform.GetComponent<AudioSource>().Play();

            collectiblesCollected += 1f;
            Destroy(collision.gameObject);
            collectibleText.text = collectiblesCollected.ToString();
        }
    }
}
