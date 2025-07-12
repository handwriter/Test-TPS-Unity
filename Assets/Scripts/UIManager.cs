using System;
using DefaultNamespace;
using GamePush;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIManager : MonoBehaviour
{
	[SerializeField]
	private Canvas UiCanvas;

	[SerializeField]
	private Image healthBarImage;

	[SerializeField]
	private Text remainCountText;

	[SerializeField]
	private Text targetCountText;

	public Color redColor;

	public Color greenColor;

	[SerializeField]
	private CanvasGroup defeatCanvasGroup;

	[SerializeField]
	private Text defeatStringText;

	[SerializeField]
	private CanvasGroup successCanvasGroup;

	[SerializeField]
	private AnimationCurve overShowCurve;

	[SerializeField]
	private float overShowTime;

	[SerializeField] private Text _gemsText;

	[SerializeField]
	private GameObject hudPanel;

	[SerializeField] private GameObject _spawnSupportLabel;
	[SerializeField] private GameObject _desktopSupportLabel;
	[SerializeField] private GameObject _mobileSupportLabel;

	[SerializeField] private GameObject[] _additionals;

	[SerializeField] private CanvasGroup _group;

	private float overShowTimer;

	private Color tempColor;

	private bool overIsSuccess;

	private bool over;

	private ISaveLoadManager _saveLoadManager;
	
	private IInputManager _input;

	private bool _isSupportLabelActive;
	
	private const string _gemsFormat = "{0}/{1}";

	private bool _isMobile;
	
	[Inject]
	private void Construct(ISaveLoadManager saveLoadManager, IInputManager input)
	{
		_saveLoadManager = saveLoadManager;
		_input = input;
	}
	
	public void Init(Camera _camera)
	{
		UiCanvas.worldCamera = _camera;
		UiCanvas.planeDistance = 1f;
		defeatCanvasGroup.alpha = 0f;
		defeatCanvasGroup.gameObject.SetActive(value: false);
		successCanvasGroup.alpha = 0f;
		successCanvasGroup.gameObject.SetActive(value: false);
		hudPanel.SetActive(value: true);
		over = false;
		overShowTimer = 0f;
		_group.alpha = 1;
	}

	private void Start()
	{
		_isMobile = GP_Device.IsMobile();
	}

	public void UpdateCount(int _teamCount, int _remainCount, int _targetCount)
	{
		remainCountText.text = _remainCount.ToString();
		targetCountText.text = _teamCount.ToString() + "/" + _targetCount.ToString();
		if (_teamCount >= _targetCount)
		{
			targetCountText.color = greenColor;
		}
		else
		{
			targetCountText.color = redColor;
		}
	}

	private void Update()
	{
		var gemsCount = _saveLoadManager.GetGemsCount();
		var targetGems = _saveLoadManager.GetTargetGems();
		_desktopSupportLabel.SetActive(!_isMobile);
		_mobileSupportLabel.SetActive(_isMobile);
		_spawnSupportLabel.SetActive(gemsCount >= targetGems && targetGems != 0 && LevelManager.SurviveMode);
		if (_isSupportLabelActive != _spawnSupportLabel.activeSelf)
		{
			_input.SendEvent(_spawnSupportLabel.activeSelf ? "show_support" : "hide_support");
		}
		_isSupportLabelActive = _spawnSupportLabel.activeSelf;
		_gemsText.text = string.Format(_gemsFormat, new string[] {gemsCount.ToString(), targetGems.ToString()});
		
		if (GameManager.Instance.LevelManager.Player != null)
		{
			healthBarImage.fillAmount = GameManager.Instance.LevelManager.Player.Combat.HealthPercent;
		}
		if (over && overShowTimer < overShowTime)
		{
			overShowTimer += Time.unscaledDeltaTime;
			overShowTimer = Mathf.Min(overShowTimer, overShowTime);
			if (!overIsSuccess)
			{
				defeatCanvasGroup.alpha = overShowCurve.Evaluate(overShowTimer / overShowTime);
			}
			else
			{
				successCanvasGroup.alpha = overShowCurve.Evaluate(overShowTimer / overShowTime);
			}
		}
	}

	public void Defeat(string _defeatString)
	{
		overIsSuccess = false;
		defeatStringText.text = _defeatString;
		hudPanel.SetActive(value: false);
		over = true;
		defeatCanvasGroup.gameObject.SetActive(value: true);
	}

	public void Success()
	{
		overIsSuccess = true;
		hudPanel.SetActive(value: false);
		over = true;
		successCanvasGroup.gameObject.SetActive(value: true);
	}

	public void SetAdditional(int index)
	{
		for (int i = 0;i < _additionals.Length;i++)
			_additionals[i].SetActive(index == i);
	}
	
	public void ChangeTextAlpha(Text _text, float alpha)
	{
		tempColor = _text.color;
		tempColor.a = alpha;
		_text.color = tempColor;
	}
}
