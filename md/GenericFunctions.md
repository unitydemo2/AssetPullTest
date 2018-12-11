# Generic Functions

The Unity Scripting API Reference documentation lists some functions (for example, the various `GetComponent` functions) with a variant that has a letter `T` or a type name in angle brackets after the function name:


```
//C#
void FuncName<T>();
```

These are generic functions. You can use them to specify the types of parameters and/or the return type when you call the function.

```
// The type is correctly inferred because it is defined in the function call
var obj = GetComponent<Rigidbody>();
```
In C#, it can save a lot of keystrokes and cast; for example:

```
Rigidbody rb= (Rigidbody) go.GetComponent(typeof(Rigidbody));
```

Compared to: 

```
Rigidbody rb = go.GetComponent<Rigidbody>();
```

Any function that has a generic variant listed on its Scripting API Reference documentation page allows this special calling syntax.
