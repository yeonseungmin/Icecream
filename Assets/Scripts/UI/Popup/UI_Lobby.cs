using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Lobby : UI_Popup
{
    enum Buttons
    {
        
        IceCreamBtn,
        SnackBtn,
        ABCBtn,
        StoreBtn,
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

        GetButton((int)Buttons.IceCreamBtn).gameObject.BindEvent(() => { Managers.UI.ShowPopupUI<UI_Menu_ice>(); });
        GetButton((int)Buttons.SnackBtn).gameObject.BindEvent(() => { Managers.UI.ShowPopupUI<UI_Menu_snack>(); });
        GetButton((int)Buttons.ABCBtn).gameObject.BindEvent(() => { Managers.UI.ShowPopupUI<UI_Menu_ABC>(); });
        GetButton((int)Buttons.StoreBtn).gameObject.BindEvent(() => { Managers.UI.ShowPopupUI<UI_Store>(); });
        

        return true;
    }


}
