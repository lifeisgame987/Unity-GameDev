using System.Collections;
using System.Collections.Generics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour{
  
  public float moveSpeed;
  private Rigidbody2D rb;
  private float movementX;
  private float movementY;
  public GameObject playerProjectile;
  private float timeBtwSpawn;
  public float startTimeBtwSpawn;
  public float health;
  public Slider slider;
  
  void Start(){
    rb = GetComponent<Rigidbody2D>();
    rb.gravityScale = 0f;
    timeBtwSpawn = startTimeBtwSpawn;
  }
  
  void Update(){
    if(health <= 0){
      Destroy(gameObject);
      Invoke("ReloadScene", 5f);
    }
    slider.value = health;
    movementX = Input.GetAxisRaw("Horizontal");
    movementY = Input.GetAxisRaw("Vertical");
    
    if(timeBtwSpawn <= 0f){
      if(Input.GetMouseButtonDow(0)){
        Instantiate(playerProjectile, transform.position, Quaternion.identity);
        timeBtwSpawn = startTimeBtwSpawn;
      }
    }
    else{
      timeBtwSpawn -= startTimeBtwSpawn;
    }
  }
  
  void FixedUpdate(){
    rb.velocity = new Vector2(movementX, movementY) * moveSpeed * Time.fixedDeltaTime;
  }
  
  private void ReloadScene(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
}