pipeline {
    agent any
    stages {
        stage('Verify Shell Environment') {
            steps {
                script {
                    // Get the job name and build number
                    def jobName = env.JOB_NAME
                    def buildNumber = env.BUILD_NUMBER

                    // Print the job name and build number
                    echo "Job Name: $jobName"
                    echo "Build Number: $buildNumber"

                    // Use them in shell commands
                    sh 'sudo docker --version'
                    sh 'sudo dotnet --info'
                }
            }
        }

        stage('Checkout Jenkins Upgrade3 Git Repository') {
            steps {
                script {
                    // Clone the Git repository's master branch
                    def gitRepoUrl = 'https://github.com/anshulc55/Jenkins_Upgradev3.git'

                    checkout([$class: 'GitSCM', 
                        branches: [[name: '*/master']], 
                        userRemoteConfigs: [[url: gitRepoUrl]], 
                        extensions: [[$class: 'CleanBeforeCheckout'], [$class: 'CloneOption', noTags: false, shallow: true, depth: 1]]
                    ])
                }
            }
        }

        stage('Build Application') {
            steps {
                sh 'chmod +x ./jenkins-plugin-model/ci/01-build.sh && ./jenkins-plugin-model/ci/01-build.sh'
            }
        }

        stage('Unit Test') {
            steps {
                sh 'chmod +x ./jenkins-plugin-model/ci/03-unit-test.sh && ./jenkins-plugin-model/ci/03-unit-test.sh'
                mstest testResultsFile:"**/*.trx"
            }
        }

        stage('Push Docker Image') {
            steps {
                script {
                    // Get the job name and build number
                    def jobName = env.JOB_NAME
                    def buildNumber = env.BUILD_NUMBER

                    // Print the job name and build number
                    echo "Job Name: $jobName"
                    echo "Build Number: $buildNumber"
                
                withCredentials([usernamePassword(credentialsId: '1bb08ca6-f3cb-4ec7-953f-c3f7a93401ac', usernameVariable: 'DOCKER_HUB_USER', passwordVariable: 'DOCKER_HUB_PASSWORD')]) {                      
                    sh "chmod +x ./jenkins-plugin-model/ci/04-push.sh"
                    sh "./jenkins-plugin-model/ci/04-push.sh $buildNumber"
                }
                echo "Build Completed - Job Name: $jobName  --  Build Number: $buildNumber"
            }
        }
    }
}
}