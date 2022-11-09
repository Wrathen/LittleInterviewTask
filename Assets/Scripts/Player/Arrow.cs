using UnityEngine;

public class Arrow : MonoBehaviour {
    public float speed = 5f;
    public float angle = 0f;
    public float angleOffset = 135f;
    public float duration = 3f;
    private float deathTimer = 0f;

    void Start() {
        angle = (transform.eulerAngles.z + angleOffset) * Mathf.Deg2Rad;
        deathTimer = Time.time + duration; 
    }
    void Update() {
        if (Time.time > deathTimer) {
            Destroy(gameObject);
            return;
        }

        angle = (transform.eulerAngles.z + angleOffset) * Mathf.Deg2Rad;
        transform.position += new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * speed * GlobalStats.projectileSpeedModifier * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Enemy")) {
            col.GetComponent<Enemy>()?.TakeDamage();
            Destroy(gameObject);
        }
    }
}