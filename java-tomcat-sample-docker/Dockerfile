FROM tomcat:8.0
ADD target/*.war /usr/local/tomcat/webapps/tomcat-sample.war
EXPOSE 8080
CMD ["catalina.sh", "run"]