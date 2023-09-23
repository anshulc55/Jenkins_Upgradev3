FROM sixeyed/psod-jenkins:m5-base-2.222.1

ENTRYPOINT java -Duser.home=${JENKINS_HOME} -Djenkins.install.runSetupWizard=false -jar /jenkins/jenkins.war

COPY ./jenkins.install.UpgradeWizard.state ${JENKINS_HOME}/
COPY ./plugins/ ${JENKINS_HOME}/plugins/
COPY ./scripts/ ${JENKINS_HOME}/init.groovy.d/