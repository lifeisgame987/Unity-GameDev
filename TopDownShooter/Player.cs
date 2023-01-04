using System.Collections;
using System.Collections.Generics;
using UnityEngine;

[RequireComponent(typeOf(Rigidbody2D))]
public class  : MonoBehaviour{
  
  public float moveSpeed = 10f;
  private Vector2 movement;
  private Rigidbody2D rb;
  private Vector2 mousePos;
  public GameObject bulletPrefab;
  public Transform firePoint;
  
  void Start(){
    rb = GetComponent<Rigidbody2D>();
  }
  
  void Update(){
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");
    
    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
    if(Input.GetButtonDown("Fire1")){
      Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
  }
  
  void FixedUpdate(){
    rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    
    Vector2 posDir = mousePos - rb.position;
    
    // -90f if sprite is facing up
    float angle = Mathf.Atan2(posDir.y, posDir.x) * Mathf.Rad2Deg -90f;
    
    rb rotation = angle;
  }
}