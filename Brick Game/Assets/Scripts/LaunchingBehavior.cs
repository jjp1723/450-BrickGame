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
    private float gameTimer = 5f;
    public LineRenderer PathofTrag;
    public int TimesThrown;
    public GameObject pMenu;
    public GameObject throwblock;
    public GameObject lineRender;
    public GameObject gameText;
    public GameObject menuText;
    private bool isPaused = false;
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
            SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
        }
       
        //Debug.DrawLine(initialBlockPosition, blockPosition.position);

        if (gameTimer >= 2.0f && !menuText.activeSelf)
        {
            if (!pMenu.activeSelf)
            {
                launchBlockSprite.color = Color.white;
                lineRender.SetActive(true);
                LaunchBlock();
                blockBody.velocity = Vector3.zero;
                blockPosition.rotation = Quaternion.identity;

            }
            
           

            // issues with pausing while moving so made it so it has to be stopped to pause
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePauseMenu();
            }
        }
        else
        {
            launchBlockSprite.color = Color.red;
            lineRender.SetActive(false);
        }
    }

    void LaunchBlock()
    {
        if(Input.GetMouseButton(0))
        {
            MousePosition = ConvertToWorldUnits(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            blockBody.constraints = RigidbodyConstraints2D.None;
            /*
            if (blockPosition.position.x <= -7) 
            {
                blockPosition.position = new Vector2(-7, blockPosition.position.y);
            }
            else if (blockPosition.position.x > -1)
            {
                blockPosition.position = new Vector2(-1, blockPosition.position.y);
            }

            if (blockPosition.position.y <= -3.5f)
            {
                blockPosition.position = new Vector2(blockPosition.position.x, -3.5f);
            }
            else if (blockPosition.position.y > 0)
            {
                blockPosition.position = new Vector2(blockPosition.position.x, 0);
            }
            */
            launchForce.x = MousePosition.x - blockPosition.position.x;
            launchForce.y = MousePosition.y - blockPosition.position.y;
            PathofTrag.SetPosition(0, blockPosition.position);
            PathofTrag.SetPosition(1, MousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            blockBody.velocity = Vector3.zero;
            blockBody.angularVelocity = 0;
            launchForce *= 1000;
            blockBody.AddForce(launchForce);
            gameTimer = 0;
            PathofTrag.SetPosition(0, Vector3.zero);
            PathofTrag.SetPosition(1, Vector3.zero);
            TimesThrown++;
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

    // Toggles the pause menu on and off
    public void TogglePauseMenu()
    {
        if (isPaused)
        {
            isPaused = false;
            pMenu.SetActive(isPaused);
            throwblock.SetActive(!isPaused);
            lineRender.SetActive(false);
            gameText.SetActive(!isPaused);
            gameTimer = 1.6f;
            
        }
        else
        {
            isPaused = true;
            pMenu.SetActive(isPaused);
            throwblock.SetActive(!isPaused);
            lineRender.SetActive(!isPaused);
            gameText.SetActive(!isPaused);
        }
    }
}
