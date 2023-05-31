using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Menu_ABC : UI_Popup
{
    enum Buttons
    {
        //ToMainBtn,
        BackBtn,
        StoreBtn,
    }

    enum Images
    {
        //BG,
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
        GetButton((int)Buttons.BackBtn).gameObject.BindEvent(ToMainPopup);
        //GetButton((int)Buttons.ToMainBtn).gameObject.BindEvent(ToMainPopup);
        GetButton((int)Buttons.StoreBtn).gameObject.BindEvent(() => { Managers.UI.ShowPopupUI<UI_Store>(); });

        return true;
    }

    public void ToMainPopup()
    {
        Managers.UI.ClosePopupUI();
    }
}
