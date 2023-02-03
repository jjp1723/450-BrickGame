using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchingBehavior : MonoBehaviour
{
    private Vector3 initialBlockPosition;
    public Transform blockPosition;
    public Rigidbody2D blockBody;
    private Vector2 launchForce;
    private Vector2 MousePosition;


    // Start is called before the first frame update
    void Start()
    {
        initialBlockPosition = blockPosition.position;
        Awake();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Brick_Game_MVI", LoadSceneMode.Single);
        }

        Debug.DrawLine(initialBlockPosition, blockPosition.position);
        LaunchBlock();

    }

    void LaunchBlock()
    {
        if(Input.GetMouseButton(0))
        {
            MousePosition = ConvertToWorldUnits(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            blockBody.constraints = RigidbodyConstraints2D.None;
            blockPosition.position =  MousePosition;
            launchForce.x = initialBlockPosition.x - MousePosition.x;
            launchForce.y = initialBlockPosition.y - MousePosition.y;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            launchForce *= 1000;
            blockBody.AddForce(launchForce);
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
