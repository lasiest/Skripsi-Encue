using System.Collections;

public interface ISpawnable 
{
    public abstract void Spawn();

    public abstract IEnumerator WaitToSpawnFor(float time);
}