# AppTask

## Quick Start

This Universal Task can work with Actions, Unity Coroutines, Tasks (async / await).
And provide more friendly syntax for Transactions like:
```C#
    SomeAppTask
        .Then(AnotherTask)
        .Then(SomeAction)
        .Then(SomeCoroutine)
        .Run();
```
