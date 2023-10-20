using UnityEngine;

public class DestinationHandler : MonoBehaviour
{
    public LoadingManager loadingManager;
    private DataManager manager;
    public void LoadDestination(string destination)
    {
        manager = DataManager.instance;
        manager.Destination = destination;
        manager.CurrentScene = "TravelLevel";
        loadingManager.LoadScene(manager.CurrentScene);
    }
    public void LoadDestinationForMabini(string destination)
    {
        manager = DataManager.instance;
        manager.Destination = destination;
        manager.CurrentScene = "TravelLevel";
        loadingManager.LoadScene("MabiniEpilogue");
    }
}
