# Demo 2

Minimum Jenkins version set in plugin update.

## Run Jenkins

Same container as demo 1:

```
docker container ls
```

> Browse to http://localhost:8081 and check `demo1` job

_Manage Jenkins_..._About Jenkins_

- Version 2.164.3
- LTS has three-month cycle
- This is old...

## Update the plugin

_Manage plugins_..._Advanced_

- Upload `docker-hub-link-3.0.hpi`
- Restart Jenkins

No warnings on startup.

_Manage Jenkins_ - flags the issue; no options to correct

_Manage Plugins_..._Installed_ - no `Docker Hub Link` plugin

> Failed upgrades remove the original plugin version

- Run build, succeeds
- Output - no link
- Check output from earlier version - no link
- Check config - no plugin

## Check the job data

Connect to the container:

```
docker exec -it jenkins1 sh

echo $JENKINS_HOME

cat $JENKINS_HOME/jobs/demo1/config.xml

cat $JENKINS_HOME/jobs/demo1/builds/1/build.xml
```

> Plugin data is still therein the config, but there is no plugin to act on it, so Jenkins silently ignores it.

## Revert to the original plugin version

_Manage Plugins_..._Advanced_

- Upload `docker-hub-link-1.0.hpi`
- Check job config
- Build job
