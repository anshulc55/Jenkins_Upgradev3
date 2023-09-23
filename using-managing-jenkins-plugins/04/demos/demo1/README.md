# Demo 1

Build a simple "Hello, World" plugin using a template.

## Bootstrap the plugin project

Create a local folder for the source code:

```
mkdir -p /ps-jenkins/m4
```

Run a Java dev environment in a container:

```
docker run `
  -it --entrypoint sh `
  -v C:\ps-jenkins\m4:/src `
  -p 8081:8080 `
 maven:3.6.3-jdk-8
```

Inside the container, check the tools:

```
java -version

mvn -version
```

Create a plugin from the Jenkins templates:

```
cd /src

mvn -U archetype:generate -Dfilter="io.jenkins.archetypes:"
```

- Select `hello-world`
- version `1.6`
- artifactId `m4-demo`

## Check the code

Still inside the container:

```
cd psod-m4-demo

ls
```

Run the build:

```
mvn verify
```

> Open local folder in VS Code

## Start the dev Jenkins instance

Run the HPI target, which starts Jenkins in the container with the plugin installed:

```
mvn hpi:run
```

On the host, open Jenkins:

> http://localhost:8081/jenkins

- New freestyle job
- Add "Hello World" build step
- Run, check console
