using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class LevelGeneratorFromPixelPNG : MonoBehaviour{
  
  public Texture2D map;
  ColorToPrefab[] colorMappings;
  
  void Start(){
    GenerateLevel();
  }
  
  void GenerateLevel(){
    for(int x=0; x<map.width; x++){
      for(int y=0; y<map.height; y++){
        GenerateMap(x, y);
      }
    }
  }
  
  void GenerateMap(int x, int y){
    Color pixelColor = map.GetPixel(x, y);
    
    if(pixelColor.a == 0){
      // Transparent so ignore
      return;
    }
    
    foreach(ColorToPrefab colorMapping in colorMappings){
      if(colorMapping.color.Equals(pixelColor)){
        Vector2 position = new Vector2(x, y);
        Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
      }
    }
  }
}



using System.Collections;
using System.Collections.Generics;
using UnityEngine;

[System.Serializable]
public class ColorToPrefab{
  
  public Color color;
  public GameObject prefab;
  
}


// Some MODIFICATIONS are required for the (map) in Unity to work with the script. CHECK Brakeys!!