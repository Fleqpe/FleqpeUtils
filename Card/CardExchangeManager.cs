using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardExchangeManager : SingletonManager<CardExchangeManager>
{
    [SerializeField] private CardExchangeDisplayer prefab;
    [SerializeField] private RectTransform inventoryItemsRect;
    [SerializeField] private GridLayoutGroup inventoryItemsLayout;
    void OnEnable()
    {
        CardDisplayerManager.onUnbox += SetCards;
    }
    void OnDisable()
    {
        CardDisplayerManager.onUnbox -= SetCards;
    }
    void Start()
    {
        SetCards();
    }
    private void SetCards()
    {
        foreach (Transform item in inventoryItemsLayout.transform)
            Destroy(item.gameObject);
        SaveManager.gameFiles.cardInventory.cardDatas.ForEach(x => AddCardToInventory(x));
    }
    private void AddCardToInventory(CardData cardData)
    {
        Instantiate(prefab, inventoryItemsLayout.transform).SetCardData(cardData);
    }
}
