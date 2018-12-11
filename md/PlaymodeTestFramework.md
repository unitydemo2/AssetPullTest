# Writing and executing tests in Unity Test Runner

The Unity Test Runner tests your code in __Edit__ mode and __Play__ mode, as well as on target platforms such as Standalone, Android, or iOS.

The documentation on this page discusses writing and executing tests in the the Unity Test Runner, and assumes you understand both [scripting](CreatingAndUsingScripts) and the [Unity Test Runner](testing-editortestsrunner).

Unity delivers test results in an XML format. For more information, see the [NUnit documentation on XML format test results](https://github.com/nunit/docs/wiki/Test-Result-XML-Format).

## UnityTestAttribute

[UnityTestAttribute](ScriptRef:TestTools.UnityTestAttribute.html) requires you to return `IEnumerator`. In __Play__ mode, execute the test as a [coroutine](ScriptRef:Coroutine.html). In __Edit__ mode, you can yield `null` from the test, which skips the current frame.

__Note:__ The WebGL and WSA platforms do not support `UnityTestAttribute`.

### Regular NUnit test (works in Edit mode and Play mode)

```
[Test]
public void GameObject_CreatedWithGiven_WillHaveTheName()
{
    var go = new GameObject("MyGameObject");
    Assert.AreEqual("MyGameObject", go.name);
}
```

### Example in Play mode

```
[UnityTest]
public IEnumerator GameObject_WithRigidBody_WillBeAffectedByPhysics()
{
    var go = new GameObject();
    go.AddComponent<Rigidbody>();
    var originalPosition = go.transform.position.y;

    yield return new WaitForFixedUpdate();

    Assert.AreNotEqual(originalPosition, go.transform.position.y);
}
```

### Example in Edit mode:

```
[UnityTest]
public IEnumerator EditorUtility_WhenExecuted_ReturnsSuccess()
{
    var utility = RunEditorUtilityInTheBackgroud();

    while (utility.isRunning)
    {
        yield return null;
    }

    Assert.IsTrue(utility.isSuccess);
}
```

## UnityPlatformAttribute

Use [UnityPlatformAttribute](ScriptRef:TestTools.UnityPlatformAttribute.html) to filter tests based on the the executing platform. It behaves like the [NUnit ](http://nunit.org/docs/2.5/platform.html)[PlatformAttribute](http://nunit.org/docs/2.5/platform.html).

```
[Test]
[UnityPlatform (RuntimePlatform.WindowsPlayer)]
public void TestMethod1()
{
   Assert.AreEqual(Application.platform, RuntimePlatform.WindowsPlayer);
}

[Test]
[UnityPlatform(exclude = new[] {RuntimePlatform.WindowsEditor })]
public void TestMethod2()
{
   Assert.AreNotEqual(Application.platform, RuntimePlatform.WindowsEditor);
}
```

To only execute Editor tests on a given platform, you can also use `UnityPlatform` .

### PrebuildSetupAttriubte

Use [PrebuildSetupAttribute](ScriptRef:TestTools.PrebuildSetupAttribute.html) if you need to perform any extra set-up before the test starts. To do this, specify the class type that implements the [IPrebuildSetup](ScriptRef:TestTools.IPrebuildSetup.html) interface. If you need to run the set-up code for the whole class (for example, if you want to execute some code before the test starts, such as Asset preparation or set-up required for a specific test), implement the `IPrebuildSetup` interface in the class for tests.

```
public class TestsWithPrebuildStep : IPrebuildSetup
{
    public void Setup()
    {
        // Run this code before the tests are executed
    }

    [Test]
    //PrebuildSetupAttribute can be skipped because it's implemented in the same class
    [PrebuildSetup(typeof(TestsWithPrebuildStep))]
    public void Test()
    {
        (...)
    }
}
```

Execute the `IPrebuildSetup` code before entering Play mode or building a player. Setup can use UnityEditor namespace and its function, but to avoid compilation errors, you must place it either in the *Editor* folder, or guard it with the `#if UNITY_EDITOR` directive.

## LogAssert

A test fails if Unity logs a message other than a regular log or warning message. Use the [LogAssert](ScriptRef:TestTools.LogAssert.html) class to make a message expected in the log, so that the test does not fail when Unity logs that message.

A test also reports as failed if an expected message does not appear, or if Unity does not log any regular log or warning messages.

### Example

```
[Test]
public void LogAssertExample()
{
    //Expect a regular log message
    LogAssert.Expect(LogType.Log, "Log message");
    //A log message is expected so without the following line
    //the test would fail
    Debug.Log("Log message");
    //An error log is printed
    Debug.LogError("Error message");
    //Without expecting an error log, the test would fail
    LogAssert.Expect(LogType.Error, "Error message");
}
```

## MonoBehaviourTest

[MonoBehaviourTest](ScriptRef:TestTools.MonoBehaviourTest_1.html) is a [coroutine](ScriptRef:Coroutine.html), and a helper for writing [MonoBehaviour](ScriptRef:MonoBehaviour.html) tests. Yield `MonoBehaviourTest` from the [UnityTest](ScriptRef:TestTools.UnityTestAttribute.html) attribute to instantiate the specified MonoBehaviour and wait for it to finish executing. Implement the [IMonoBehaviourTest](ScriptRef:TestTools.IMonoBehaviourTest.html) interface to indicate when the test is done.

### Example

```
[UnityTest]
public IEnumerator MonoBehaviourTest_Works()
{
    yield return new MonoBehaviourTest<MyMonoBehaviourTest>();
}

public class MyMonoBehaviourTest : MonoBehaviour, IMonoBehaviourTest
{
    private int frameCount;
    public bool IsTestFinished
    {
        get { return frameCount > 10; }
    }

     void Update()
     {
        frameCount++;
     }
}
```

## Running tests on platforms

In __Play__ mode, you can run tests on specific platforms. The target platform is always the current Platform selected in [Build Settings](BuildSettings) (menu: __File__ > __Build Settings__). Click __Run all in the player__ to build and run your tests on the currently active target platform.

Note that your current platform displays in brackets on the button. For example, in the screenshot below, the button reads __Run all in player (StandaloneWindows)__, because the current platform is Windows.

![](../uploads/Main/UnityTestRunner-3.png)

The test results display in the build once the test is complete.

![](../uploads/Main/UnityTestRunner-4.png)

To get the test results from the platform to the Editor running the test, both need to be on same network. The application running on the platform reports back the test results, displays the tests executed, and shuts down.

Note that some platforms do not support shutting down the application with [Application.Quit](ScriptRef:Application.Quit.html). These continue running after reporting test results.

If Unity cannot instantiate the connection, you can visually see the tests succeed in the running application. Note that running tests on platforms with arguments, in this state, does not provide XML test results.

## Running from the command line

To do this, run Unity with the following [command line ](CommandLineArguments)[arguments](CommandLineArguments):

* `runTests` - Executes tests in the Project.

* `testPlatform` - The platform you want to run tests on.

    * Available platforms:

        * `playmode` and `editmode`. Note that If unspecified, tests run in `editmode` by default.

        * Platform/Type convention is from the [BuildTarget](ScriptRef:BuildTarget.html) enum. The tested and official supported platforms:

            * [StandaloneWindows](ScriptRef:BuildTarget.StandaloneWindows.html)

            * [StandaloneWindows64](ScriptRef:BuildTarget.StandaloneWindows64.html)

            * [StandaloneOSXIntel](ScriptRef:BuildTarget.StandaloneOSXIntel.html)

            * [StandaloneOSXIntel64](ScriptRef:BuildTarget.StandaloneOSXIntel64.html)

            * [iOS](ScriptRef:BuildTarget.iOS.html)

            * [tvOS](ScriptRef:BuildTarget.tvOS.html)

            * [Android](ScriptRef:BuildTarget.Android.html)

            * [PS4](ScriptRef:BuildTarget.PS4.html)

            * [XboxOne](ScriptRef:BuildTarget.XboxOne.html)

* `testResults` - The path indicating where Unity should save the result file. By default, Unity saves it in the Project’s root folder. 

### Example

The following example shows a command line argument on Windows. The specific line may differ depending on your operating system.


```
>Unity.exe -runTests -projectPath PATH_TO_YOUR_PROJECT -testResults C:\temp\results.xml -testPlatform editmode
```

__Tip:__ On Windows, in order to read the result code of the executed command, run the following: 

`start /WAIT Unity.exe ARGUMENT_LIST`.

## Comparison utilities

The [UnityEngine.TestTools.Utils](ScriptRef:TestTools.Utils.Utils.html) namespace contains utility classes to compare [Vector2](ScriptRef:Vector2.html), [Vector3](ScriptRef:Vector3.html), [Vector4](ScriptRef:Vector4.html), [Quaternion](ScriptRef:Quaternion.html), [Color](ScriptRef:Color.html) and `float` types using NUnit constraints.

---

* <span class="page-edit"> 2018-03-21  <!-- include IncludeTextAmendPageYesEdit --></span>