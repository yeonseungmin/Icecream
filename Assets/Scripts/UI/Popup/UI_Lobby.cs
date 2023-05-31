using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Lobby : UI_Popup
{
    enum Buttons
    {
        //ToMainBtn,
    }

    enum Images
    {
        BG,
    }

    enum Texts
    {

    }

    private void Start()
    {
        Init();
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButton(typeof(Buttons));
        BindImage(typeof(Images));
        BindText(typeof(Texts));

        //GetButton((int)Buttons.ToMainBtn).gameObject.BindEvent(() => { Managers.UI.ClosePopupUI(); });

        return true;
    }

}
