// Samyam, Dani -> Uses (extra sprites)
using UnityEngine;

public class Parallax : MonoBehaviour{
  
  [SerializeField] private float _parallaxSpeedX;
  [SerializeField] private float _parallaxSpeedY;

  private Transform _cameraTransform;
  private float _startPositionX, _startPositionY;
  private float _spriteSizeX;

  private void Start(){
    _cameraTransform = Camera.main.transform;
    _startPositionX = transform.position.x;
    _startPositionY = transform.position.y;
    _spriteSizeX = GetComponent<SpriteRenderer>().bounds.size.x;
  }
  
  private void LateUpdate(){
    float relativeDistanceX = _cameraTransform.position.x * _parallaxSpeedX;
    float relativeDistanceY = _cameraTransform.position.y * _parallaxSpeedY;
    transform.position = new Vector3(_startPositionX + relativeDistanceX, _startPositionX + relativeDistanceY, transform.position.z);
    
    // Loop parallax effect
    float cameraRelativeDistance = _cameraTransform.position.x * (1 - _parallaxSpeedX);
    if(cameraRelativeDistance > _startPositionX + _spriteSizeX){
      _startPositionX += _spriteSizeX;
    }
    else if(cameraRelativeDistance < _startPositionX - _spriteSizeX){
      _startPositionX -= _spriteSizeX;
    }
  }
}


// CodeMonkey -> Uses (drawmode = tilemap)
using UnityEngine;

public class Parallax : MonoBehaviour{
  
  [SerializeField] private float _parallaxSpeedX;
  [SerializeField] private float _parallaxSpeedY;
  
  [SerializeField] private float _infiniteHorizontal;
  [SerializeField] private float _infiniteVertical;
  
  private Transform _cameraTransform;
  private Vector3 _lastCameraPosition;
  private float _textureUnitSizeX, _textureUnitSizeY;
  
  private void Start(){
    _cameraTransform = Camera.main.transform;
    _lastCameraPosition = _cameraTransform.position;
    Sprite sprite = GetComponent<SpriteRenderer>().sprite;
    Texture2D texture = sprite.texture;
    _textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    _textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
  }
  
  private void Update(){
    Vector3 deltaMovement = _cameraTransform.position - _lastCameraPosition;
    transform.position += new Vector3(deltaMovement.x * _parallaxSpeedX, deltaMovement.y * _parallaxSpeedY);
    _lastCameraPosition = _cameraTransform.position;
    
    // Loop parallax effect
    if(_infiniteHorizontal){
      float deltaPositionX = _cameraTransform.position.x - transform.position.x;
      if(Mathf.Abs(deltaPositionX) >= _textureUnitSizeX){
        float offsetPositionX = deltaPositionX % _textureUnitSizeX;
        transform.position = new Vector3(_cameraTransform.position.x + offsetPositionX, transform.position.y);
      }
    }
    if(_infiniteVertical){
      float deltaPositionY = _cameraTransform.position.y - transform.position.y;
      if(Mathf.Abs(deltaPositionY) >= _textureUnitSizeY){
        float offsetPositionY = deltaPositionY % _textureUnitSizeY;
        transform.position = new Vector3(transform.position.x, _cameraTransform.position.y + offsetPositionY);
      }
    }
  }
}