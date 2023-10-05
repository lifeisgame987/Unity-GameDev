using UnityEngine;

public class GameManager : StaticInstance<GameManager>{
  
  public static event Action onBeforeStateChanged;
  public static event Action onAfterStateChanged;
  
  private GameState _state;
  
  public void Start() => ChangeState(GameState.Start);
  
  public void ChangeState(GameState newState){
    if(_state == newState) return;
    
    onBeforeStateChanged?.Invoke(newState);
    
    _state = newState;
    
    switch(newState){
      case GameState.Start:
        HandleStart();
        break;
      case GameState.Spawn:
        HandleSpawn();
        break;
      case GameState.Play:
        HandlePlay();
        break;
      case GameState.Win:
        HandleWin();
        break;
      case GameState.Lose:
        HandleLose();
        break;
      default:
        throw new exception(nameOf(newState), newState, null);
    }
    
    onAfterStateChanged?.Invoke(newState);
  }
  
  private void HandleStart(){
    // cutscenes, cinematics
    ChangeState(GameState.Spawn);
  }
  
  private void HandleSpawn(){
    
  }
  
  private void HandleSpawn(){
    
  }
  
  private void HandleSpawn(){
    
  }
    
  private void HandleSpawn(){
    
  }
}

public enum GameState{
  Start,
  Spawn,
  Play,
  Win,
  Lose,
}


// Decoupled GameManager (trial)
using UnityEngine;

public class GM_Tutorial : Monobehaviour{
  
  public static GameManager Instance {get; private set;}
  
  private GameState _state;
  private enum State{
    Start,
    AutoMove,
    MoveRight
    MoveLeft,
    Jump,
    Collect,
    Punch,
    Throw,
  }
  
  private float _countdownTimer = 3f;
  
  private void Awake(){
    Instance = this;
  }
  
  private void Start(){
    _state = State.Start;
  }
  
  private void Update(){
    switch(_state){
      case State.Start:
        _countdownTimer -= Time.deltaTime;
        if(_countdownTimer < 0f){
          _state = State.AutoMove;
        }
        break;
      case State.AutoMove:
        break;
      case State.MoveRight:
        break;
      case State.MoveLeft:
        break;
      case State.Jump:
        break;
      case State.Collect:
        break;
      case State.Punch:
        break;
      case State.Throw:
        break;
    }
  }
}