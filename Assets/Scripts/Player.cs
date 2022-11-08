using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public PlayerMovement pMovement;
    public PlayerAnimation pAnimation;

    private Camera mainCam;

    void Awake() {
        pMovement = GetComponent<PlayerMovement>();
        pAnimation = GetComponent<PlayerAnimation>();

        if (!pMovement || !pAnimation) Debug.LogError("Initialization Failed in Player.cs");
    }
    void Start() {
        mainCam = Camera.main;
        mainCam.GetComponent<FollowTarget>()?.SetTarget(transform);
    }
}