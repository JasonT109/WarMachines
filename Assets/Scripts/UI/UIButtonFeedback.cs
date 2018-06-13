using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class UIButtonFeedback : MonoBehaviour, IDeselectHandler, ISelectHandler //This Interface is required to receive OnDeselect callbacks.
{
    public Image InteractIcon;
    public bool InitialState = false;
    public bool ignored = false;

    void Start()
    {
        SetIconState(InitialState);
    }

    void OnEnable()
    {
        SetIconState(InitialState);
    }

    public void OnFirstSelect()
    {
        SetIconState(true);
    }

    private void GetIcon()
    {
        Image[] InteractIcons = gameObject.GetComponentsInChildren<Image>(true);
        if (InteractIcons.Length > 1)
            InteractIcon = InteractIcons[1];
    }

    private void SetIconState(bool state)
    {
        if (InteractIcon == null)
            GetIcon();
        if (InteractIcon != null && !ignored)
            InteractIcon.gameObject.SetActive(state);
    }

    public void OnSelect(BaseEventData data)
    {
        SetIconState(true);
    }

    public void OnDeselect(BaseEventData data)
    {
        SetIconState(false);
    }
}