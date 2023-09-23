# Demo 2

Add publish & notify steps

## Publish

Build Docker image and publish to Docker Hub; search for `Docker Hub` in [plugins](https://plugins.jenkins.io/).

- main "Docker" most popular
- but lots of dependencies and lots of features I don't need
- try CloudBees Docker Build & Publish

Back to Jenkins - _Manage Jenkins_ ... _Manage Plugins_

- from `Available` tab
- install CloudBees Docker Build & Publish

In `pi` job, add _build and publish_ step

- repo: `sixeyed/pi-psod`
- registry credentials - add new username/password creds
- use Docker Hub username and [authentication token](https://hub.docker.com/settings/security)
- advanced - Dockerfile path `./docker/web/Dockerfile`

Build now - FAILS (3yr old plugin)

- add build environment, hub creds:
  - `DOCKER_HUB_USER`
  - `DOCKER_HUB_PASSWORD`
- add build step, before build & push

```
docker login -u $DOCKER_HUB_USER -p $DOCKER_HUB_PASSWORD
```

## Notify

Notify on Slack; search for `Slack` in [plugins](https://plugins.jenkins.io/).

Browse to app management in Slack: https://psod-jenkins.slack.com/apps/manage

- search for Jenkins CI
- add to Slack
- choose `m3` channel
- check Jenkins steps

Back to Jenkins - _Manage Jenkins_ ... _Manage Plugins_

- install `Slack notification` plugin
- browse to _Manage Jenkins_ ... _Configure system_
- add workspace `psod-jenkins`
- add Slack API token

In the `pi` job, add post-build step

- Slack notification
- Notify: start, failure, success
- Advanced: include test results

> Build now

Check notifications in Slack - URLs point to local instance
