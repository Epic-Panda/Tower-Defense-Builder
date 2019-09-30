using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    public PlatformController platformController;
    public List<Slot> slot;

    PlayerStats playerStats;
    Towers towers;

    void Start()
    {
        platformController = PlatformController.Instance;

        towers = Towers.Instance;
        playerStats = PlayerStats.Instance;
    }

    public void OnDrop(PointerEventData eventData)
    {
        RectTransform inv = transform as RectTransform;

        // build tower on platform
        if (!RectTransformUtility.RectangleContainsScreenPoint(inv, Input.mousePosition))
        {
            // create ray to determinate mouse position in world
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);

            Vector3 pos = hit.point;

            GameObject platform = null;

            foreach (GameObject p in platformController.platform)
            {
                if (p.GetComponent<PlatformStatus>().empty)
                {
                    if (platform == null)
                    {
                        platform = p;
                        continue;
                    }

                    if (Vector3.Distance(platform.transform.position, pos) > Vector3.Distance(p.transform.position, pos))
                    {
                        platform = p;
                    }
                }
            }

            playerStats.selectedSlot.AddTowerToPlatform(platform);
            return;
        }

        // check for each slot if mouse pointer is over it
        foreach (Slot s in slot)
        {
            inv = s.transform as RectTransform;

            if (RectTransformUtility.RectangleContainsScreenPoint(inv, Input.mousePosition))
            {
                // check if it is same slot
                if (s == playerStats.selectedSlot)
                    break;

                // if slot is not empty check if merge is possible
                if (!s.empty)
                {
                    if (playerStats.movingTower.tower.level == s.towerInfo.tower.level)
                    {
                        int lvl = s.towerInfo.tower.level;

                        if (lvl >= towers.maxLvl)
                            return;

                        // merge towers
                        // remove old towers
                        playerStats.selectedSlot.removeTowerFromSlot();
                        s.removeTowerFromSlot();

                        // create new one
                        s.addTowerToSlot(towers.towerList[lvl]);
                    }
                }
                // if slot is empty then put tower in that slot
                else
                {
                    playerStats.selectedSlot.removeTowerFromSlot();

                    s.addTowerToSlot(playerStats.movingTower.tower);
                }

                break;
            }
        }
    }
}

// backup for standalone itemdrophandler
/*
 using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    public PlatformController platformController;
    public Slot slot;

    void Start()
    {
        platformController = PlatformController.Instance;
    }

    public void OnDrop(PointerEventData eventData)
    {
        //TODO da sredim ovde da mi izbaci item
        RectTransform inv = transform as RectTransform;
        Debug.Log("TRY");

        if (!RectTransformUtility.RectangleContainsScreenPoint(inv, Input.mousePosition))
        {
            GameObject platform = null;

            foreach (GameObject p in platformController.platform)
            {
                if (p.GetComponent<PlatformStatus>().empty)
                {
                    if (platform == null)
                    {
                        platform = p;
                        continue;
                    }

                    if (Vector3.Distance(platform.transform.position, Input.mousePosition) > Vector3.Distance(p.transform.position, Input.mousePosition))
                    {
                        platform = p;
                    }
                }
            }

            slot.AddTowerToPlatform(platform);
        }
    }
}

 */
