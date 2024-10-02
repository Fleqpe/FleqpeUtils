using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CardDisplayerManager : SingletonManager<CardDisplayerManager>
{
    [SerializeField] private CardDisplayer prefab;
    [SerializeField] private RectTransform inventoryItemsRect;
    [SerializeField] private GridLayoutGroup inventoryItemsLayout, equippedItemsLayout;
    public static UnityAction<CardData> onEquip, onDequip;
    public static UnityAction onUnbox;
    void OnEnable()
    {
        onEquip += AddCardToEquipped;
        onDequip += AddCardToInventory;
        onUnbox += SetCards;
    }
    void OnDisable()
    {
        onEquip -= AddCardToEquipped;
        onDequip -= AddCardToInventory;
        onUnbox -= SetCards;
    }
    void Start()
    {
        SetCards();
    }
    private void SetCards()
    {
        ResetCards();
        SaveManager.gameFiles.cardInventory.cardDatas.ForEach(cardData => AddCard(cardData));
    }
    private void AddCard(CardData card)
    {
        if (SaveManager.gameFiles.cardInventory.equippedCards.Exists(y => card.ID == y))
            AddCardToEquipped(card);
        else
            AddCardToInventory(card);
    }
    private void ResetCards()
    {
        foreach (Transform item in equippedItemsLayout.transform)
            Destroy(item.gameObject);
        foreach (Transform item in inventoryItemsLayout.transform)
            Destroy(item.gameObject);
    }
    private void AddCardToEquipped(CardData cardData)
    {
        Instantiate(prefab, equippedItemsLayout.transform).SetCardData(cardData);
    }
    private void AddCardToInventory(CardData cardData)
    {
        Instantiate(prefab, inventoryItemsLayout.transform).SetCardData(cardData);
    }
}
