using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour {
    public string targetTag;
    public bool triggerableOnlyOnce = false;
    private bool _hasAlreadyTriggered = false;
    public UnityEvent OnTriggerEnterEvents;
    public UnityEvent OnTriggerExitEvents;

    void OnTriggerEnter2D(Collider2D other) {
        if (!IsAbleToTrigger()) return;
        if (!other.CompareTag(targetTag)) return;
        OnTriggerEnterEvents.Invoke();
    }
    void OnTriggerExit2D(Collider2D other) {
        if (!IsAbleToTrigger()) return;
        if (!other.CompareTag(targetTag)) return;
        OnTriggerExitEvents.Invoke();
    }

    private bool IsAbleToTrigger() {
        if (triggerableOnlyOnce && _hasAlreadyTriggered) return false;
        _hasAlreadyTriggered = true;
        return true;
    }
}