public static class GameState
{
    public static bool TrashTakenOut = false;
    public static bool HomeworkDone = false;
    public static bool TrashBagPickedUp = false;
    public static bool DoorUnlocked = false;
    public static bool HasEnteredHouse = false;
    public static bool ShowTrashBag = false;

    // replay game
    public static void Reset()
    {
        TrashTakenOut = false;
        HomeworkDone = false;
        TrashBagPickedUp = false;
        DoorUnlocked = false;
    }
}
