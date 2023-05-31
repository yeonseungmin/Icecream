using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Basket : UI_Popup
{
    enum Buttons
    {
        BasketBtn,
    }

    enum Images
    {
        BG,
    }

    enum Texts
    {
        AddressText
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

        GetButton((int)Buttons.BasketBtn).gameObject.BindEvent(() => { Managers.UI.ClosePopupUI(); });

        return true;
    }

    // AddressText¸¦ ¿¬µ¿

}
