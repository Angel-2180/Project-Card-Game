using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostInvestissementNerfPatience10 : MonoBehaviour
{
    private void Action()
    {
        StateMachine.current.enemyUnit.investisment += StateMachine.current.enemyUnit.investisment / 2;
        StateMachine.current.enemyUnit.patience--;
        //Augmente l�investissement de 50% mais r�duit la patience de 1
    }
}
