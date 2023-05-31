using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BreakoutInterfaceManager : MonoBehaviour
{

  [SerializeField]
  TMP_Text livesCounter;

  [SerializeField]
  TMP_Text scoreCounter;
  
  public void UpdateLives(int _value) {
    this.livesCounter.SetText( $"Lives: {_value.ToString()}");
  }

  public void UpdateScore(int _value) {
    this.scoreCounter.SetText( $"Score: {_value.ToString()}");
  }

  public void ResetGame(int _startLives) {
    this.UpdateLives(_startLives);
    this.UpdateScore(0);
  }

}
