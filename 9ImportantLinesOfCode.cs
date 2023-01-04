// #1 Variables
public float speed;
public GameObject player;
private SpriteRenderer rend;
public bool isAlive;


// #2 GetComponent<?>();
private SpriteRenderer rend;

void Start(){
  rend = GetComponent<SpriteRenderer>();
  rend.color = Color.blue;
}


// #3 Instantiate(GameObject, position, rotation);
public GameObject objectToSpawn;

void Start(){
  Instantiate(objectToSpawn, Vector3.zero, Quaternion.identity);
}

NOTE:-- Vector3.zero = (0,0,0)
        Quaternion.identity = No rotation


// #4 Destroy(GameObject);
//    Destroy(GameObject, lifetime);
public float lifetime;

void Start(){
  Destroy(gameObject, lifetime);
}


// #5 Loops
public int noOfTreesToSpawn;
public GameObject trees;

void Start(){
  for(int i=0; i<noOfTreesToSpawn; i++){
    Vector3 randomPos = new Vector3(Random.Range(-11, 11), Random.Range(-4, 5), 0);
    Instantiate(trees, randomPos, Quaternion.identity);
  }
}


// #6 if/else
public GameObject male;
public GameObject female;
public bool isMale;

void Start(){
  if(isMale){
    Instantiate(male, Vector3.zero, Quaternion.identity);
  }
  else{
    Instantiate(female, Vector3.zero, Quaternion.identity);
  }
}


// #7 Input.GetAxisRaw();
public float speed;

void Update(){
  Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
  transform.position = transform.position + playerInput.normalized * speed * Time.deltaTime;
}
 NOTE :-- Time.deltaTime -> To make frame independent


// #8 Vector2.MoveTowards(startPos, target, speed);
public float speed;
public GameObject target;

void Update(){
  transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
}


// #9 OnTriggerEnter2D(Collision2D collision){}
public GameObject particles;

void OnTriggerEnter2D(Collision2D collision){
  if(collision.tag == "Enemy"){
    Instantiate(particles, transform.position, Quaternion.identity);
  }
}

NOTE :- To trigger both must have colliders and one    of them must have RigidBody2D and isTigger on    that has the script attached