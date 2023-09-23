FROM alpine:3.11 AS installer

ARG JENKINS_VERSION="2.222.1"

RUN apk add --no-cache curl
RUN apk add --no-cache --repository http://dl-cdn.alpinelinux.org/alpine/edge/community docker-cli
RUN curl -SL -o jenkins.war http://mirrors.jenkins.io/war-stable/$JENKINS_VERSION/jenkins.war

# Jenkins
FROM alpine:3.11

# jenkins deps
RUN apk add --no-cache \
    bash \
    coreutils \
    git \
    openjdk11 \
    openssh-client \
    ttf-dejavu \
    unzip 

# compose deps
RUN apk add --no-cache \
    gcc \
    libc-dev \
    libffi-dev \
    make \
    openssl-dev \
    python-dev \
    py-pip

RUN pip install docker-compose

ARG JENKINS_VERSION="2.222.1"
ENV JENKINS_VERSION=${JENKINS_VERSION} \
    JENKINS_HOME="/data"

VOLUME ${JENKINS_HOME}

EXPOSE 8080
ENTRYPOINT java -Duser.home=${JENKINS_HOME} -jar /jenkins/jenkins.war

COPY --from=installer /usr/bin/docker /usr/bin/docker
COPY --from=installer /jenkins.war /jenkins/jenkins.war
