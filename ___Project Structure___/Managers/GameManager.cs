// Most appropriate GameManager structure
using UnityEngine;

public class GameManager : MonoBehaviour{
  
  public static GameManager Instance {get; private set;}
  
  public event EventHandler OnStateChanged;
  public event EventHandler OnGamePaused;
  public event EventHandler OnGameResumed;
  
  private State _state;
  public enum State{
    Start,
    CountdownTimer,
    GamePlay,
    GameOver
  }
  
  private float _countdownTimer = 3f;
  private bool _isGamePaused = false;
  
  private void Awake(){
    Instance = this;
  }
  
  private void Start(){
    InputManager.Instance.OnPauseAction += InputManager_OnPauseAction;
    ChangeState(State.Start);
  }
  
  private void Update(){
    switch(_state){
      case State.Start:
        break;
      case State.CountdownTimer:
        _countdownTimer -= Time.deltaTime;
        if(_countdownTimer < 0f){
          _state = State.GamePlay;
          OnStateChanged?.Invoke(this, EventArgs.Empty);
        }
        break;
      case State.GamePlay:
        break;
      case State.GameOver:
        break;
      default:
        throw new exception(nameOf(_state), _state, null);
    }
  }
  
  private void InputManager_OnPauseAction(Object sender, System.EventArgs e){
    TogglePause();
  }
  
  public bool IsStartState(){
    return _state == State.Start;
  }
  
  public bool IsCountdownTimerState(){
    return _state == State.CountdownTimer;
  }

  public bool IsGamePlayState(){
    return _state == State.GamePlay;
  }
  
  public bool IsGameOverState(){
    return _state == State.GameOver;
  }
  
  public void ChangeState(State newState){
    if(_state == newState) return;
    _state = newState;
    OnStateChanged?.Invoke(this, EventArgs.Empty);
  }
  
  private void TogglePause(){
    _isGamePaused = !_isGamePaused;
    if(_isGamePaused){
      Time.timeScale = 0f;
      OnGamePaused?.Invoke(this, EventArgs.Empty);
    }
    else{
      Time.timeScale = 1f;
      OnGameResumed?.Invoke(this, EventArgs.Empty);
    }
    // As the game play uses pause/resume system, scene changes will
    // make the game potentially stay in pause, so we have to manually
    // resume it in the first Scene (MainMenuScene)
  }
  
  private void OnDestroy(){
    InputManager.Instance.OnPauseAction -= InputManager_OnPauseAction;
  }
}





// Tarodev
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
