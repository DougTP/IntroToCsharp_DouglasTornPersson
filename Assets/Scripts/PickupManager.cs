using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickupManager : MonoBehaviour
{
    private static PickupManager instance;
    [SerializeField] private GameObject pickupPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public static PickupManager GetInstance()
    {
        return instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            GameObject newPickup = Instantiate(pickupPrefab);
            newPickup.transform.position = new Vector3(Random.Range(0f, 5f), 1f, Random.Range(0f, 5f));
        }
    }
}