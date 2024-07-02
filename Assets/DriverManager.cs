using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityStandardAssets.Vehicles.Car;

[RequireComponent(typeof(CarController))]
[RequireComponent(typeof(CarAudio))]
public class DriverManager : MonoBehaviour
{
    public GameObject driverSeat;
    public XRLever lever;
    public XRKnob knob;
    public XRGripButton button;
    public float speedCoefficient;
    public UnityEvent<GameObject> onTriggerEvent;

    private bool seatEmpty;
    private bool isOn;
    private Vector3 startPostition;
    private Quaternion rotation;
    private ConstraintSource constrainsSource;

    private CarAudio carAudio;
    private CarController m_Car; // the car controller we want to use

    private void Awake()
    {
        // get the car controller
        m_Car = GetComponent<CarController>();
        carAudio = GetComponent<CarAudio>();

     }


    private void Start()
    {
        seatEmpty = true;
        isOn = false;
        startPostition = transform.position;
        rotation = transform.rotation;
        XRSimpleInteractable simpleInteractable = GetComponent<XRSimpleInteractable>();
        simpleInteractable.activated.AddListener(x => SwitchPostion());
        button.GetComponent<XRGripButton>().selectEntered.AddListener(x => ResetPostition());

        constrainsSource.sourceTransform = driverSeat.transform;
        constrainsSource.weight = 1;

    }
    // Update is called once per frame
    void Update()
    {
        m_Car.Move(knob.value, lever.value ? speedCoefficient : 0f, !lever.value ? speedCoefficient : 0f, 0);

        isOn = lever.value;

        if (isOn)
        {
            carAudio.StartSound();
        }
        else
        {
            carAudio.StopSound();
        }

    }

    void SwitchPostion()
    {
        if (seatEmpty)
        {
            GameObject player = GameObject.FindWithTag("Player");
            //player.GetComponent<DynamicMoveProvider>().enabled = false;

            constrainsSource.weight = 1;

            //player.GetComponent<PositionConstraint>().AddSource(constrainsSource);
            //player.GetComponent<PositionConstraint>().constraintActive = true;

            player.GetComponent<ParentConstraint>().AddSource(constrainsSource);
            player.GetComponent<ParentConstraint>().constraintActive = true;

            seatEmpty = false;

         }
        else
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.transform.position = transform.position + new Vector3(0, 1.5f, 1.5f);

            //player.GetComponent<DynamicMoveProvider>().enabled = true;

            constrainsSource.weight = 0;

            //player.GetComponent<PositionConstraint>().constraintActive = false;
            //player.GetComponent<PositionConstraint>().RemoveSource(0);

            player.GetComponent<ParentConstraint>().constraintActive = false;
            player.GetComponent<ParentConstraint>().RemoveSource(0);

            seatEmpty = true;

            onTriggerEvent.Invoke(gameObject);

        }
    }

    void ResetPostition()
    {
        transform.position = startPostition;
        transform.rotation = rotation;
        knob.value = 0;
        lever.value = false;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}
