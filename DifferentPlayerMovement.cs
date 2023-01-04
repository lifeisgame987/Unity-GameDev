// #1
public class PlayerMovement : MonoBehaviour{
  
  public float speed;
  private Rigidbody2D rb2d;
  
  private string buttonPressed;
  private const string RIGHT = "right";
  private const string LEFT = "left";
  
  void Start(){
    rb2d = GetComponent<RigidBody2D>();
  }
  
  void Update(){
    if(Input.GetKey(KeyCode.rightArrow)){
      buttonPressed = RIGHT;
    }
    else if(Input.GetKey(KeyCode.leftArrow)){
      buttonPressed = LEFT;
    }
    else{
      buttonPressed = null;
    }
  }
  
  void FixedUpdate(){
    if(buttonPressed == RIGHT){
      rb2d.velocity = new Vector2(speed, 0);
    }
    else if(buttonPressed == LEFT){
      rb2d.velocity = new Vector2(-speed, 0);
    }
    else{
      rb2d.velocity = new Vector2(0, 0);
    }
  }
}


// #2
public class PlayerMovement : MonoBehaviour{
  
  public float speed;
  private Rigidbody2D rb2d;
  
  private string buttonPressed;
  private const string RIGHT = "right";
  private const string LEFT = "left";
  
  void Start(){
    rb2d = GetComponent<RigidBody2D>();
  }
  
  void Update(){
    if(Input.GetKey(KeyCode.rightArrow)){
      buttonPressed = RIGHT;
    }
    else if(Input.GetKey(KeyCode.leftArrow)){
      buttonPressed = LEFT;
    }
    else{
      buttonPressed = null;
    }
  }
  
  void FixedUpdate(){
    if(buttonPressed == RIGHT){
      // To get slippery effect
      rb2d.AddForce(new Vector2(speed, 0));
    }
    else if(buttonPressed == LEFT){
      // To get slippery effect
      rb2d.AddForce(new Vector2(-speed, 0));
    }
  }
  // rb2d.AddForce(new Vector2(speed, 0), ForceMode2D.impulse); -> continuous force
}


// #3
public class PlayerMovement : MonoBehaviour{
  
  public float speed;
  
  void Start(){
   
  }
  
  void Update(){
    if(Input.GetKey(KeyCode.rightArrow)){
      transform.position += transform.right * (Time.deltaTime * speed);
    }
    else if(Input.GetKey(KeyCode.leftArrow)){
      transform.position -= transform.right * (Time.deltaTime * speed);
    }
  }
}


// #4
public class PlayerMovement : MonoBehaviour{
  
  public float speed;
  
  void Start(){
   
  }
  
  void Update(){
    if(Input.GetKey(KeyCode.rightArrow)){
      transform.Translate(transform.right * (Time.deltaTime * speed));
    }
    else if(Input.GetKey(KeyCode.leftArrow)){
      transform.Translate(transform.left * (Time.deltaTime * speed));
    }
  }
  // transform.Translate(transform.right * (Time.deltaTime * speed), Space.World); -> Moves along its axis ignoring rotation
}


// #5
public class PlayerMovement : MonoBehaviour{
  
  public float speed;
  private Rigidbody2D rb;
  private Vector2 movement;
  
  void Start(){
    rb = GetComponent<Rigidbody2D>();
  }
  
  void Update(){
    movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
  }
  
  void FixedUpdate(){
    rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
  }
}


// #6 -> MOSTLY USED PLAYER MOVEMENT
public class PlayerMovement : MonoBehaviour{
  
  public float speed;
  
  void Start(){
   
  }
  
  void Update(){
    Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f).normalized;
    transform.position += movement * speed * Time.deltaTime;
  }
}


// .normalized -> To make diagonal move with the                  same speed as X and Y axis move  GetAxis() -> Starts with slow and stops with                  slow                              GetAxisRaw() -> Starts immediately and stops                    immediately
