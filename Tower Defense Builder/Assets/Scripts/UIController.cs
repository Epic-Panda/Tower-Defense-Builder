using UnityEngine;

public class UIController : MonoBehaviour {

    public GameObject inventory, store;

	void Update () {

        // on space pressed switch inventory and shop
        if (Input.GetKeyDown("space"))
        {
            inventory.SetActive(!inventory.active);
            store.SetActive(!store.active);
        }
	}
}
