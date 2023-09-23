## Run Jenkins

Built from [this Dockerfile](../jenkins/core/Dockerfile), standard Jenkins 2.204 install:

```
docker run -d -p 8082:8080 --name jenkins2 sixeyed/psod-jenkins:2.204.4
```

Browse to http://localhost:8082 & sign in

```
docker logs jenkins2
```

## Finish the Jenkins setup

Click _Install suggested plugins_:

- Installs a whole bunch of plugins

- Generic: folders creds, pipeline

- Java assumptions: ant, gradle

- Multiple SCM - Git, Subversion, GitHub

- Auth with LDAP, PAM

- Notification with email

## See what we can do

- Left nav has New Item, People etc. also Credentials

- Click _New Item_ to create a job

- Lots of project types, inc. pipeline, folder, freestyle

- Create folder

- Can set defaults for docker builds & shared libraries

- Click folder & _New Item_

## New features in the job definition

- _Source Code Management_ : Git, Subversion

- _Build Triggers_ : schedule and based on other jobs + GitHub trigger + poll scm

- New stage _Build environment_ -> secrets, Gradle, Ant

- _Build_ : add step, execute shell (Linux only); gradle & ant options - invoke target

- Add Ant step, target `build`

- _Build Now_ fails

- Plugins may not validate across the whole job...
