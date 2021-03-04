using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializerSwitch : MonoBehaviour
{

    public string currentName;
    public ElementInitializer [] init;

    private void Update()
    {
        currentName = ElementInitializer.name;
        switch (currentName)
        {
            case "H_button":
                init[0].Initializer();
                break;
            case "C_button":
                init[1].Initializer();
                break;
            case "O_button":
                init[2].Initializer();
                break;
            case "N_button":
                init[3].Initializer();
                break;
            case "S_button":
                init[4].Initializer();
                break;
            case "F_button":
                init[5].Initializer();
                break;
            case "CL_button":
                init[6].Initializer();
                break;
            case "BR_button":
                init[7].Initializer();
                break;

        }

        
    }


}
