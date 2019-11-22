pipeline {
    agent any
    stages {
        stage('Build Application') {
            steps {
                sh 'mvn -f java-tomcat-sample/pom.xml clean package'
            }
            post {
                success {
                    echo "Now Archiving the Artifacts...."
                    archiveArtifacts artifacts: '**/*.war'
                }
            }
        }

        stage('Create Tomcat Docker Image'){
            steps {
                sh "find / -name java-tomcat-maven-example.war"
                sh "pwd"
                sh "ls -a"
                sh "docker build ./java-tomcat-sample-docker -t tomcatsamplewebapp:${env.BUILD_ID}"
            }
        }

    }
}


pipeline {
    agent any
    stages {
        stage ('Build Servlet Project') {
            steps {
                /*For windows machine */
               //bat  'mvn clean package'
 
                /*For Mac & Linux machine */
                sh  'mvn clean package'
            }
 
            post{
                success{
                    echo 'Now Archiving ....'
 
                    archiveArtifacts artifacts : '**/*.war'
                }
            }
        }
 
        stage ('Create Tomcat Docker Image') {
            steps{
                sh "docker build . -t tomcatwebapp:${env.BUILD_ID}"
 
                //bat "docker build . -t tomcatwebapp:${$env.BUILD_ID}"
 
            }
        }
 
    }
}