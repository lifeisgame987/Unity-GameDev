using UnityEngine;

public class CardUITween : MonoBehaviour
{
	[SerializeField] private RectTransform lockButton;
	[SerializeField] private RectTransform cardVisualsHolder;
	[SerializeField] private GameObject cardBack;
	[SerializeField] private GameObject startButton;

    private void Start()
    {
        UnlockTween();
    }

    private void UnlockTween()
    {
        LeanTween.scale(lockButton, new Vector3(1.2f, 1.2f, 0), 0.2f).setOnComplete(StartCardUITween);
    }

    private void StartCardUITween()
    {
        lockButton.gameObject.SetActive(false);
        LeanTween.rotateAroundLocal(cardVisualsHolder, Vector3.up, -90f, 0.5f).setOnComplete(NextHalfCardUITween);
    }

    private void NextHalfCardUITween()
    {
        cardBack.SetActive(false);
        startButton.SetActive(true);
        LeanTween.rotateAroundLocal(cardVisualsHolder, Vector3.up, -90f, 0.5f);
    }
}
