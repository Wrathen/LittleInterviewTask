using UnityEngine;

public class Bow : MonoBehaviour {
    public GameObject arrowPrefab;
    public Transform anchorPoint;
    public float distanceFromAP = 1f;
    public float offsetRotation = 45f;

    public float attackSpeed = 0.17f;
    private float nextAttackTime = 0;

    private float angleBetweenMouse;
    private Vector3 mousePos;
    private Vector3 screenPos;

    void Update() {
        mousePos = Input.mousePosition;
        screenPos = GameManager.GetCamera().WorldToScreenPoint(anchorPoint.position);
        angleBetweenMouse = Mathf.Atan2(mousePos.y - screenPos.y, mousePos.x - screenPos.x);

        RotateAroundAnchor();
        LookAtMouse();
        
        if (Input.GetMouseButton(0)) Shoot();
    }

    void Shoot() {
        if (nextAttackTime > Time.time) return;
        nextAttackTime = Time.time + attackSpeed;
        Instantiate(arrowPrefab, transform.position, transform.rotation);
    }
    void RotateAroundAnchor() {
        transform.localPosition = new Vector3(Mathf.Cos(angleBetweenMouse) * distanceFromAP,
            Mathf.Sin(angleBetweenMouse) * distanceFromAP, -4);
    }
    void LookAtMouse() {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,            
            transform.localEulerAngles.y, 
            angleBetweenMouse * Mathf.Rad2Deg + offsetRotation);
    }
}