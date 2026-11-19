using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

[System.Serializable]
public class ObjectiveManager : MonoBehaviour
{
    [SerializeField] TMP_Text _objectiveText;
    [SerializeField] private List<string> _objectives = new List<string>();

    int _currentObjective = 0;

    private void Start()
    {
        ContinueObjective();
    }

    //Set current Objective
    public async void ContinueObjective()
    {
        if (_currentObjective != 0)
        {
            _objectiveText.text = $"* <s>{_objectives[_currentObjective - 1]}<s>";
            await Task.Delay(1000);
        }

        if (_currentObjective > _objectives.Count) return;
        _objectiveText.text = $"* {_objectives[_currentObjective]}";
        _currentObjective++;
    }
}
