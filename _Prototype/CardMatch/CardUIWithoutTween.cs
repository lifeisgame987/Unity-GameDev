using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
	[SerializeField] private Loader.Scene currentLevel;
	[SerializeField] private Loader.Scene previousLevel;

	[SerializeField] private GameAssetsSO gameAssetsSO;

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
		startButton.onClick.AddListener(() =>
		{
			Loader.Load(currentLevel);
		});
  }

  private void OnEnable()
  {
    LoadSavedLevelData();
		CheckPreviousLevelCompleted();
  }
    
	private void LoadSavedLevelData()
	{
		currentLevelData = Saver.LoadLevelData(currentLevel.ToString());
		previousLevelData = Saver.LoadLevelData(previousLevel.ToString());
	}

	private void CheckPreviousLevelCompleted()
	{
		if(previousLevelData.IsLevelCompleted)
		{
			LevelOpen();
			SetLevelStarValues();
		}
		else
		{
			LevelClosed();
		}
	}

  private void LevelOpen()
	{
		cardBack.SetActive(false);
		starHolder.SetActive(true);
		startButton.gameObject.SetActive(true);
	}

	private void LevelClosed()
	{
    cardBack.SetActive(true);
    starHolder.SetActive(false);
    startButton.gameObject.SetActive(false);
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

    if(currentLevelData.NumberOfStars == 3)
		{
      starThree.sprite = gameAssetsSO.starFull;
    }
  }
}
