using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
    
{
    [Header("General Setup Settings")]
    [Tooltip("how fast ship moves in x axis")]
    [SerializeField] float xControlSpeed = 10f;
    [Tooltip("how fast ship moves in y axis")]
    [SerializeField] float yControlSpeed = 10f;
    [Tooltip("how far player move horizontally")] [SerializeField] float xRange = 5f;
    [Tooltip("how far player move verticallly")] [SerializeField] float yRange = 5f;

    [Header("Screen Based Position tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;


    [Header("Player Input Based tuning")]
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -20f;
    [Header("Additional settings")]
    [SerializeField] float controlYawFactor = -10f;
    [SerializeField] float positionRollFactor = -2f;

    [Tooltip("Array of a game obects that contain lasers")] [SerializeField] GameObject[] lasers;




    float xThrow;
    float yThrow;


    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();

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
     void ProcessFiring()
    {
        // if pusing fire button
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
           
        
    }
    void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;


        }//foreach(ObjectType item in things) here item is named as per our choice as laser // lasers is different
    }
    
}
