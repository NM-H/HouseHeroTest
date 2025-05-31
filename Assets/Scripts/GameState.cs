public static class GameState
{
    // House Entry
    public static bool HasEnteredHouse = false;

    // Inventory Progress
    public static bool TrashBagPickedUp = false;
    public static bool TrashTakenOut = false;

    // Room State
    public static bool HomeworkDone = false;
    public static bool ShowTrashBag = false;

    //Task Progress
    public static bool PlantWatered = false;
    public static bool MudCleaned = false;

    // Replay Game
    public static void Reset()
    {
        TrashTakenOut = false;
        HomeworkDone = false;
        TrashBagPickedUp = false;
        HasEnteredHouse = false;
        ShowTrashBag = false;
        PlantWatered = false;
        MudCleaned = false;
    }
}
