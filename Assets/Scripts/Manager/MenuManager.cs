
public class MenuManager
{
    private static MenuManager instance;

    public static MenuManager getManager(){
        if(instance == null)
            instance = new MenuManager();
        return instance;
    }

    public string? currentScene { get; set; }
    public string? Destination {get; set;}
}
