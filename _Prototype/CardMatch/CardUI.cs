// huge bug with respect to parent event that leads to child event timings wrong
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
	[SerializeField] private Loader.Scene currentLevel;
	[SerializeField] private Loader.Scene previousLevel;

	[SerializeField] private GameAssetsSO gameAssetsSO;

	[SerializeField] private Button lockButton;
	[SerializeField] private RectTransform cardVisualsHolder;
	[SerializeField] private GameObject cardBack;
	[SerializeField] private GameObject starHolder;
	[SerializeField] private Image starOne;
	[SerializeField] private Image starTwo;
	[SerializeField] private Image starThree;
	[SerializeField] private Button startButton;

	private LevelData currentLevelData;
	private LevelData previousLevelData;

	private bool isLockClicked;

    private void Awake()
    {
        LoadSavedLevelData();
        LoadSavedLockClicked();

        lockButton.onClick.AddListener(() =>
		{
			//Debug.Log(previousLevel + " awake: " + "islevelcompleted: " + !previousLevelData.IsLevelCompleted);
			if (!previousLevelData.IsLevelCompleted) return;

			Saver.SaveLevelLockClicked(currentLevel.ToString(), true);
			Menu_Manager.Instance.StartLockTween();
        });

		startButton.onClick.AddListener(() =>
		{
			Loader.Load(currentLevel);
		});
    }

    private void OnEnable()
    {
        LoadSavedLevelData();
        LoadSavedLockClicked();
		CheckPreviousLevelCompleted();
    }

	private void Start()
	{
        Menu_Manager.Instance.OnLockLoopTweenStarted += Menu_Manager_OnLockLoopTweenStarted;
		Menu_Manager.Instance.OnLockTweenStarted += Menu_Manager_OnLockTweenStarted;
		Debug.Log("subscribed");
	}

    private void Menu_Manager_OnLockLoopTweenStarted(object sender, System.EventArgs e)
    {
        StartLockLoopTween();
    }

    private void Menu_Manager_OnLockTweenStarted(object sender, System.EventArgs e)
    {
		StartUnlockTween();
    }

	private void LoadSavedLevelData()
	{
		currentLevelData = Saver.LoadLevelData(currentLevel.ToString());
		previousLevelData = Saver.LoadLevelData(previousLevel.ToString());

		/*Debug.Log(currentLevel + " isLockClicked: " + isLockClicked + " stars: " + currentLevelData.NumberOfStars);
		Debug.Log(previousLevel + " islevelcompleted: " + previousLevelData.IsLevelCompleted);*/
	}

	private void LoadSavedLockClicked()
	{
		isLockClicked = Saver.LoadLevelLockClicked(currentLevel.ToString());
	}

	private void CheckPreviousLevelCompleted()
	{
		if(previousLevelData.IsLevelCompleted)
		{
			Debug.Log("islockclickedOnce " + isLockClicked);
			if (isLockClicked)
			{
				Debug.Log("card opened");
				LevelOpen();
				SetLevelStarValues();
			}
			else
			{
				Debug.Log("lock tweening");
				Menu_Manager.Instance.StartLockLoopTween();
			}
		}
		else
		{
			LevelClosed();
		}
	}

	private void StartUnlockTween()
	{
		lockButton.onClick.RemoveAllListeners();
        //setOnComplete(RevealLevelPartOne);
        LeanTween.scale(lockButton.gameObject, new Vector3(1.2f, 1.2f, 0), 0.2f).setOnComplete(RevealLevelPartOne);
    }

    private void RevealLevelPartOne()
	{
		lockButton.gameObject.SetActive(false);
        //setOnComplete(RevealLevelPartTwo);
        LeanTween.rotateAroundLocal(cardVisualsHolder, Vector3.up, -90f, 0.5f).setOnComplete(RevealLevelPartTwo);
    }

    private void RevealLevelPartTwo()
	{
		cardBack.SetActive(false);
		starHolder.SetActive(true);
		startButton.gameObject.SetActive(true);
        //LeanTween
        LeanTween.rotateAroundLocal(cardVisualsHolder, Vector3.up, -90f, 0.5f);
    }

    private void LevelOpen()
	{
		lockButton.gameObject.SetActive(false);
		cardVisualsHolder.rotation = Quaternion.identity;
		cardBack.SetActive(false);
		starHolder.SetActive(true);
		startButton.gameObject.SetActive(true);
	}

	private void LevelClosed()
	{
        lockButton.gameObject.SetActive(true);
		lockButton.GetComponent<RectTransform>().rotation = Quaternion.identity;
		cardVisualsHolder.rotation = Quaternion.Euler(0, -180f, 0);
        cardBack.SetActive(true);
        starHolder.SetActive(false);
        startButton.gameObject.SetActive(false);
    }

	private void StartLockLoopTween()
	{
		lockButton.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 10f);
        //LeanTween
        LeanTween.rotateAroundLocal(lockButton.GetComponent<RectTransform>(), Vector3.forward, 20f, 0.5f).setLoopPingPong();
    }

    private void SetLevelStarValues()
	{
		if(currentLevelData.NumberOfStars == 1)
		{
			starOne.sprite = gameAssetsSO.starFull;
		}
		
		if(currentLevelData.NumberOfStars == 2)
		{
            starTwo.sprite = gameAssetsSO.starFull;
        }

        if (currentLevelData.NumberOfStars == 3)
		{
            starThree.sprite = gameAssetsSO.starFull;
        }
    }
}
