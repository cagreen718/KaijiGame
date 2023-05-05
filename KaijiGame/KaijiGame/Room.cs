public class Room
{
    private int moveCount;
    private bool doorUnlocked;
    private EnemyChar currentEnemy;
    private List<EnemyChar> enemies;
    private Door doorPrototype;

    public Room(List<EnemyChar> enemies, Door doorPrototype)
    {
        this.moveCount = 0;
        this.doorUnlocked = false;
        this.currentEnemy = null;
        this.enemies = enemies;
        this.doorPrototype = doorPrototype;
    }

    public void MoveToNextEnemy()
    {
        if (moveCount < 5)
        {
            currentEnemy = enemies[moveCount % enemies.Count].Clone();
            moveCount++;
        }
        else
        {
            currentEnemy = null;
            doorUnlocked = true;
        }
    }

    public bool CanUnlockDoor()
    {
        return doorUnlocked;
    }

    public Door GetDoor()
    {
        return doorPrototype.Clone();
    }

    public EnemyChar GetCurrentEnemy()
    {
        return currentEnemy;
    }
}