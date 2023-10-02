pipeline {
    agent any

    environment {
        // Define environment variables here
        MY_ENV_VAR = 'Custom Value'
    }

    stages {
        stage('Checkout') {
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

        stage('Build') {
            steps {
                // Build your application here (e.g., compile, package, etc.)
                sh '''
                ls
                echo "In Build Step"
                '''
            }
        }

        stage('Test') {
            steps {
                // Run your tests (e.g., unit tests, integration tests)
                sh 'echo "In Test Step"'
            }
        }

        stage('Deploy') {
            steps {
                // Deploy your application to a target environment (e.g., staging, production)
                sh 'echo "Value of ENV Varaible is "$MY_ENV_VAR""'
            }
        }
    }

    post {
        success {
            // Actions to perform when the pipeline succeeds
            echo 'Pipeline succeeded!'
        }
        failure {
            // Actions to perform when the pipeline fails
            echo 'Pipeline failed!'
        }
    }
}
