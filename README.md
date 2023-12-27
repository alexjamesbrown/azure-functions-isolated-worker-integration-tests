# Integration Tests For Azure Functions Isolated Worker

**Spoiler: This is a WIP**

This is an attempt at doing some integration tests for Isolated Worker Azure Functions.  
It would be nice if we could spin up the app and run in memory, like we can with asp.net / `WebApplicationFactory`

This has been heavily inspired by the answer given on this StackOverflow post:
https://stackoverflow.com/questions/77211786/how-to-start-a-full-net-core-worker-service-in-an-integration-end-to-end-test

And also the issue on the azure-functions-dotnet-worker repo:
https://github.com/Azure/azure-functions-dotnet-worker/issues/968

Any help / contributions greatly appreciated!