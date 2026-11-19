using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    [SerializeField] GameObject _canvas;
    [SerializeField] TMP_Text _itemname;
    [SerializeField] TMP_Text _itemDescription;
    [SerializeField] Image _itemImage;

    [SerializeField] GameObject _inventoryItemPrefab;
    [SerializeField] Transform _gridLayout;

    bool on = false;
    private void Start()
    {
        Instance = this;

        _canvas.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.I))
        {
            _canvas.SetActive(on = !on);

            PlayerMovement pm = FindAnyObjectByType<PlayerMovement>();
            if (pm != null) pm.lockMovement = on;
        }
    }

    public void AddItemToInventory(InventoryItem item)
    {
        GameObject instantiatedObj = Instantiate(_inventoryItemPrefab, _gridLayout);

        TMP_Text _itemName = instantiatedObj.GetComponentInChildren<TMP_Text>();
        Image _itemSprite = instantiatedObj.GetComponentInChildren<Image>();
        Button _button = instantiatedObj.GetComponentInChildren<Button>();

        _button.onClick.AddListener(() => ShowItemDescription(item._ItemName, item._ItemDescription, item._ItemSprite)); //takes method to activate
        _itemName.text = item._ItemName;
        _itemSprite.sprite = item._ItemSprite;
    }

    void ShowItemDescription(string _titleText, string _descriptionText, Sprite _itemIcon)
    {
        _itemname.text = _titleText;
        _itemDescription.text = _descriptionText;
        _itemImage.sprite = _itemIcon;
    }
}
