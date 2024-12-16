using Function;
using TMPro;
using UnityEngine;

public class TitleStartHoverText : UIObject
{
    [SerializeField] private TextMeshProUGUI _titleText;

    [SerializeField] private float _scalingSpeed;
    [SerializeField] private float _scalingValue;

    private float _smoothedValue = 0f;
    private float _smoothingFactor = 1f;

    private float _minScaleValue = 0.8f;
    private float _maxScaleValue = 1.5f;

    private float _beforeClampedValue;
    private float _middleValue;

    private float _randomAngle;

    private AudioSource source;
    private float[] spectrumDataArr = new float[1];

    private void Start()
    {
        _middleValue = (_minScaleValue + _maxScaleValue) / 2;
    }

    private void FixedUpdate()
    {
        if (source == null)
        {
            source = SoundManager.Instance.GetAudioSource(SoundType.Bgm);
        }

        spectrumDataArr = source.GetSpectrumData(64, 0, FFTWindow.Hamming);

        var rawValue = spectrumDataArr[0] * _scalingValue;
        _smoothedValue = Mathf.Lerp(_smoothedValue, rawValue, _smoothingFactor);
        var clampedValue = Mathf.Clamp(_smoothedValue, _minScaleValue, _maxScaleValue);

        var cTextScale = _titleText.transform.localScale;
        var cTextRot = _titleText.transform.rotation;

        if (clampedValue > _middleValue)
        {
            _titleText.transform.localScale = Vector2.Lerp(cTextScale, Vector3.one * clampedValue, Time.fixedDeltaTime * _scalingSpeed);

            if (clampedValue > _beforeClampedValue)
            {
                _randomAngle = Random.Range(-40, 40);
            }

            var randomQuaternion = Quaternion.Euler(0, 0, _randomAngle);
            _titleText.transform.rotation = Quaternion.Lerp(cTextRot, randomQuaternion, Time.fixedDeltaTime * _scalingSpeed);
        }
        else
        {
            _titleText.transform.localScale = Vector2.Lerp(cTextScale, Vector3.one * _minScaleValue, Time.fixedDeltaTime * _scalingSpeed);


            _titleText.transform.rotation = Quaternion.Lerp(cTextRot, Quaternion.identity, Time.fixedDeltaTime * _scalingSpeed);
        }

        _beforeClampedValue = clampedValue;
    }
}
