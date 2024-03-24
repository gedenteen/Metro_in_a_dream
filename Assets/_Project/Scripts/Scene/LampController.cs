using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    [Header("Changeable values")]
    public float delayForDeactivatingLamp = 3f;

    [Header("Links to objects")]
    [SerializeField] private GameObject[] lamps;

    private float timer;

    private void Start()
    {
        for (int i = 0; i < lamps.Length; i++)
        {
            lamps[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (timer > 0f)
        {
            timer = Mathf.Clamp(timer - Time.deltaTime, 0f, delayForDeactivatingLamp);
            if (timer == 0f)
            {
                for (int i = 0; i < lamps.Length; i++)
                {
                    if (lamps[i].activeInHierarchy)
                    {
                        lamps[i].SetActive(false);
                    }
                }
            }

            // Debug.Log($"LampController: Update: timer={timer}");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Debug.Log("LampController: trigger");

        for (int i = 0; i < lamps.Length; i++)
        {
            if (!lamps[i].activeInHierarchy)
            {
                lamps[i].SetActive(true);
            }
        }
        timer = delayForDeactivatingLamp;
    }
}
