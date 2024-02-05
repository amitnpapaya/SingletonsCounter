using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Febucci.UI;
using Febucci.UI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class CounterController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private SoundManager _soundManager;
    
    [Header("View")]
    [SerializeField] private TextAnimator_TMP _textAnimator;
    
    [Header("Config")]
    [SerializeField] private int _initialCounterCount;
    [SerializeField] private KeyCode _counterUpKey;
    [SerializeField] private KeyCode _counterDownKey;
    
    [SerializeField] private AudioClip _upAudioClip;
    [SerializeField] private AudioClip _downAudioClip;

    private int _counterCount;
    private CancellationTokenSource _currentToken;

    private void Awake()
    {
        _counterCount = _initialCounterCount;
        _textAnimator.SetText($"{_counterCount}");
    }

    private async UniTaskVoid UpdateText()
    {
        _currentToken?.Cancel();
        
        var text = $"<rainb><incr>{_counterCount}</incr></rainb>";
        _textAnimator.ResetState();
        _textAnimator.SetText(text);
        
        _currentToken = new CancellationTokenSource();
        await UniTask.Delay(TimeSpan.FromSeconds(5), cancellationToken: _currentToken.Token);
        
        text = $"{_counterCount}";
        _textAnimator.ResetState();
        _textAnimator.SetText(text);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_counterDownKey))
        {
            _counterCount--;
            _soundManager.PlaySound(_downAudioClip);
            UpdateText().Forget();
        }
        
        else if (Input.GetKeyDown(_counterUpKey))
        {
            _counterCount++;
            _soundManager.PlaySound(_upAudioClip);
            UpdateText().Forget();
        }
    }
}
