using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
  PlayerInputs inputs;
  Vector2 movement;
  Rigidbody2D rigidBody;

  [SerializeField]
  int moveSpeed = 10;


  private void Awake() {
    inputs = new PlayerInputs();
    rigidBody = GetComponent<Rigidbody2D>();
  }

  private void OnEnable() {
    inputs.Enable();    
  }

  private void Start() {
  }

  // Update is called once per frame
  void Update()
  {
    PlayerInput();
  }

  private void FixedUpdate() {
    Move();
  }

  private void PlayerInput() {
    movement = inputs.Movement.Paddle.ReadValue<Vector2>();
  }

  private void Move() {
    Vector2 position = CaclulateMovePosition();
    rigidBody.MovePosition(position);
  }

  private Vector2 CaclulateMovePosition() {
    return (Vector2) GetComponent<Transform>().position + movement * (moveSpeed * Time.fixedDeltaTime);
  }

}
