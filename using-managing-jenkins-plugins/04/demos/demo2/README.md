# Demo 2

Building a useful plugin - a post-build step which shows a link to Docker Hub.

## Run the plugin

Start a new Docker dev environment, mounting the local source code:

```
docker run `
  -it --entrypoint sh `
  -v "$(pwd)\docker-hub-link:/src" `
  -p 8081:8080 `
 maven:3.6.3-jdk-8
```

Inside the container, build and run the plugin:

```
cd /src

mvn hpi:run
```

When the build completes, it runs a local dev instance of Jenkins:

> http://localhost:8081/jenkins

## Test the plugin

Check the plugin is listed from _Manage Jenkins_..._Manage Plugins_..._Installed_

Then use the plugin in a job:

- New item, freestyle, name `Pi`
- Add a build step: `echo "Demo 2"`
- Add a post-build step - Docker Hub
- Run, check console
- Open the job run, check sidebar

## See how Jenkins stores plugin data

The source folder is used for test runs of the plugin.

The plugin config is stored in:

- [config.xml](./docker-hub-link/work/jobs/pi/config.xml)

And the values used are stored in each build:

- [build.xml](./docker-hub-link/work/jobs/pi/builds/1/build.xml)

## Walk through the code

For a post-build step you extend the `Recorder` class:

- [DockerHubLinkRecorder](./docker-hub-link/src/main/java/io/jenkins/plugins/dockerHubLink/DockerHubLinkRecorder.java)

To set options for the plugin, build the UI in [Jelly](http://commons.apache.org/proper/commons-jelly/):

- [config.jelly](./docker-hub-link/src/main/resources/io/jenkins/plugins/dockerHubLink/DockerHubLinkRecorder/config.jelly)

To add logic which runs during a build, add an `Action` class:

- [DockerHubLinkAction](./docker-hub-link/src/main/java/io/jenkins/plugins/dockerHubLink/DockerHubLinkAction.java)

And to render content in the build output, add another Jelly UI:

- [index.jelly](./docker-hub-link/src/main/resources/io/jenkins/plugins/dockerHubLink/DockerHubLinkAction/index.jelly)

## Further reading

Lots of good docs from the Jenkins team for building plugins:

- Extension points: https://jenkins.io/doc/developer/extensions/jenkins-core/

- Plugin developer guide: https://jenkins.io/doc/developer/plugin-development/

- Jenkins API documentation: https://javadoc.jenkins.io/overview-summary.html

- A good sample community plugin: https://github.com/jenkinsci/s3explorer-plugin
