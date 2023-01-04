// transform.Translate(Vector2); -> Continuously move Object to a direction with speed
transform.Translate(Vector2.left * speed * Time.deltaTime);


// Vector2.MoveTowards(Vector2, GameObject || Vector2, float); -> Continuously move Object to other Object or a certain point with speed
Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);


// Collider2D collider = Physics2D.OverlapPoint(Vector2); -> Returns a collider to the given Vector2 point
Collider2D collider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.GetTouch(0)));


// Instantiate(GameObject, Vector2, Vector2); -> Spawns Object prefab on the given position and rotation
Instantiate(gameObjectPrefab, transform.position, Quaternion.identity);


// Destroy(GameObject); -> Destroys the gameObject
Destroy(gameObject);


// Destroy(GameObject, float); -> Destroys the gameObject with lifetime
Destroy(gameObject, lifeTime);


// Collider2D collider = Physics2D.OverlapCircle(Vector2, float, LayerMask); -> Forms an invisible cirle around the given position of any object to the given float radius within specific layers and returns the collider found within the invisible circle;
Collider2D collider = Physics2D.OverlapCircle(groundCheck.position, radius, whatIsGround);


// Collider2D[] collider = Physics2D.OverlapCircleAll(Vector2, float, LayerMask); -> Forms an invisible cirle around the given position of any object to the given float radius within specific layers and returns the list of all colliders found within the invisible circle;
Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, areaOfEffect, whatIsDestructible);


// float distance = Vector2.Distance(Vector2, Vector2); -> Returns the length between two Vectors
float distance = Vector2.Distance(transform
.position, target.position);
float distance = (transform.position - target.position).magnitude;


// transform.Rotate(Vector3 axis); -> Rotates the object along the Vector3 direction
transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);


// transform.RotateAround(Vector3 point, Vector3 axis, float degrees); -> Rotates around a point either continuous or by keyboard keys;
transform.RotateAround(Vector3.zero, Vector3.forward, Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime);


// rigidbody2d.AddTorque(float torque); -> Adds rotational force to the gameObject
rigidbody2d.AddTorque(Input.GetAxisRaw("Horizontal") * speed * Time.fixedDeltaTime);