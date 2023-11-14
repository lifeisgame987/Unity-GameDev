using UnityEngine;
using UnityEngine.UI;

public class CardUILockTween : MonoBehaviour
{
	[SerializeField] private Loader.Scene currentLevel;
	[SerializeField] private Loader.Scene previousLevel;

	[SerializeField] private Button lockButton;
	[SerializeField] private Button startButton;

	[SerializeField] private GameObject cardBack;
	[SerializeField] private RectTransform cardVisualsHolder;

	private bool isCurrentCardUIOpen;
	private LevelDataTest previousLevelData;

    private void Awake()
    {
        if(currentLevel == Loader.Scene.MainMenu || currentLevel == Loader.Scene.Loading)
		{
			Debug.LogError("Invalid Current Level: " + currentLevel);
			return;
		}
		
		if(previousLevel == Loader.Scene.MainMenu || previousLevel == Loader.Scene.Loading)
		{
			Debug.LogError("Invalid Previous Level: " + previousLevel);
			return;
		}

		isCurrentCardUIOpen = SaverTest.LoadCardUIOpen(currentLevel.ToString());
		previousLevelData = SaverTest.LoadLevelData(previousLevel.ToString());

		startButton.onClick.AddListener(() =>
		{
			Loader.Load(currentLevel);
		});

		if(isCurrentCardUIOpen)
		{
			lockButton.gameObject.SetActive(false);
			cardBack.SetActive(false);
			cardVisualsHolder.rotation = Quaternion.identity;
			startButton.gameObject.SetActive(true);
			return;
		}

		startButton.gameObject.SetActive(false);

		lockButton.onClick.AddListener(() =>
		{
			if (previousLevelData.IsLevelCompleted)
			{
				SaverTest.SaveCardUIOpen(currentLevel.ToString(), true);
				GetComponent<CardUITweenTest>().enabled = true;
			}
		});
    }

    private void Start()
    {
		if (isCurrentCardUIOpen) return;

		if(previousLevelData.IsLevelCompleted)
		{
			ClickLockTween();
		}
		else
		{
			lockButton.GetComponent<RectTransform>().rotation = Quaternion.identity;
		}
    }

	private void ClickLockTween()
	{
        LeanTween.rotateAroundLocal(lockButton.GetComponent<RectTransform>(), Vector3.forward, 20f, 0.5f).setLoopPingPong();
    }
}
