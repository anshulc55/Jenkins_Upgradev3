# Demo 3

Deploying custom plugins to a real Jenkins server (manually).

## Build the HPI

```
mvn hpi:hpi
```

Generates HPI file in `docker-hub-link/target`.

## Deploy to a real Jenkins instance

Run a new Jenkins container from the setup in the previous module:

```
docker run -d `
  -p 8083:8080 `
  --name jenkins3 `
    sixeyed/psod-jenkins:m3-demo4
```

> Browse to http://localhost:8083 and log in with `psod`/`psod`

Install the plugin from _Manage Jenkins_..._Manage Plugins_..._Advanced_

- Upload plugin
- Browse to `docker-hub-link.hpi`
- Installs

## Test the plugin

- New freestyle job `ch02-hello-diamol`
- Add post-build step
- Docker Hub, org `diamol`

Build the job and check output.
