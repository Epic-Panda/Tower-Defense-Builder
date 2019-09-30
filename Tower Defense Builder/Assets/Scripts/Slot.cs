using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [Header("Script")]
    public TowerInSlot towerInfo;

    [Header("setup")]
    public bool empty = true;

    [Header("UI")]
    public Image slotImage;

    [Header("Platform")]
    public GameObject platform;

    // add new tower if there is no tower
    public void addTowerToSlot(Tower tower)
    {
        if (!empty)
            return;

        towerInfo.towerUI.SetActive(true);
        towerInfo.towerUI.transform.localPosition = Vector3.zero;

        // set sprite
        towerInfo.image.sprite = tower.img;

        // set level text
        towerInfo.levelText.text = tower.level.ToString();

        towerInfo.tower = tower;
        empty = false;
    }

    public void removeTowerFromSlot()
    {
        if (empty)
            return;

        towerInfo.image.sprite = null;
        towerInfo.levelText.text = null;
        empty = true;
        towerInfo.towerUI.SetActive(false);
        RemoveTowerFromPlatform();
    }

    // create game object and set it on platform
    public void AddTowerToPlatform(GameObject platform)
    {
        // change slot color
        slotImage.color = new Color32(255, 255, 255, 255);

        this.platform = platform;
        this.platform.GetComponent<PlatformStatus>().empty = false;

        // instantiate new object from turret prefab and add it to platform as child
        towerInfo.towerObj = Instantiate(towerInfo.tower.turretPrefab, platform.transform.position + platform.GetComponent<PlatformStatus>().turretOffset, Quaternion.identity);
        towerInfo.towerObj.transform.parent = platform.transform;

        // set tower info
        towerInfo.towerObj.GetComponent<TowerContoller>().tower = towerInfo.tower;
    }

    public void RemoveTowerFromPlatform()
    {
        // return slot color to normal
        slotImage.color = new Color32(255, 255, 255, 100);

        // if turret on slot is not on platform, skip
        if (platform == null)
            return;
        
        Destroy(towerInfo.towerObj);
        platform.GetComponent<PlatformStatus>().empty = true;
        platform = null;
    }
}
