using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlotsUI : MonoBehaviour
{
    public Image leftWeaponIcon;
    public Image rigthWeponIcon;

    public void UpdateWeaponSlotUI(bool isLeft, WeaponItem item)
    {
        if (isLeft)
        {

            if (item.itemIcon != null)
            {

                leftWeaponIcon.sprite = item.itemIcon;
                leftWeaponIcon.enabled = true;
            }
            else
            {
                leftWeaponIcon.sprite = null;
                leftWeaponIcon.enabled = false;
            }

        }
        else
        {
            if (item.itemIcon != null)
            {

                rigthWeponIcon.sprite = item.itemIcon;
                rigthWeponIcon.enabled = true;
            }
            else
            {
                rigthWeponIcon.sprite = null;
                rigthWeponIcon.enabled = false;
            }
        }
    }
}
