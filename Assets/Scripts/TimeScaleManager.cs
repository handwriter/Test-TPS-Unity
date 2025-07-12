using UnityEngine;
using Zenject;

public class TimeScaleManager : MonoBehaviour
{
	public float deadTimeScale = 0.15f;

	private bool dead;

	public float bulletTimeScale = 0.12f;

	private float bulletTimeFactor;

	public float currentTimeScale;
	
	private IInputManager _input;

	[Inject]
	private void Construct(IInputManager input)
	{
		_input = input;
	}

	private float pauseTimeScaleFactor => (!LevelManager.Paused) ? 1 : 0;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
		if (_input.IsSlow())
		{
			bulletTimeFactor = bulletTimeScale;
		}
		else
		{
			bulletTimeFactor = 1f;
		}
		UpdateTimeSclae();
	}

	public void Dead()
	{
		dead = true;
	}

	public void ResetTimeScales()
	{
		dead = false;
	}

	private void UpdateTimeSclae()
	{
		Time.timeScale = (dead ? deadTimeScale : 1f) * pauseTimeScaleFactor * bulletTimeFactor;
		if (Time.timeScale > 0f)
		{
			Time.fixedDeltaTime = Time.timeScale * 0.0069444445f;
		}
		currentTimeScale = Time.timeScale;
	}
}
