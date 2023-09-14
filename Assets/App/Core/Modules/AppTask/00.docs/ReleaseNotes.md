# Release Notes

## Planing

- Add configs for choose silent or fast failure in transaction (for production and post production)
- Add Rollback (works only with Catch in silence mode)

## Known Issues
- Catch(), Rollback() functions works not properly. Don't use this.


## 0.1.0
- Add AppTask functional:
    - Work this Coroutines, Tasks, Actions
    - Public API for (Run, Then, All, Any)
    - Work in transaction style like SomeAppTask.Then(AnotherTask).Then(AnotherCoroutine).Then(...) etc
    - Now comments all try/catch for fast failure principle (for development mode)