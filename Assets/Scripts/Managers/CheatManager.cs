using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatManager : MonoBehaviour {
    public GameObject helmet;
    public GameObject gloves;
    public GameObject pants;
    public GameObject shoes;
    public static bool cheatsEnabled = true;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            GameManager.AddMoney(5000);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            helmet.SetActive(!helmet.activeSelf);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            gloves.SetActive(!gloves.activeSelf);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            pants.SetActive(!pants.activeSelf);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            shoes.SetActive(!shoes.activeSelf);
    }
}