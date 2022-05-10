using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
    
{
    [SerializeField] float xControlSpeed = 10f;
    [SerializeField] float yControlSpeed = 10f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;

    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlYawFactor = -10f;

    [SerializeField] float positionRollFactor = -2f;
    [SerializeField] float controlRollFactor = -20f;




    float xThrow;
    float yThrow;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();

    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yawDueTOControlPosition = xThrow * controlYawFactor;

        float rollDueTOPosition = transform.localPosition.x * positionRollFactor;
        float rollDuetoControlPosition = xThrow * controlRollFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow; // PositiononScreen is coupled with pitch and yaw

        float yaw = yawDueToPosition + yawDueTOControlPosition; // PositiononScreen is coupled with pitch and yaw

        float roll = rollDueTOPosition + rollDuetoControlPosition; // control throw  is coupled with pitch and roll

        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);    // x= pitch , y = yaw , z =roll
    }
     void ProcessTranslation()
    {
         xThrow = Input.GetAxis("Horizontal");
         yThrow = Input.GetAxis("Vertical");


        float xOffset = xThrow * Time.deltaTime * xControlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * yControlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampedYPos = Mathf.Clamp(rawYPos, -yRange + 1f, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
