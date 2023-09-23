# Demo 3

Jenkins build with portable scripts and offline plugin setup.

## Download plugins

https://plugins.jenkins.io/

- search git; archive; download hpi
- rename to zip
- check `META-INF` folder
  - `MANIFEST.MF` lists dependencies

## Run Jenkins

Built from [this Dockerfile](../jenkins/m3-demo3/Dockerfile), M3 Jenkins install with plugins in `./jenkins/m3-demo3/plugins`:

```
docker run -d `
  -p 8082:8080 `
  --name jenkins2 `
  -v /var/run/docker.sock:/var/run/docker.sock `
  sixeyed/psod-jenkins:m3-demo3
```

Browse to http://localhost:8082 & sign in (`psod`/`psod`)

_Manage Jenkins_ - huge error list;

> Installing HPIs doesn't install plugin dependencies

If online, click `Correct`

- otherwise, plugin ID in list is URL in catalogue
- and in download

## Try again

Copy in those - and then warnings about _their_ deps; so it goes on until...

Remove old Jenkins:

```
docker container rm -f jenkins2
```

Start with new image from [this Dockerfile](../jenkins/m3-demo3-v2/Dockerfile), M3 Jenkins install with plugins in `./jenkins/m3-demo3-v2/plugins`:

```
docker run -d `
  -p 8082:8080 `
  --name jenkins2 `
  -v /var/run/docker.sock:/var/run/docker.sock `
  sixeyed/psod-jenkins:m3-demo3-v2
```

Browse to http://localhost:8082 & sign in (`psod`/`psod`)

## Other plugin installation options

_Manage Jenkins_ ... _Manage Plugins_ - Advanced

- lets you upload HPI

_Manage Jenkins_ ... _Jenkins CLI_

- `install-plugin` command

## Create the job

- New freestyle job called `pi`
- repo url https://github.com/sixeyed/pi

  - branch spec `*/psod`
  - advanced clone - shallow, 1
  - clean before checkout

- All same options, just with git plugin (not GitHub)

- poll scm
  - schedule `H/5 * * * *`

## Add build steps

Build code:

```
chmod +x ./ci/01-build.sh && ./ci/01-build.sh
```

Run smoke test

```
chmod +x ./ci/02-smoke-test.sh && ./ci/02-smoke-test.sh
```

Unit tests

```
chmod +x ./ci/03-unit-test.sh && ./ci/03-unit-test.sh
```

> Build Now - check console log

## Add test report

Add post-build step

- MSTest report

> Build and check - test results per build, drill down into tests

> Build again

Refresh job page

- with multiple builds trend report at job level

## Publish

Just using the script, not the CloudBees plugin

- Jenkins credentials add new username/password
- use Docker Hub username and authentication token

- add build environment, hub creds:

  - `DOCKER_HUB_USER`
  - `DOCKER_HUB_PASSWORD`

- add build step

```
chmod +x ./ci/04-push.sh && ./ci/04-push.sh
```

## Notify

_Manage Jenkins_ ... _Configure system_

- add workspace `psod-jenkins`
- add Slack API token

In the `pi` job, add post-build step

- Slack notification
- Notify: start, failure, success
- Advanced: include test results

> Build and check
