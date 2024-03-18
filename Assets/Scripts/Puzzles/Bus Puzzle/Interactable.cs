using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    Outline outline;
    public string message;

    public UnityEvent onInteraction;

    [SerializeField] private bool _isInteracted;

    public bool isInteracted
    {
        get { return _isInteracted; }
        private set { _isInteracted = value; }
    }

    private void Start()
    {
        outline = GetComponent<Outline>();
        DisableOutline();
    }

    public void Interact()
    {
        onInteraction.Invoke();
        isInteracted = true;
    }

    public void SetInteracted(bool value)
    {
        _isInteracted = value;
    }

    public void DisableOutline()
    {
        outline.enabled = false;
    }

    public void EnableOutline()
    {
        outline.enabled = true;
    }

}
