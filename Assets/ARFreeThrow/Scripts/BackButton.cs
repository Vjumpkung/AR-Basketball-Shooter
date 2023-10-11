using UnityEngine;

public class BackButton : MonoBehaviour
{
    public void unloadARBasketBallShooter()
    {
        StateNameController.GameReset();
        InputAxesAndSceneChanges.LoadScene("EntryUI");
    }
}
