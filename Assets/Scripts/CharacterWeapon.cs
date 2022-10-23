using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingStartPosition;
    [SerializeField] private float lifeSpan = 2f;
    [SerializeField] private TrajectoryLine trajectoryLine;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        bool IsPlayerTurn = playerTurn.IsPlayerTurn();
        trajectoryLine.enabled = IsPlayerTurn;
        if (IsPlayerTurn) 
        {
            //create the directional force used in projectile
            Vector3 force = transform.forward * 700f + transform.up * 300f;
            gameObject.GetComponent<LineRenderer>().enabled = true;
            trajectoryLine.DrawCurvedTrajectory(force, shootingStartPosition.position);
            
            if (Input.GetKeyDown(KeyCode.V))
            {
                TurnManager.GetInstance().TriggerChangeTurn();
                GameObject newProjectile = Instantiate(projectilePrefab);
                newProjectile.transform.position = shootingStartPosition.position;
                newProjectile.transform.rotation = shootingStartPosition.rotation;
                newProjectile.GetComponent<Projectile>().Initialize(force);
                audioSource.Play();
                
                // Destroy the projectile
                Destroy(newProjectile, lifeSpan);
                //Turns off the trajectile renderer after shooting
                gameObject.GetComponent<LineRenderer>().enabled = false;
            }
        }
    }
}
