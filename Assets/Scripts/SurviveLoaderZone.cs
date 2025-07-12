using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Zenject;

public class SurviveLoaderZone : MonoBehaviour
{
    public float radius;
    public LevelManager.gameModes gameMode;
    public LevelManager.game3Ctypes game3CType;
    public List<Renderer> renderers;
    
    public TextMesh text;
    
    public Material defaultMaterial;
    public Color defaultTextColor;
    
    public Material lockMaterial;
    public Color lockedTextColor;
    private bool _locked;
    private IAdsManager _adsManager;
    private IInputManager _input;
    private const string AD_LEVEL_UNLOCK = "survive_mode_unlock";
    private bool _inDistance;

    [Inject]
    private void Construct(IAdsManager adsManager, IInputManager input)
    {
        _adsManager = adsManager;
        _input = input;
    }
    
    void Start()
    {
        SetLockedState(!DataManager.EverEnteredLevel("level6"));
        _adsManager.AddRewardAdListener(RewardAdListener);
    }

    private void RewardAdListener(string id)
    {
        if (id == AD_LEVEL_UNLOCK)
        {
            SetLockedState(false);
        }
    }
    
    private void SetLockedState(bool locked)
    {
        _locked = locked;
        text.color = locked ? lockedTextColor : defaultTextColor;
        for (int i = 0; i < renderers.Count; i++)
        {
            renderers[i].material = locked ? lockMaterial : defaultMaterial;
        }
    }

    private void Update()
    {
        bool prevInDist = _inDistance;
        _inDistance =
            Vector3.Distance(GameManager.Instance.LevelManager.Player.transform.position, base.transform.position) <
            radius;
        if (_inDistance)
        {
            if (!_locked)
            {
                GameManager.Instance.LevelManager.gameMode = gameMode;
                GameManager.Instance.LevelManager.game3CType = game3CType;
                GameManager.Instance.LevelManager.LoadSurviveMode();
            }
            else
            {
                if (_input.IsWatchAd()) _adsManager.ShowRewardAd(AD_LEVEL_UNLOCK);
                if (prevInDist != _inDistance) _input.SendEvent("show_survive_ad");
            }
        }
        else
        {
            _input.SendEvent("hide_survive_ad");
        }
    }

    private void OnDestroy()
    {
        _input.SendEvent("hide_survive_ad");
        _adsManager.RemoveRewardAdListener(RewardAdListener);
    }
}
