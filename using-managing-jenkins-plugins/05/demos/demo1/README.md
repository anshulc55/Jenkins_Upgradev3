# Demo 1

Breaking change in a plugin update.

## Run Jenkins

Built from [this Dockerfile](../jenkins/20.02/Dockerfile), standard Jenkins 2.164 install with automated and custom plugins.

```
docker container run -d `
  -p 8081:8080 `
  --name jenkins1 `
  sixeyed/psod-jenkins:m5-20.02
```

> Browse to http://localhost:8081 and log in with `psod`/`psod`

_Manage Jenkins_ - multiple security warnings - old version of jenkns but latest plugins.

_Manage Plugins_..._Installed_

- Docker Hub Link version 1.0 from HPI

## Run a job using the plugin

New freestyle job:

- Name `demo1`
- Add Docker Hub Link post-build
- Repo name `ps`
- Build

> Check output

## Update the plugin

_Manage Plugins_..._Advanced_

- Install `docker-hub-link-2.0.hpi`
- Click Restart

_Manage Plugins_..._Installed_

- Docker Hub Link is 2.0

> Build original job - fails

Configure job - new validation in plugin
