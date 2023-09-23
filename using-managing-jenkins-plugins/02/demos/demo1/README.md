## Run Jenkins

Built from [this Dockerfile](../jenkins/core/Dockerfile), standard Jenkins 2.204 install:

```
docker run -d -p 8081:8080 --name jenkins1 sixeyed/psod-jenkins:2.204.4
```

Browse to http://localhost:8081 & sign in

```
docker logs jenkins1
```

## Finish the Jenkins setup

Click _Select plugins to install_ (not _Install suggested plugins_), then:

- select _None_
- finish install & login

## See what we can do

- Left nav has _New Item_, _People_ etc.

- Click _New Item_ to create a job

- Only one type of project, Freestyle

- _Source Code Management_ : none

- _Build Triggers_ : schedule and based on other jobs

- _Build_ : add step, execute shell (Linux only)

- add shell step:

```
echo "Hello from build $BUILD_TAG"
```

- click _Build Now_, check build output

## Use tools installed on the server

- edit job, add new step ( can run tools installed and in path)

```
docker-compose version

docker version
```

- Click _Build Now_ and check output
