# Demo 3

Automating Jenkins and plugin updates.

## Run Jenkins

Start a new container, storing job data on the local machine:

```
mkdir /jenkins-jobs

docker run -d `
  -p 8082:8080 `
  -v C:\jenkins-jobs:/data/jobs `
  --name jenkins2 `
  sixeyed/psod-jenkins:m5-20.02
```

- Walk through the [Dockerfile](../jenkins/20.02/Dockerfile) and [base Dockerfile](../jenkins/base/2.164.3/Dockerfile)

- Compare with [official Jenkins Docker image](https://hub.docker.com/r/jenkins/jenkins) and [plugins.txt](https://github.com/fabric8io/jenkins-docker/blob/master/plugins.txt)

> Open http://localhost:8082 and login in with `psod`/`psod`

_Manage Jenkins_..._About Jenkins_

- Version 2.164.3

_Manage Plugins_..._Installed_

- Plugin version 1.0

## Add a job

New freestyle job:

- Name `demo3`
- Add Docker Hub Link post-build
- Repo owner `pi`
- Build

> Check output

## Update Jenkins

_Manage Jenkins_..._Prepare for shutdown_

```
docker rm -f jenkins2

docker container ls

tree C:\jenkins-jobs

docker run -d `
  -p 8083:8080 `
  -v C:\jenkins-jobs:/data/jobs `
  --name jenkins3 `
  sixeyed/psod-jenkins:m5-20.03
```

> Walk through [Dockerfile](../jenkins/20.03/Dockerfile) and [base Dockerfile](../jenkins/base/2.222.1/Dockerfile)

- OS update
- Java 11
- Latest Jenkins
- Latest plugin

> Log in at http://localhost:8083 with `psod`/`psod`

> Check link plugin at http://localhost:8083/pluginManager/installed

- Docker Hub Link is at 3.0

Demo3 job is still there:

- Check build log, link renders correctly
- Configure job, plugin step shown
- Build job, succeeds
