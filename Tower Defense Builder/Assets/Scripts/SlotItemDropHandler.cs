/*using UnityEngine;
using UnityEngine.EventSystems;

public class SlotItemDropHandler : MonoBehaviour, IDropHandler
{
    public Slot slot;
    PlayerStats playerStats;
    Towers towers;

    void Start()
    {
        towers = Towers.Instance;
        playerStats = PlayerStats.Instance;
    }

    public void OnDrop(PointerEventData eventData)
    {
        //TODO da sredim ovde da mi spoji tower
        RectTransform inv = transform as RectTransform;

        if (RectTransformUtility.RectangleContainsScreenPoint(inv, Input.mousePosition))
        {
            if (!slot.empty)
            {
                if (playerStats.movingTower.tower.level == slot.itemDragHandler.towerInfo.tower.level)
                {
                    int lvl = slot.itemDragHandler.towerInfo.tower.level;

                    if (lvl >= towers.maxLvl)
                        return;

                    // remove old towers
                    playerStats.selectedSlot.removeTowerFromSlot();
                    slot.removeTowerFromSlot();

                    // create new one
                    slot.addTowerToSlot(towers.towerList[lvl]);
                }
            }
        }
    }
}*/