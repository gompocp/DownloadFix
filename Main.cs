﻿using System;
using UIExpansionKit.API;
using MelonLoader;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace DownloadFix
{
    public static class ModInfo
    {
        public const string Name = "DownloadFix";
        public const string Author = "gompo#6956";
        public const string Version = "1.0.1";
        public const string DownloadLink = null;
    }

    public class DownloadFix : MelonMod
    {
        public override void OnApplicationStart()
        {
            ICustomLayoutedMenu settingsPage = ExpansionKitApi.GetExpandedMenu(ExpandedMenu.SettingsMenu);
            settingsPage.AddSimpleButton("Unblock unpack queue", delegate
            {
                Utilities.UnblockUnPackQueue();
            });
        }

        public override void VRChat_OnUiManagerInit()
        {
            GameObject unblockButton = GameObject.Instantiate(GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/GoButton").transform, GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup/ProgressPanel").transform).gameObject;
            unblockButton.GetComponentInChildren<Text>().text = "Unblock Queue";
            unblockButton.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            unblockButton.GetComponent<Button>().onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(new Action(delegate
            {
                Utilities.UnblockUnPackQueue();
                Utilities.DeselectClickedButton(unblockButton);
            })));
            unblockButton.GetComponent<Transform>().localPosition = new Vector3(-2.4f, -124f, 0);
            GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress")
                .transform.localPosition = new Vector3(0, 17, 0);
            
        }
    }
}
