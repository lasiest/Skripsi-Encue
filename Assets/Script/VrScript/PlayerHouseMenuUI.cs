using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHouseMenuUI : MonoBehaviour
{
    [SerializeField]private GameObject _mainMenu;
    [SerializeField]private GameObject[] _mainMenuChild;
    [SerializeField]private GameObject _levelSelection;
    [SerializeField]private GameObject _settings;

    private void Start() {
        _mainMenu.transform.GetChild(0).gameObject.GetComponent<Button>().onClick.AddListener(StartButton);
        _mainMenu.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(SettingsButton);
        _mainMenu.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.AddListener(ExitButton);
    }

    private void StartButton(){
        _mainMenu.SetActive(false);
        _levelSelection.SetActive(true);
    }

    private void SettingsButton(){
        _mainMenu.SetActive(false);
        _levelSelection.SetActive(true);
    }

    private void ExitButton(){
        
    }

    private void BackButton(){
        _mainMenu.SetActive(true);
        _levelSelection.SetActive(false);
        _settings.SetActive(false);
    }
}
