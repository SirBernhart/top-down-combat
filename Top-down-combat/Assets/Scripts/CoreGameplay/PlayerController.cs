using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ShootBehavior shootBehavior;
    [SerializeField] private Movement movementController;

    [Header("Controls")]
    [SerializeField] private InputActionAsset actionAsset;
    private InputAction moveAction;
    private InputAction shootAction;
    private InputAction lookAction;

    private Vector2 lastMoveInput;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;

        InputActionMap playerActionMap = actionAsset.FindActionMap("Player");
        moveAction = playerActionMap.FindAction("Move");
        shootAction = playerActionMap.FindAction("Fire");
        lookAction = playerActionMap.FindAction("Look");

        shootAction.performed += OnShootActionPerformed;
    }

    private void OnShootActionPerformed(InputAction.CallbackContext context)
    {
        Vector2 pointerPos = mainCamera.ScreenToWorldPoint(lookAction.ReadValue<Vector2>());

        Vector2 shootDirection = (pointerPos - (Vector2) transform.position).normalized;
        shootBehavior.Shoot(shootDirection, transform.position);
    }

    private void OnEnable()
    {
        actionAsset.Enable();
    }

    private void Update()
    {
        lastMoveInput = moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        movementController.Move(lastMoveInput);
    }
}
