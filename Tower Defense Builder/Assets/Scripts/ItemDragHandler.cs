using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public TowerInSlot towerInfo;
    public PlayerStats playerStats;
    public Slot slot;

    void Start()
    {
        playerStats = PlayerStats.Instance;
        slot = gameObject.GetComponentInParent<Slot>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        //remove turret from platform
        slot.RemoveTowerFromPlatform();

        playerStats.movingTower = towerInfo;
        playerStats.selectedSlot = slot;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // return to start position
        transform.localPosition = Vector3.zero;
    }
}

// backup for standalone
/*
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public TowerInSlot towerInfo;
    public PlayerStats playerStats;
    public Slot slot;
    public ItemDropHandler itemDropHandler;

    void Start()
    {
        playerStats = PlayerStats.Instance;
        slot = gameObject.GetComponentInParent<Slot>();
        itemDropHandler = transform.parent.GetComponentInParent<ItemDropHandler>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        playerStats.movingTower = towerInfo;
        playerStats.towerOldSlot = slot;
        transform.position = Input.mousePosition;
        itemDropHandler.slot = slot;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // return to start position
        transform.localPosition = Vector3.zero;
        itemDropHandler.slot = null;
    }
}
*/