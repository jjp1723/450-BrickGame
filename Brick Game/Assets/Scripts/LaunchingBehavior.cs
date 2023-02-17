using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchingBehavior : MonoBehaviour
{
    public Transform blockPosition;
    public Rigidbody2D blockBody;
    public SpriteRenderer launchBlockSprite;
    private Vector2 launchForce;
    private Vector2 MousePosition;
    private float divisionCounter = 1f;
    private bool isDividing = false;
    private float gameTimer = 5f;
    public LineRenderer PathofTrag;

    
    // Start is called before the first frame update
    void Start()
    {
        Awake();
    }

    // Update is called once per frame
    void Update()
    {

        gameTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Brick_Game_MVI", LoadSceneMode.Single);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        //Debug.DrawLine(initialBlockPosition, blockPosition.position);

        if (gameTimer >= 2.5f && divisionCounter == 1f)
        {
            launchBlockSprite.color = Color.white;
            LaunchBlock();
        }
        else
        {
            if (isDividing)
            {
                if (divisionCounter <= 600f)
                {
                    blockBody.velocity -= launchForce * 3 / 600;
                    divisionCounter++;
                }
                else
                {
                    divisionCounter = 1f;
                    isDividing = false;
                }
            }

            launchBlockSprite.color = Color.red;
        }
    }

    void LaunchBlock()
    {
        if(Input.GetMouseButton(0))
        {

            MousePosition = ConvertToWorldUnits(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

            launchForce.x = blockPosition.position.x - MousePosition.x;
            launchForce.y = blockPosition.position.y - MousePosition.y;
            PathofTrag.SetPosition(0, blockPosition.position);
            PathofTrag.SetPosition(1, MousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            blockBody.velocity = Vector2.zero;
            blockBody.angularVelocity = 0;
            blockBody.velocity += launchForce * 3;
            gameTimer = 0;
            PathofTrag.SetPosition(0, Vector3.zero);
            PathofTrag.SetPosition(1, Vector3.zero);
            isDividing = true;
        }
    }

    //Open source camera conversion code from https://forum.unity.com/threads/pixel-to-world-unit-conversion.461640/
    public Vector2 WorldUnitsInCamera;
    public Vector2 WorldToPixelAmount;

    public GameObject Camera;

    void Awake()
    {
        //Finding Pixel To World Unit Conversion Based On Orthographic Size Of Camera
        WorldUnitsInCamera.y = Camera.GetComponent<Camera>().orthographicSize * 2;
        WorldUnitsInCamera.x = WorldUnitsInCamera.y * Screen.width / Screen.height;

        WorldToPixelAmount.x = Screen.width / WorldUnitsInCamera.x;
        WorldToPixelAmount.y = Screen.height / WorldUnitsInCamera.y;
    }


    //Taking Your Camera Location And Is Off Setting For Position And For Amount Of World Units In Camera
    public Vector2 ConvertToWorldUnits(Vector2 TouchLocation)
    {
        Vector2 returnVec2;

        returnVec2.x = ((TouchLocation.x / WorldToPixelAmount.x) - (WorldUnitsInCamera.x / 2)) +
        Camera.transform.position.x;
        returnVec2.y = ((TouchLocation.y / WorldToPixelAmount.y) - (WorldUnitsInCamera.y / 2)) +
        Camera.transform.position.y;

        return returnVec2;
    }
}
