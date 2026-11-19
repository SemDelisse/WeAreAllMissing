using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class NumberLock : MonoBehaviour
{
    PlayerMovement _ccScript;

    [SerializeField] int _correctCode;

    readonly List<int> _corectLockNum = new List<int>();

    int _lockNum1 = 0;
    int _lockNum2 = 0;
    int _lockNum3 = 0;
    int _lockNum4 = 0;

    [SerializeField] TMP_Text _lockTxt1;
    [SerializeField] TMP_Text _lockTxt2;
    [SerializeField] TMP_Text _lockTxt3;
    [SerializeField] TMP_Text _lockTxt4;

    [SerializeField] Animator _interactedAnim;

    [SerializeField] GameObject _canvas;
    // Start is called before the first frame update
    void Start()
    {
        HideLock();
        UpdateLockState();

        _ccScript = FindAnyObjectByType<PlayerMovement>();

        foreach (var _num in _correctCode.ToString())
        {
            _corectLockNum.Add(Int32.Parse(_num.ToString()));
        }
    }

    public void ShowLock()
    {
        if (_ccScript) _ccScript.lockMovement = true;
        _canvas.SetActive(true);
    }
    public void HideLock()
    {
        if (_ccScript) _ccScript.lockMovement = false;
        _canvas.SetActive(false);
    }

    public void IncrementLockNum(int _row)
    {

        switch (_row)
        {
            case 1:
                if (_lockNum1 < 9) _lockNum1++;
                else _lockNum1 = 0;
                break;
            case 2:
                if (_lockNum2 < 9) _lockNum2++;
                else _lockNum2 = 0;
                break;
            case 3:
                if (_lockNum3 < 9) _lockNum3++;
                else _lockNum3 = 0;
                break;
            case 4:
                if (_lockNum4 < 9) _lockNum4++;
                else _lockNum4 = 0;
                break;
        }

        UpdateLockState();
    }
    public void DecrementLockNum(int _row)
    {

        switch (_row)
        {
            case 1:
                if (_lockNum1 > 0) _lockNum1--;
                else _lockNum1 = 9;
                break;
            case 2:
                if (_lockNum2 > 0) _lockNum2--;
                else _lockNum2 = 9;
                break;
            case 3:
                if (_lockNum3 > 0) _lockNum3--;
                else _lockNum3 = 9;
                break;
            case 4:
                if (_lockNum4 > 0) _lockNum4--;
                else _lockNum4 = 9;
                break;
        }

        UpdateLockState();
    }

    //bool _lockOpen = false;
    public void ActivateLock()
    {
        if (_corectLockNum[0] == _lockNum1 && _corectLockNum[1] == _lockNum2 && _corectLockNum[2] == _lockNum3 && _corectLockNum[3] == _lockNum4)
        {
            Debug.Log("Right Code!");
            _interactedAnim.SetBool("Open", true);
            FindAnyObjectByType<DoorNumbLock>().UnlockDoor();
            HideLock();
        }
        else
        {
            Debug.Log("Wrong Code!");
        }
    }

    void UpdateLockState()
    {
        _lockTxt1.text = _lockNum1.ToString();
        _lockTxt2.text = _lockNum2.ToString();
        _lockTxt3.text = _lockNum3.ToString();
        _lockTxt4.text = _lockNum4.ToString();
    }
}
