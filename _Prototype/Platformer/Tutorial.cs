// Player
using UnityEngine;

public class Player : MonoBehaviour{
  
  [SerializeField] private float _speed;
  [SerializeField] private float _jumpForce;
  
  [SerializeField] private Rigidbody2D _rb;
  [SerializeField] private Transform _groundCheck;
  [SerializeField] private LayerMask _groundLayer;
  
  private float _movementX;
  private bool _jumpPressed;
  private bool _isGrounded;
  private bool _canJump;
  
  private void Update(){
    _movementX = Input.GetAxisRaw("Horizontal");
    _jumpPressed = Input.GeyKeyDown(KeyCode.Space);
    float groundRadius = 2.0f
    _isGrounded = Physics2D.OverlapCircle(_groundCheck, groundRadius, _groundLayer);
  }
  
  private void FixedUpdate(){
    if(GM_Tutorial.Instance.IsAutoMoving()){
      if(_isGrounded)
        _rb.velocity += _speed * Time.fixedDeltaTime;
      return;
    }
    
    _rb.velocity += (_movementX * _speed) * Time.fixedDeltaTime;
    
    if(_canJump && _jumpPressed && _isGrounded){
      _rb.AddForce(Vector2.up * _jumpForce);
    }
  }
  
  private void OnTriggerEnter2D(Collider2D collider){
    Trigger trigger = collider.GetComponent<Trigger>();
    if(trigger != null){
      trigger.OnTrigger();
    }
  }
}

// GM_Tutorial
using UnityEngine;

public class GM_Tutorial : MonoBehaviour{
  
  public static GM_Tutorial Instance {get; private set;}
  
  public event EventHandler OnStateChanged;
  
  private GameState _state;
  public enum State{
    Start,
    AutoMove,
    MoveRight,
    MoveLeft,
    JumpUp,
    JumpDown,
    Collect,
  }
  
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
          OnStateChanged?.Invoke(this, EventArgs.Empty);
        }
        break;
      case State.AutoMove:
        break;
      case State.MoveRight:
        break;
      case State.MoveLeft:
        break;
      case State.JumpUp:
        break;
      case State.JumpDown:
        break;
      case State.Collect:
        break;
    }
  }
  
  public bool IsAutoMoving(){
    return _state == State.AutoMove;
  }
  
  public void ChangeState(State newState){
    if(_state == newState) return;
    _state = newState;
    OnStateChanged?.Invoke(this, EventArgs.Empty);
  }
}

// MoveRightTrigger
using UnityEngine;

public class Trigger : MonoBehaviour{
  
  [SerializeField] private GM_Tutorial.Instance.State _nextState;
  
  private void Start(){
    GM_Tutorial.Instance.OnStateChanged += GM_Tutorial_OnStateChanged;
    Hide();
  }
  
  private void GM_Tutorial_OnStateChanged(Object sender, System.EventArgs e){
    if(GM_Tutorial.Instance.IsAutoMoving()){
      Show();
    }
  }
  
  public void OnTrigger(){
    GM_Tutorial.Instance.ChangeState(_nextState);
    Hide();
  }
  
  private void Show(){
    gameObject.SetActive(true);
  }
  
  private void Hide(){
    gameObject.SetActive(false);
  }
}

// MoveLeftTrigger
using UnityEngine;

public class Trigger : MonoBehaviour{
  
  [SerializeField] private GameState _nextState; // MoveLeft
  [SerializeField] private GameObject _nextTrigger; // JumpTrigger
  
  public void OnTrigger(){
    GM_Tutorial.Instance.ChangeState(_nextState);
    EnableNextTrigger();
    DestroySelf();
  }
  
  private void EnableNextTrigger(){
    _nextTrigger?.SetActive(true);
  }
  
  private void DestroySelf(){
    Destroy(gameObject);
  }
}

// JumpUpTrigger
using UnityEngine;

public class Trigger : MonoBehaviour{
  
  [SerializeField] private GameState _nextState; // JumpUp
  [SerializeField] private GameObject _nextTrigger; // JumpDownTrigger
  
  public void OnTrigger(){
    GM_Tutorial.Instance.ChangeState(_nextState);
    EnableNextTrigger();
    DestroySelf();
  }
  
  private void EnableNextTrigger(){
    _nextTrigger?.SetActive(true);
  }
  
  private void DestroySelf(){
    Destroy(gameObject);
  }
}

// JumpDownTrigger
using UnityEngine;

public class Trigger : MonoBehaviour{
  
  [SerializeField] private GameState _nextState; // JumpDown
  [SerializeField] private GameObject _nextTrigger; // JumpFinishedTrigger
  
  public void OnTrigger(){
    GM_Tutorial.Instance.ChangeState(_nextState);
    EnableNextTrigger();
    DestroySelf();
  }
  
  private void EnableNextTrigger(){
    _nextTrigger?.SetActive(true);
  }
  
  private void DestroySelf(){
    Destroy(gameObject);
  }
}

// JumpFinishedTrigger
using UnityEngine;

public class Trigger : MonoBehaviour{
  
  [SerializeField] private GameState _nextState; // Collect
  [SerializeField] private GameObject _nextTrigger; // 
  
  public void OnTrigger(){
    GM_Tutorial.Instance.ChangeState(_nextState);
    EnableNextTrigger();
    DestroySelf();
  }
  
  private void EnableNextTrigger(){
    _nextTrigger?.SetActive(true);
  }
  
  private void DestroySelf(){
    Destroy(gameObject);
  }
}