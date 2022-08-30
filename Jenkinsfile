pipeline {
      agent any
      stages {
            stage('Init') {
                  steps {
                        echo 'Hi, this is DamiaNeoDon this time'
                        echo 'We are Starting the Testing'
                  }
            }
            stage('Build') {
                  steps {
                        echo 'Building Sample Maven Project'
                  }
            }
            stage('Deploy') {
                  steps {
                        echo "Deploying in Staging Area"
                  }
            }
            stage('Deploy Production 123') {
                  steps {
                          echo "Deploying in Production Area 321"
                  }
                        stage('extra concludnig step') {
            steps {
                          echo "extra step in prod"
                  }
            }
            }
      }
}
