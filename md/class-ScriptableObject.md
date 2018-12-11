#ScriptableObject

##What is a ScriptableObject?

A ScriptableObject is a data container that you can use to save large amounts of data, independent of class instances. One of the main use cases for ScriptableObjects is to reduce your Project’s memory usage by avoiding copies of values. This is useful if your Project has a [Prefab](Prefabs) that stores unchanging data in attached MonoBehaviour scripts. Everytime you instantiate that Prefab, it will get its own copy of that data. Instead of using the method, and storing duplicated data, you can use a ScriptableObject to store the data and then access it by reference from all of the Prefabs. This means that there is one copy of the data in memory.

Just like MonoBehaviours, ScriptableObjects derive from the base Unity Object but, unlike MonoBehaviours, you can not attach a ScriptableObject to a [GameObject](class-GameObject). Instead, you save them as Assets in your Project.

When using the Editor, you can save data to ScriptableObjects while editing and at run time because ScriptableObjects use the Editor namespace and Editor scripting. In a deployed build, however, you can’t use ScriptableObjects to save data, but you can use the saved data from the ScriptableObject Assets that you set up during development.
Data that you save from Editor Tools to ScriptableObjects as an asset is written to disk and is therefore persistent between sessions.

##Using a ScriptableObject
The main use cases for ScriptableObjects are:

* Saving and storing data during an Editor session
* Saving data as an Asset in your Project to use at run time

To use a ScriptableObject, you need to create a script in your __Assets__ folder and make it inherit from the `ScriptableObject` class. You can use the [CreateAssetMenu](ScriptRef:CreateAssetMenuAttribute.html) attribute to make it easy to create custom assets using your class. For example:

```
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class SpawnManagerScriptableObject : ScriptableObject
{
    public string prefabName;

    public int numberOfPrefabsToCreate;
    public Vector3[] spawnPoints;
}
``` 
With the above script in your __Assets__ folder, you can create an instance of your ScriptableObject by navigating to __Assets &gt; Create &gt; ScriptableObjects &gt; SpawnManagerScriptableObject__. Give your new ScriptableObject instance  a meaningful name and alter the values. To use these values, you need to create a new script that references your ScriptableObject, in this case, a `SpawnManagerScriptableObject`. For example:

```
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // The GameObject to instantiate.
    public GameObject entityToSpawn;

    // An instance of the ScriptableObject defined above.
    public SpawnManagerScriptableObject spawnManagerValues;

    // This will be appended to the name of the created entities and increment when each is created.
    int instanceNumber = 1;

    void Start()
    {
        SpawnEntities();
    }

    void SpawnEntities()
    {
        int currentSpawnPointIndex = 0;

        for (int i = 0; i < spawnManagerValues.numberOfPrefabsToCreate; i++)
        {
            // Creates an instance of the prefab at the current spawn point.
            GameObject currentEntity = Instantiate(entityToSpawn, spawnManagerValues.spawnPoints[currentSpawnPointIndex], Quaternion.identity);

            // Sets the name of the instantiated entity to be the string defined in the ScriptableObject and then appends it with a unique number. 
            currentEntity.name = spawnManagerValues.prefabName + instanceNumber;

            // Moves to the next spawn point index. If it goes out of range, it wraps back to the start.
            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % spawnManagerValues.spawnPoints.Length;

            instanceNumber++;
        }
    }
}
```
Attach the above script to a GameObject in your [Scene](CreatingScenes). Then, in the Inspector, set the __Spawn Manager Values__ field to be the new `SpawnManagerScriptableObject` that you set up. Set the __Entity To Spawn__ field to be any Prefab in your Assets folder, and then click __Play__ in the Editor. You will see the Prefab you referenced in the `Spawner` instantiated using the settings you set in the `SpawnManagerScriptableObject`.
ableObject-derived class, you can use the [CreateAssetMenu](ScriptRef:CreateAssetMenuAttribute.html) attribute to make it easy to create custom assets using your class.

Tip: When working with ScriptableObject references in the inspector, you can double click the reference field to open the inspector for your ScriptableObject. You can also create a custom Editor to define the look of the inspector for your type to help manage the data that it represents.

---
* <span class="page-edit">2018-10-15  <!-- include IncludeTextNewPageYesEdit --></span>

