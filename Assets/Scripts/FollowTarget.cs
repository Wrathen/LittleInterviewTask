using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {
    private Transform target;

    // Base Functions
    void Update() {
        if (!target) return;
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

    // Main Functions
    public void SetTarget(Transform go) { target = go; }
}