using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helm:MonoBehaviour
{
    public int nearZero;

    public int wheelNearZero;
    //Adjust the sensitivity of the wheel
    public float wheelSensitivity;

    //How close Federico needs to be to sucessfully drop mail
    public int pigeonDropDistance;

    public GameObject ship;
    private Vector3 initialMousePos;
    private Text speedometer;
    private GameObject helm;
    private GameObject destination;
    private GameObject playspace;

    private SfxPlayer sPlayer;

    public void Awake()
    {
        ship = GameObject.Find("Federico");
        playspace = GameObject.FindWithTag("PlaySpace");
        sPlayer = GameObject.Find("SfxPlayer").GetComponent<SfxPlayer>();
        //speedometer = GameObject.Find("Speedometer").GetComponent<Text>();
        //helm = GameObject.Find("HelmPanel");
    }

    public void Start()
    {
        //helm.SetActive(false);
    }

    public void SetThrottle(Slider slider)
    {
        //Zeroes out the throttle if it was set near zero
        if (slider.value < nearZero && slider.value > -nearZero)
        {
            slider.value = 0;
        }

        //Get the new setting and report it to ShipController        
        ship.GetComponent<ShipController>().throttle = slider.value / 10;
        //Debug.Log(ship.GetComponent<ShipController>().throttle + " " + slider.value);

        SetSpeedometer(Mathf.RoundToInt(Mathf.Abs(slider.value) * 10));
    }

    public void ReleaseWheel(Image image)
    {
        //Snaps the wheel to center if it's close enough to zero
        if (image.transform.rotation.eulerAngles.z < wheelNearZero || image.transform.rotation.eulerAngles.z > 360-wheelNearZero)
        {
            image.transform.rotation = Quaternion.identity;
            //Get the new setting and report it to ShipController
            //shipTransform.rotation = Quaternion.identity;
            ship.GetComponent<ShipController>().shipTransform.rotation = Quaternion.identity;
        }
    }

    public void TurnWheel(Image image)
    {
        Vector3 currMousePos = Input.mousePosition;

        float angle = wheelSensitivity * Vector2.Angle(initialMousePos-image.transform.position, currMousePos-image.transform.position);

        Vector3 rotationVec;

        if (Vector3.Cross(initialMousePos - image.transform.position, currMousePos - image.transform.position).z < 0)
        {
            rotationVec = new Vector3(0F, 0F, -angle);
        }
        else
        {
            rotationVec = new Vector3(0F, 0F, angle);
        }

        image.transform.Rotate(rotationVec);
        //Get the new setting and report it to ShipController
        //shipTransform.rotation = rotationVec???
        ship.GetComponent<ShipController>().shipTransform.rotation = image.transform.rotation;

        initialMousePos = currMousePos;
    }

    public void GrabWheel()
    {
        initialMousePos = Input.mousePosition;
    }

    public void SetSpeedometer(int speed)
    {
        //speedometer.text = speed.ToString("000");
    }

    public void PigeonDrop()
    {
        destination = GameObject.FindWithTag("Destination");
        if ((ship.transform.position - destination.transform.position).magnitude < pigeonDropDistance)
        {
            sPlayer.PlaySoundEffect("mail drop");
            //Untag the current planet so that when the new planet spawns, we point to it instead
            destination.tag = "Untagged";

            //Flags the current destination and all asteroids for deletion
            destination.GetComponent<Destroyer>().destroy_offscreen = true;
            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
            foreach (GameObject asteroid in asteroids){
                asteroid.GetComponent<Destroyer>().destroy_offscreen = true;
            }

            //Spawn the planet and asteroids for the next round
            playspace.GetComponent<PlaySpace_Controller>().Next_Round();
            

            Debug.Log("Mail Delivered!");
        }
        else
        {
            Debug.Log("Missed." + ship.transform.position + " " + destination.transform.position);
        }
    }
}
