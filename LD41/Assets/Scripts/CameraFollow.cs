﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player1;
    public Transform player2;
    public Transform player3;
    public Transform player4;

    Vector3 targetposition;

    public float zoomFactor = 1f;
    public float followTimeDelta = 1f;
    public float divideOrtho = 1f;
    int playerCount;


    void Start ()
    {
        playerCount = GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>().playerCount;
        player1 = GameObject.Find("Player1").transform;
        if(playerCount > 1) {
            player2 = GameObject.Find("Player2").transform;
        }
        if(playerCount > 2) {
            player3 = GameObject.Find("Player3").transform;
        }
        if(playerCount > 3) {
            player4 = GameObject.Find("Player4").transform;
        }
    }

	void Update () {

        if (playerCount == 1)
        {
            transform.position = new Vector3 (player1.position.x, player1.position.y, transform.position.z);

        }
        else
        {
            FixedCameraFollowSmooth(GetComponent<Camera>(), player1, player2);

        }

        }
    // Follow Two Transforms with a Fixed-Orientation Camera
    public void FixedCameraFollowSmooth(Camera cam, Transform t1, Transform t2)
    { 
        // Midpoint we're after
        Vector3 midpoint = (t1.position + t2.position) / 2f;

        // Distance between objects
        float distance = (t1.position - t2.position).magnitude;

        // Move camera a certain distance
        Vector3 cameraDestination = midpoint - cam.transform.forward * distance * zoomFactor;

        // Adjust ortho size if we're using one of those
        if(cam.orthographic)
        {
            // The camera's forward vector is irrelevant, only this size will matter
            cam.orthographicSize = 2 + distance / divideOrtho;
        }
        // You specified to use MoveTowards instead of Slerp
        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);

        // Snap when close enough to prevent annoying slerp behavior
        if((cameraDestination - cam.transform.position).magnitude <= 0.05f)
            cam.transform.position = cameraDestination;

    }
}
