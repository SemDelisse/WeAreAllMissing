using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogManager : MonoBehaviour
{
    public Color White = new Color(255, 255, 0);
    public Color Black = new Color(0, 255, 0);
    public float _colorSwitchDuration = 1;

    [SerializeField] private TMP_Text _DialogText;
    [SerializeField] private Image _DialogImage;
    public List<Dialog> _DialogList; // List of ingredients

    // Movement Lock
    private PlayerMovement _PlayerMovement;
    private CameraLook _CameraLook;

    [System.Serializable]
    public class Dialog
    {
        [Header("Dialog")]
        [TextArea(3, 10)]
        public string _DialogText;
        public int _screenTime = 2;

        [Header("Sounds")]
        public AudioSource _Mp4_Effect_Png_ZipMax_txt_baud9600;

        [Header("Images")]
        public Sprite _dialogSprite;
        public float _opacityLevel;
    }

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    Color change;
    private async void Start()
    {
        _PlayerMovement = FindAnyObjectByType<PlayerMovement>();
        //_DialogText = GetComponent<TMP_Text>();
        _DialogText.color = White;

        //if (_PlayerMovement != null) {
        //    _PlayerMovement.lockMovement = true;
        //    _CameraLook.freeMouseMovement = true;
        //}

        foreach (var dialog in _DialogList)
        {
            //Play sound effect if not null
            if (dialog._Mp4_Effect_Png_ZipMax_txt_baud9600 != null) dialog._Mp4_Effect_Png_ZipMax_txt_baud9600.Play();
            //show text given
            if (dialog._DialogText != null) _DialogText.text = dialog._DialogText;

            if (dialog._dialogSprite != null)
            {
                var tempColor = _DialogImage.color;
                tempColor.a = dialog._opacityLevel;
                _DialogImage.color = tempColor;
                //_DialogImage.color.a = 2f;
            }

            await Task.Delay(dialog._screenTime * 1000);

            //change = Color.Lerp(White, Black, Mathf.PingPong(Time.time / _colorSwitchDuration, 1));
            //_DialogText.color = change;

            //await Task.Delay(1000);
            //change = Color.Lerp(Black, White, Mathf.PingPong(Time.time / _colorSwitchDuration, 1));
            //_DialogText.color = change;
        }

        gameObject.SetActive(false);
        if (_PlayerMovement) _PlayerMovement.lockMovement = false;
    }
}
