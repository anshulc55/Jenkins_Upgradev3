# Demo 1

Standard Jenkins build

## Run Jenkins

Built from [this Dockerfile](../jenkins/m3-demo1/Dockerfile), standard Jenkins 2.204 install with .NET Core SDK:

```
docker run -d `
  -p 8081:8080 `
  --name jenkins1 `
  -v /var/run/docker.sock:/var/run/docker.sock `
  sixeyed/psod-jenkins:m3-demo1
```

Browse to http://localhost:8081 & sign in

```
docker logs jenkins1
```

## Finish the Jenkins setup

Click _Select plugins to install_ then:

- select _None_
- finish install & login

## Set up the project & clone the repo

First we need to connecto to GitHub. Check the [plugin catalogue](https://plugins.jenkins.io/)

- search `github`
- check `GitHub Integration` plugin details

Back to Jenkins - _Manage Jenkins_ ... _Manage Plugins_

- from `Available` tab
- install GitHub Integration

Create new freestyle job `pi`:

- Git SCM
- repo url `https://github.com/sixeyed/pi` (no credentials - public)
- branch spec `\*psod`
- advanced clone - shallow, depth = 1
- clean before checkout

Build triggers:

- poll scm
- schedule `H/5 * * * *`

Build steps:

- shell `ls`

> Build now and verify repo download

## Build the code

Check for a .NET Core plugin in [the catalogue](https://plugins.jenkins.io/).

- filter on platform .NET

> No way to install .NET Core SDK as a plugin (needs server install).

Add build step:

```
dotnet build ./src/Pi.Web/Pi.Web.csproj
```

> Build and check

Add smoke test:

```
dotnet ./src/Pi.Web/bin/Debug/netcoreapp3.1/Pi.Web.dll
```

> Build again

## Run tests

Unit tests use NUnit which can output MSTest `.trx` format files.

Add unit test:

```
dotnet test --logger "trx;LogFileName=Pi.Math.trx" ./src/Pi.Math.Tests/Pi.Math.Tests.csproj

dotnet test --logger "trx;LogFileName=Pi.Runtime.trx" ./src/Pi.Runtime.Tests/Pi.Runtime.Tests.csproj
```

> Build and check console output

Browse workspace for `.trx` files; now we need an MSTest plugin from the [catalogue](https://plugins.jenkins.io/)

- search `trx`
- check `MSTest` plugin details

Back to Jenkins - _Manage Jenkins_ ... _Manage Plugins_

- from `Available` tab
- install MSTest

In `pi` job, add post-build step for MSTest

- default options

> Build

- test results per build
- drill down into tests

> Build again & refresh job page

- with multiple builds trend report at job level
