using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDialogScene : GameScene{
    private void Awake(){
        isDialogExit = false;
    }

    public void ChoiceVariant(int number){
        if (number == 1) Variant1();
        else if (number == 2) Variant2();
    }

    public void Variant1(){
        isDialogExit = true;
    }

    public void Variant2(){
        isDialogExit = true;
        
    }
}
