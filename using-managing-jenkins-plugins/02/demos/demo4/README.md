## Run Jenkins

Built from [this Dockerfile](../jenkins/bare/Dockerfile), standard Jenkins 2.204 install with no plugins:

```
docker run -d -p 8084:8080 --name jenkins4 sixeyed/psod-jenkins:2.204.4
```

Browse to http://localhost:8084 & sign in

```
docker logs jenkins4
```

## Finish the Jenkins setup

Click _Select plugins to install_:

- Select _None_

- Add _Git_ and _Pipelines_ (dependency count)

- Finish install & login

Still warnings, but config issues not security vulnerabilities

## Check plugins

Select _Manage Jenkins_ and _Manage Plugins_.

- No updates (latest install on setup)

- Installed, ~50 plugins

- Explicitly installed 2

## Try a pipeline build

- _New Item_, pipeline type

- Add pipeline script

```
pipeline {
   agent any

   stages {
      stage('Build') {
         steps {
            echo 'Build...'
            sh 'docker-compose version'
         }
      }
      stage('Test') {
         steps {
            echo 'Test...'
            sh 'git version'
         }
      }
   }
}
```

- Build Now

- Check stage logs

- Configure - pipeline from SCM, can point to declarative file in repo
