using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.XR;
using static Define;

public class UI_Main : UI_Popup
{
    enum Images
    {
        BG,
    }

    enum Texts
    {
        StartText,
    }

    private void Start()
    {
        Init();
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindImage(typeof(Images));
        BindText(typeof(Texts));

        GetImage((int)Images.BG).gameObject.BindEvent(() => { Managers.UI.ShowPopupUI<UI_Lobby>(); });

        return true;
    }

}
