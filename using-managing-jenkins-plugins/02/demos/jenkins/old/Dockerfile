FROM sixeyed/psod-jenkins:2.204.4

ENTRYPOINT java -Duser.home=${JENKINS_HOME} -Djenkins.install.runSetupWizard=false -jar /jenkins/jenkins.war

COPY ./jenkins.install.UpgradeWizard.state ${JENKINS_HOME}/
COPY ./plugins/ ${JENKINS_HOME}/plugins/
COPY ./scripts/ ${JENKINS_HOME}/init.groovy.d/