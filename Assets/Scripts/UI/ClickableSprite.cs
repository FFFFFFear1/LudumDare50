﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickableSprite : MonoBehaviour
{
    [SerializeField] private PlatformType type;
    
    private Button _button;
    private PlatfromUI _sprite;
    private bool _canSpawn;

    private void Awake()
    {
        _button = GetComponent<Button>();
        initButtons();
    }

    private void initButtons()
    {
        EventTrigger downEventTrigger = _button.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((eventData) => {
            _sprite = InventoryUI.instance.GetPlatfromSprite(type);
            });
        downEventTrigger.triggers.Add(entry);

        EventTrigger.Entry entryEnter = new EventTrigger.Entry();
        entryEnter.eventID = EventTriggerType.PointerEnter;
        entryEnter.callback.AddListener((eventData) => {
            _canSpawn = false;
        });
        downEventTrigger.triggers.Add(entryEnter);

        EventTrigger.Entry entryExit = new EventTrigger.Entry();
        entryExit.eventID = EventTriggerType.PointerExit;
        entryExit.callback.AddListener((eventData) => {
            _canSpawn = true;
        });
        downEventTrigger.triggers.Add(entryExit);

        EventTrigger.Entry entryUp = new EventTrigger.Entry();
        entryUp = new EventTrigger.Entry();
        entryUp.eventID = EventTriggerType.PointerUp;
        entryUp.callback.AddListener((eventData) => {
            if (_sprite != null)
            {
                if (_canSpawn)
                {
                    InventoryUI.instance.GetPlatfrom(type, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), _sprite.GetAngle);
                }
                Destroy(_sprite.gameObject);
            }
            });
        downEventTrigger.triggers.Add(entryUp);

    }
}
