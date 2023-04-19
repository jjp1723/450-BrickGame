using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MagneticBehavior : MonoBehaviour
{
    public GameObject launchBall;
    private Transform launchPosition;
    private Transform thisPosition;
    private Vector3 constraints;
    private Rigidbody2D launchBody;
    private Vector3 distance;
    public List<AudioClip> magnetSounds = new List<AudioClip>();
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        launchPosition = launchBall.GetComponent<Transform>();
        thisPosition = this.GetComponent<Transform>();
        constraints = new Vector3(3.5f, 3.5f, 3.5f);
        launchBody = launchBall.GetComponent<Rigidbody2D>();
        audio = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (launchBody.constraints != RigidbodyConstraints2D.FreezeAll) 
        {
            distance = thisPosition.position - launchPosition.position;
            if ((Mathf.Abs(distance.x) < constraints.x) &&
                (Mathf.Abs(distance.y) < constraints.y) &&
                    (Mathf.Abs(distance.z) < constraints.z))
            {
                launchBody.AddForce((distance) * 6);
                if(audio.isPlaying == false)
                {
                    audio.PlayOneShot(magnetSounds[Random.Range(0, magnetSounds.Count)]);
                }
            }
        }
    }
}
