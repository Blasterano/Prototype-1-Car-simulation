using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera,hoodCamera;
    public KeyCode camSwitch;
    public string inputid;

    [SerializeField] float speed;
    [SerializeField] float rpm;
    [SerializeField] private float turnSpeed = 50.0f;
    [SerializeField] private float horsePower = 1000.0f;
    [SerializeField] private int wheelOnGround;
    float horizontalInput, forwardInput;

    [SerializeField] GameObject CenterOfMass;
    [SerializeField] List<WheelCollider> wheels;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = CenterOfMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // this is where we get player input
        horizontalInput = Input.GetAxis("Horizontal" + inputid);
        forwardInput = Input.GetAxis("Vertical" + inputid);

        if (IsOnGround())
        {
            // We move the vehicle forward
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            rb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);

            // we turn the vehicle
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.RoundToInt(rb.velocity.magnitude * 3.6f); // for MPH, multiply with 2.237
            rpm = Mathf.Round((speed % 30) * 40);
            speedometerText.text = "Speed: " + speed + "KPH";
            rpmText.text = "rpm: " + rpm;
        }

        if(Input.GetKeyDown(camSwitch))
        {
            mainCamera.gameObject.active = !mainCamera.gameObject.active;
            hoodCamera.gameObject.active = !hoodCamera.gameObject.active;
        }
    }

    bool IsOnGround()
    {
        wheelOnGround = 0;
        foreach(WheelCollider wheel in wheels)
        {
            if (wheel.isGrounded)
                wheelOnGround++;
        }

        if(wheelOnGround==4)
            return true;
        else
            return false;
    }
}
