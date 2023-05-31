using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutManager : MonoBehaviour
{

  public static BreakoutManager Instance;

  [SerializeField]
  BreakoutInterfaceManager interfaceManager;

  [SerializeField]
  World world;

  [SerializeField]
  int startLives;
  int score=0;

  private void Awake() {
    if(Instance == null) {
    Instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else {
      Destroy(gameObject);
    }
  }

  // Start is called before the first frame update
  void Start()
  {
      this.interfaceManager.ResetGame(startLives); 
  }

  public void UpdateScore(int _value) {
    score+=_value;
    this.interfaceManager.UpdateScore(score);
  }
}
