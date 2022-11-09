using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatManager : MonoBehaviour {
    public static bool cheatsEnabled = true;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            GameManager.AddMoney(5000);
    }
}