using UnityEngine;

public class SoundManager : MonoBehaviour{
  
  [SerializeField] private AudioClipsSO _audioClipsSO;
  
  private void Start(){
    // Subscribe to events fired by other scripts that required to play sound
  }
  
  private void PlaySound(AudioClip clip, Vector3 position, float volume = 1f){
    AudioSource.PlayClipAtPoint(clip, position, volume);
  }
}