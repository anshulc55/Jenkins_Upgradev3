pipeline {
    agent any

    stages {
        stage('Install .NET 7 SDK') {
            steps {
                sh 'curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 7.0'
            }
        }

        stage('Install Docker Engine CE') {
            steps {
                sh '''
                    curl -fsSL https://get.docker.com -o get-docker.sh
                    sudo sh get-docker.sh
                    sudo systemctl start docker
                    sudo systemctl enable docker
                    sudo systemctl status docker
                    sudo docker --version
                '''
            }
        }

        stage('Add Jenkins User to Docker Group') {
            steps {
                sh '''
                    sudo apt-get update
                    sudo usermod -aG docker jenkins
                    sudo systemctl restart docker
                '''
            }
        }
    }
}
