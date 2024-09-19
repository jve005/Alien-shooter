using UnityEngine;

public class InputActions : MonoBehaviour
{
    private InputSystem_Actions _inputActions;

    public float Horizontal; 
    
    public bool Jump;
    public bool Attack;
    public bool Interact;
    public Vector2 Look;

    public void Update()
    {
        Horizontal = _inputActions.Player.Move.ReadValue<Vector2>().x;
        Attack = _inputActions.Player.Attack.WasPressedThisFrame();
        Jump = _inputActions.Player.Jump.WasPressedThisFrame();
        Look = _inputActions.Player.Look.ReadValue<Vector2>().normalized;
    }

    private void Awake() { _inputActions = new InputSystem_Actions(); }

    private void OnEnable() { _inputActions.Enable(); }

    private void OnDisable() { _inputActions.Disable(); }
}