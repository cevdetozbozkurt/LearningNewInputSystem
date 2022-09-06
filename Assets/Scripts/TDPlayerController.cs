using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDPlayerController : MonoBehaviour
{

    private TDActions controls;

    private void Awake()
    {
        controls = new TDActions();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        controls.Player.Shoot.performed += _ => PlayerShoot();
    }

    private void PlayerShoot()
    {
        Vector2 mousePosition = controls.Player.MousePosition.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    void Update()
    {
        
    }
}
