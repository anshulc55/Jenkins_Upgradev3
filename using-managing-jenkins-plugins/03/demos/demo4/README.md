# Demo 4

Self-contained Jenkins build with automated plugin setup .

## Run Jenkins

Built from [this Dockerfile](../jenkins/m3-demo4/Dockerfile), standard Jenkins 2.204 install plus scripted plugin setup in [this Groovy script](../jenkins/m3-demo4/scripts/install-plugins.groovy):

```
docker run -d `
  -p 8083:8080 `
  --name jenkins3 `
  -v /var/run/docker.sock:/var/run/docker.sock `
  sixeyed/psod-jenkins:m3-demo4
```

Browse to http://localhost:8083

> Longer startup time - script runs at start, so first time deploys plugins

Sign in with:

- username `psod`
- password `psod`

## Check the Jenkins filesystem

Connect to the container:

```
docker exec -it jenkins3 sh
```

List the plugin directory contents:

```
ls /data/plugins
```

## Add creds

- Jenkins credentials add new username/password `dockerHub`
- use Docker Hub username and authentication token

## Build the pipeline

New pipeline job, `pi`

Using [this Jenkinsfile in GitHub](https://github.com/sixeyed/pi/blob/psod/Jenkinsfile)

_Pipline script from SCM_

- Repo `https://github.com/sixeyed/pi`
- Branch `*/psod`
- File `Jenkinsfile`

_Additional Behaviours_ (standard Git)

- advanced clone - shallow, 1
- clean before checkout

## Notify

_Manage Jenkins_ ... _Configure system_

- add workspace `psod-jenkins`
- add Slack API token

> Build now - all good

Test results published, but no graph on main page

Slack notifications there

## Try with alternative pipeline

Using [Jenkinsfile.v2 in GitHub](https://github.com/sixeyed/pi/blob/psod/Jenkinsfile.v2), which builds with [Dockerfile.v2](https://github.com/sixeyed/pi/blob/psod/docker/web/Dockerfile.v2).

New pipeline job, _Copy from_ Pi

_Pipline script from SCM_

- Change file to `Jenkinsfile.v2`

> Build and check outpute

Compare Jenkinsfile to a typical [GitHub Actrions workflow](https://github.com/sixeyed/pi/blob/master/.github/workflows/build-linux.yaml).
